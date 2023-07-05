namespace Omi.Fix.Types.Xml {

    #pragma warning disable CS8618

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class FixFields
    {

        private FixFieldsFixFieldSpec[] fixFieldSpecField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FixFieldSpec")]
        public FixFieldsFixFieldSpec[] FixFieldSpec
        {
            get
            {
                return this.fixFieldSpecField;
            }
            set
            {
                this.fixFieldSpecField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FixFieldsFixFieldSpec
    {

        private ushort tagField;

        private string nameField;

        private string dataTypeField;

        private string descriptionField;

        private string versionField;

        private bool isRequiredField;

        private bool isEnumTypeField;

        private FixFieldsFixFieldSpecFixEnumField[] enumPairsField;

        /// <remarks/>
        public ushort Tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string DataType
        {
            get
            {
                return this.dataTypeField;
            }
            set
            {
                this.dataTypeField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        public bool IsRequired
        {
            get
            {
                return this.isRequiredField;
            }
            set
            {
                this.isRequiredField = value;
            }
        }

        /// <remarks/>
        public bool IsEnumType
        {
            get
            {
                return this.isEnumTypeField;
            }
            set
            {
                this.isEnumTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("FixEnumField", IsNullable = false)]
        public FixFieldsFixFieldSpecFixEnumField[] EnumPairs
        {
            get
            {
                return this.enumPairsField;
            }
            set
            {
                this.enumPairsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FixFieldsFixFieldSpecFixEnumField
    {

        private string keyField;

        private string valueField;

        /// <remarks/>
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}

