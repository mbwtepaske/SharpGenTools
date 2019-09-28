﻿using System.Xml.Serialization;

namespace SharpGen.Config
{
    [XmlType("map")]
    public class MappingRule : MappingBaseRule
    {
        public MappingRule()
        {
            IsFinalMappingName = false;
            MethodCheckReturnType = true;
        }

        /// <summary>
        /// Default Value for parameters
        /// </summary>
        [XmlAttribute("assembly")]
        public string Assembly { get; set; }

        /// <summary>
        /// Default Value for parameters
        /// </summary>
        [XmlAttribute("namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// Default Value for parameters
        /// </summary>
        [XmlAttribute("default")]
        public string DefaultValue { get; set; }

        [XmlIgnore]
        public bool? MethodCheckReturnType { get; set; }
        [XmlAttribute("check")]
        public bool _MethodCheckReturnType_ { get { return MethodCheckReturnType.Value; } set { MethodCheckReturnType = value; } } public bool ShouldSerialize_MethodCheckReturnType_() { return MethodCheckReturnType != null; }

        [XmlIgnore]
        public bool? AlwaysReturnHResult { get; set; }
        [XmlAttribute("hresult")]
        public bool _AlwaysReturnHResult_ { get { return AlwaysReturnHResult.Value; } set { AlwaysReturnHResult = value; } } public bool ShouldSerialize_AlwaysReturnHResult_() { return AlwaysReturnHResult != null; }

        /// <summary>
        /// General visibility for Methods
        /// </summary>
        [XmlIgnore]
        public Visibility? Visibility { get; set; }
        [XmlAttribute("visibility")]
        public Visibility _Visibility_ { get { return Visibility.Value; } set { Visibility = value; } } public bool ShouldSerialize_Visibility_() { return Visibility != null; }

        /// <summary>
        /// General visibility for DefaultCallback class
        /// </summary>
        [XmlIgnore]
        public Visibility? NativeCallbackVisibility { get; set; }
        [XmlAttribute("callback-visibility")]
        public Visibility _NativeCallbackVisibility_ { get { return NativeCallbackVisibility.Value; } set { NativeCallbackVisibility = value; } } public bool ShouldSerialize_NativeCallbackVisibility_() { return NativeCallbackVisibility != null; }

        [XmlIgnore]
        public NamingFlags? NamingFlags { get; set; }
        [XmlAttribute("naming")]
        public NamingFlags _NamingFlags_ { get { return NamingFlags.Value; } set { NamingFlags = value; } } public bool ShouldSerialize_NamingFlags_() { return NamingFlags != null; }

        /// <summary>
        /// Name of a native callback
        /// </summary>
        [XmlAttribute("callback-name")]
        public string NativeCallbackName { get; set; }

        /// <summary>
        /// Used for methods, to force a method to not be translated to a property
        /// </summary>
        [XmlIgnore]
        public bool? Property { get; set; }
        [XmlAttribute("property")]
        public bool _Property_ { get { return Property.Value; } set { Property = value; } } public bool ShouldSerialize_Property_() { return Property != null; }

        /// <summary>
        /// Use to output vtbl offsets for methods as private fields that can be modified
        /// </summary>
        [XmlIgnore]
        public bool? CustomVtbl { get; set; }
        [XmlAttribute("custom-vtbl")]
        public bool _CustomVtbl_ { get { return CustomVtbl.Value; } set { CustomVtbl = value; } } public bool ShouldSerialize_CustomVtbl_() { return CustomVtbl != null; }

        /// <summary>
        /// Used for property zith COM Objects, in order to persist the getter
        /// </summary>
        [XmlIgnore]
        public bool? Persist { get; set; }
        [XmlAttribute("persist")]
        public bool _Persist_ { get { return Persist.Value; } set { Persist = value; } } public bool ShouldSerialize_Persist_() { return Persist != null; }

        /// <summary>
        /// Gets or sets the struct pack alignment.
        /// </summary>
        /// <value>The struct pack. </value>
        [XmlIgnore]
        public int? StructPack { get; set; }
        [XmlAttribute("pack")]
        public int _StructPack_ { get { return StructPack.Value; } set { StructPack = value; } } public bool ShouldSerialize_StructPack_() { return StructPack != null; }

        /// <summary>
        /// Mapping name
        /// </summary>
        [XmlAttribute("name-tmp")]
        public string MappingName { get; set; }
        public bool ShouldSerializeMappingName() { return IsFinalMappingName.HasValue && !IsFinalMappingName.Value; }
        
        /// <summary>
        /// Mapping name
        /// </summary>
        [XmlAttribute("name")]
        public string MappingNameFinal
        {
            get { return MappingName; }
            set
            {
                MappingName = value;
                IsFinalMappingName = true;
            }
        }
        public bool ShouldSerializeMappingNameFinal() { return !IsFinalMappingName.HasValue || IsFinalMappingName.Value; }


        /// <summary>
        /// True if the MappingName doesn't need any further rename processing
        /// </summary>
        [XmlIgnore]
        public bool? IsFinalMappingName { get; set; }

        /// <summary>
        /// True if a struct should used a native value type marshalling
        /// </summary>
        [XmlIgnore]
        public bool? StructHasNativeValueType { get; set; }
        [XmlAttribute("native")]
        public bool _StructHasNativeValueType_ { get { return StructHasNativeValueType.Value; } set { StructHasNativeValueType = value; } } public bool ShouldSerialize_StructHasNativeValueType_() { return StructHasNativeValueType != null; }

        /// <summary>
        /// True if a struct should be used as a class instead of struct (imply StructHasNativeValueType)
        /// </summary>
        [XmlIgnore]
        public bool? StructToClass { get; set; }
        [XmlAttribute("struct-to-class")]
        public bool _StructToClass_ { get { return StructToClass.Value; } set { StructToClass = value; } } public bool ShouldSerialize_StructToClass_() { return StructToClass != null; }

        /// <summary>
        /// True if a struct is using some Custom Marshal (imply StructHasNativeValueType)
        /// </summary>
        [XmlIgnore]
        public bool? StructCustomMarshal { get; set; }
        [XmlAttribute("marshal")]
        public bool _StructCustomMarshal_ { get { return StructCustomMarshal.Value; } set { StructCustomMarshal = value; } } public bool ShouldSerialize_StructCustomMarshal_() { return StructCustomMarshal != null; }

        /// <summary>
        /// True if a struct is using some Custom Marshal (imply StructHasNativeValueType)
        /// </summary>
        [XmlIgnore]
        public bool? IsStaticMarshal { get; set; }
        [XmlAttribute("static-marshal")]
        public bool _IsStaticMarshal_ { get { return IsStaticMarshal.Value; } set { IsStaticMarshal = value; } } public bool ShouldSerialize_IsStaticMarshal_() { return IsStaticMarshal != null; }

        /// <summary>
        /// True if a struct is using some a Custom New for the Native struct (imply StructHasNativeValueType)
        /// </summary>
        [XmlIgnore]
        public bool? StructCustomNew { get; set; }
        [XmlAttribute("new")]
        public bool _StructCustomNew_ { get { return StructCustomNew.Value; } set { StructCustomNew = value; } } public bool ShouldSerialize_StructCustomNew_() { return StructCustomNew != null; }
        
        /// <summary>
        /// Mapping type name
        /// </summary>
        [XmlAttribute("type")]
        public string MappingType { get; set; }

        /// <summary>
        /// Set to true to override the type used to natively represent this member when marshalling with the mapping type
        /// </summary>
        [XmlIgnore]
        public bool? OverrideNativeType { get; set; }
        [XmlAttribute("override-native-type")]
        public bool _OverrideNativeType_ { get { return OverrideNativeType.Value; } set { OverrideNativeType = value; } }
        public bool ShouldSerialize_OverrideNativeType_() { return OverrideNativeType != null; }

        /// <summary>
        /// Pointer to modify the type
        /// </summary>
        [XmlAttribute("pointer")]
        public string Pointer { get; set; }

        /// <summary>
        /// ArrayDimension
        /// </summary>
        [XmlAttribute("array")]
        public string TypeArrayDimension { get; set; }

        /// <summary>
        /// Used for enums, to tag enums that are used as flags
        /// </summary>
        [XmlIgnore]
        public bool? EnumHasFlags { get; set; }
        [XmlAttribute("flags")]
        public bool _EnumHasFlags_ { get { return EnumHasFlags.Value; } set { EnumHasFlags = value; } } public bool ShouldSerialize_EnumHasFlags_() { return EnumHasFlags != null; }

        /// <summary>
        /// Used for enums, to tag enums that should have none value (0)
        /// </summary>
        [XmlIgnore]
        public bool? EnumHasNone { get; set; }
        [XmlAttribute("none")]
        public bool _EnumHasNone_ { get { return EnumHasNone.Value; } set { EnumHasNone = value; } } public bool ShouldSerialize_EnumHasNone_() { return EnumHasNone != null; }

        /// <summary>
        /// Used for interface to mark them as callback interface
        /// </summary>
        [XmlIgnore]
        public bool? IsCallbackInterface { get; set; }
        [XmlAttribute("callback")]
        public bool _IsCallbackInterface_ { get { return IsCallbackInterface.Value; } set { IsCallbackInterface = value; } } public bool ShouldSerialize_IsCallbackInterface_() { return IsCallbackInterface != null; }

        /// <summary>
        /// Used for interface to mark them as dual-callback interface
        /// </summary>
        [XmlIgnore]
        public bool? IsDualCallbackInterface { get; set; }
        [XmlAttribute("callback-dual")]
        public bool _IsDualCallbackInterface_ { get { return IsDualCallbackInterface.Value; } set { IsDualCallbackInterface = value; } } public bool ShouldSerialize_IsDualCallbackInterface_() { return IsDualCallbackInterface != null; }

        [XmlIgnore]
        public bool? AutoGenerateShadow { get; set; }
        [XmlAttribute("autogen-shadow")]
        public bool _AutoGenerateShadow_ { get => AutoGenerateShadow.Value; set => AutoGenerateShadow = value; } public bool ShouldSerialize_AutoGenerateShadow_() { return AutoGenerateShadow != null; }
        
        [XmlAttribute("shadow-name")]
        public string ShadowName { get; set; }

        [XmlAttribute("vtbl-name")]
        public string VtblName { get; set; }

        /// <summary>
        /// Used for methods to specify that inheriting methods from interface should be kept public and without any rename.
        /// </summary>
        [XmlIgnore]
        public bool? IsKeepImplementPublic { get; set; }
        [XmlAttribute("keep-implement-public")]
        public bool _IsKeepImplementPublic_ { get { return IsKeepImplementPublic.Value; } set { IsKeepImplementPublic = value; } } public bool ShouldSerialize_IsKeepImplementPublic_() { return IsKeepImplementPublic != null; }

        /// <summary>
        /// DLL name attached to a function
        /// </summary>
        [XmlAttribute("dll")]
        public string FunctionDllName { get; set; }

        /// <summary>
        /// Used to duplicate methods taking pointers and generate an additional private method with pure pointer. This method
        /// is also disabling renaming
        /// </summary>
        /// <value><c>true</c> if [raw PTR]; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool? RawPtr { get; set; }
        [XmlAttribute("rawptr")]
        public bool _RawPtr_ { get { return RawPtr.Value; } set { RawPtr = value; } } public bool ShouldSerialize_RawPtr_() { return RawPtr != null; }

        /// <summary>
        /// Parameter Attribute
        /// </summary>
        [XmlIgnore]
        public ParamAttribute? ParameterAttribute { get; set; }
        [XmlAttribute("attribute")]
        public ParamAttribute _ParameterAttribute_ { get { return ParameterAttribute.Value; } set { ParameterAttribute = value; } } public bool ShouldSerialize_ParameterAttribute_() { return ParameterAttribute != null; }

        /// <summary>
        /// For Method, true means that the return type should be returned in any case. For Parameter is tagged to be used as a return type
        /// </summary>
        [XmlIgnore]
        public bool? ParameterUsedAsReturnType { get; set; }
        [XmlAttribute("return")]
        public bool _ParameterUsedAsReturnType_ { get { return ParameterUsedAsReturnType.Value; } set { ParameterUsedAsReturnType = value; } } public bool ShouldSerialize_ParameterUsedAsReturnType_() { return ParameterUsedAsReturnType != null; }

        /// <summary>
        /// ClassType attached to a function
        /// </summary>
        [XmlAttribute("group")]
        public string Group { get; set; }

        /// <summary>
        /// An integer that can be used to transform the method's vtable offset relative to the value specified by the compiler.
        /// </summary>
        [XmlAttribute("offset-translate")]
        public int LayoutOffsetTranslate { get; set; }

        /// <summary>
        /// Specifies how a marshallable element is related to another marshallable.
        /// </summary>
        [XmlAttribute("relation")]
        public string Relation { get; set; }
    }
}