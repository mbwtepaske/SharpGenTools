﻿using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using SharpGen.Config;
using SharpGen.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger = SharpGen.Logging.Logger;

namespace SharpGenTools.Sdk.Tasks
{
    public class GenerateExtensionHeaders : SharpGenCppTaskBase
    {
        [Required]
        public ITaskItem[] ExtensionHeaders { get; set; }

        [Required]
        public string CastXmlExecutablePath { get; set; }

        [Required]
        public string OutputPath { get; set; }

        [Required]
        public ITaskItem PartialCppModuleCache { get; set; }

        [Required]
        public ITaskItem[] UpdatedConfigs { get; set; }

        [Required]
        public string[] CastXmlArguments { get; set; }

        [Output]
        public ITaskItem[] ReferencedHeaders { get; set; }

        protected override bool Execute(ConfigFile config)
        {
            var configsWithExtensions = new HashSet<string>();
            foreach (var file in ExtensionHeaders)
            {
                configsWithExtensions.Add(file.GetMetadata("ConfigId"));
            }

            var updatedConfigs = new HashSet<ConfigFile>();
            foreach (var cfg in config.ConfigFilesLoaded)
            {
                if (UpdatedConfigs.Any(updated => updated.GetMetadata("Id") == cfg.Id))
                {
                    updatedConfigs.Add(cfg);
                }
            }

            var resolver = new IncludeDirectoryResolver(SharpGenLogger);
            resolver.Configure(config);

            var castXml = new CastXml(SharpGenLogger, resolver, CastXmlExecutablePath, CastXmlArguments)
            {
                OutputPath = OutputPath
            };

            var macroManager = new MacroManager(castXml);

            var cppExtensionGenerator = new CppExtensionHeaderGenerator(macroManager);

            var module = cppExtensionGenerator.GenerateExtensionHeaders(config, OutputPath, configsWithExtensions, updatedConfigs);

            ReferencedHeaders = macroManager.IncludedFiles.Select(file => new TaskItem(file)).ToArray();

            if (SharpGenLogger.HasErrors)
            {
                return false;
            }

            module.Write(PartialCppModuleCache.ItemSpec);

            return !SharpGenLogger.HasErrors;
        }
    }
}
