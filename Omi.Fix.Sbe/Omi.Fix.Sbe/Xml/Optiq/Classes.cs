namespace Omi.Fix.Sbe.Optiq;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fixprotocol.io/2016/sbe")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://fixprotocol.io/2016/sbe", IsNullable = false)]
public partial class messageSchema
{

    private types typesField;

    private messageSchemaMessage[] messageField;

    private string packageField;

    private byte idField;

    private ushort versionField;

    private string semanticVersionField;

    private string descriptionField;

    private string byteOrderField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
    public types types
    {
        get
        {
            return this.typesField;
        }
        set
        {
            this.typesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("message")]
    public messageSchemaMessage[] message
    {
        get
        {
            return this.messageField;
        }
        set
        {
            this.messageField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string package
    {
        get
        {
            return this.packageField;
        }
        set
        {
            this.packageField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort version
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string semanticVersion
    {
        get
        {
            return this.semanticVersionField;
        }
        set
        {
            this.semanticVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string description
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string byteOrder
    {
        get
        {
            return this.byteOrderField;
        }
        set
        {
            this.byteOrderField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class types
{

    private typesType[] typeField;

    private typesComposite[] compositeField;

    private typesEnum[] enumField;

    private typesSet[] setField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("type")]
    public typesType[] type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("composite")]
    public typesComposite[] composite
    {
        get
        {
            return this.compositeField;
        }
        set
        {
            this.compositeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("enum")]
    public typesEnum[] @enum
    {
        get
        {
            return this.enumField;
        }
        set
        {
            this.enumField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("set")]
    public typesSet[] set
    {
        get
        {
            return this.setField;
        }
        set
        {
            this.setField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesType
{

    private string nameField;

    private string primitiveTypeField;

    private string nullValueField;

    private string presenceField;

    private long minValueField;

    private bool minValueFieldSpecified;

    private ulong maxValueField;

    private bool maxValueFieldSpecified;

    private byte lengthField;

    private bool lengthFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string primitiveType
    {
        get
        {
            return this.primitiveTypeField;
        }
        set
        {
            this.primitiveTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string nullValue
    {
        get
        {
            return this.nullValueField;
        }
        set
        {
            this.nullValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string presence
    {
        get
        {
            return this.presenceField;
        }
        set
        {
            this.presenceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public long minValue
    {
        get
        {
            return this.minValueField;
        }
        set
        {
            this.minValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool minValueSpecified
    {
        get
        {
            return this.minValueFieldSpecified;
        }
        set
        {
            this.minValueFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ulong maxValue
    {
        get
        {
            return this.maxValueField;
        }
        set
        {
            this.maxValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maxValueSpecified
    {
        get
        {
            return this.maxValueFieldSpecified;
        }
        set
        {
            this.maxValueFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte length
    {
        get
        {
            return this.lengthField;
        }
        set
        {
            this.lengthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool lengthSpecified
    {
        get
        {
            return this.lengthFieldSpecified;
        }
        set
        {
            this.lengthFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesComposite
{

    private typesCompositeType[] typeField;

    private string nameField;

    private string descriptionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("type")]
    public typesCompositeType[] type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string description
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
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesCompositeType
{

    private string nameField;

    private string primitiveTypeField;

    private string semanticTypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string primitiveType
    {
        get
        {
            return this.primitiveTypeField;
        }
        set
        {
            this.primitiveTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string semanticType
    {
        get
        {
            return this.semanticTypeField;
        }
        set
        {
            this.semanticTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesEnum
{

    private typesEnumValidValue[] validValueField;

    private string nameField;

    private string encodingTypeField;

    private byte deprecatedField;

    private bool deprecatedFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("validValue")]
    public typesEnumValidValue[] validValue
    {
        get
        {
            return this.validValueField;
        }
        set
        {
            this.validValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string encodingType
    {
        get
        {
            return this.encodingTypeField;
        }
        set
        {
            this.encodingTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte deprecated
    {
        get
        {
            return this.deprecatedField;
        }
        set
        {
            this.deprecatedField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool deprecatedSpecified
    {
        get
        {
            return this.deprecatedFieldSpecified;
        }
        set
        {
            this.deprecatedFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesEnumValidValue
{

    private string nameField;

    private ushort sinceVersionField;

    private bool sinceVersionFieldSpecified;

    private ushort deprecatedField;

    private bool deprecatedFieldSpecified;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort sinceVersion
    {
        get
        {
            return this.sinceVersionField;
        }
        set
        {
            this.sinceVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool sinceVersionSpecified
    {
        get
        {
            return this.sinceVersionFieldSpecified;
        }
        set
        {
            this.sinceVersionFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort deprecated
    {
        get
        {
            return this.deprecatedField;
        }
        set
        {
            this.deprecatedField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool deprecatedSpecified
    {
        get
        {
            return this.deprecatedFieldSpecified;
        }
        set
        {
            this.deprecatedFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
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

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesSet
{

    private typesSetChoice[] choiceField;

    private string nameField;

    private string encodingTypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("choice")]
    public typesSetChoice[] choice
    {
        get
        {
            return this.choiceField;
        }
        set
        {
            this.choiceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string encodingType
    {
        get
        {
            return this.encodingTypeField;
        }
        set
        {
            this.encodingTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class typesSetChoice
{

    private string nameField;

    private ushort sinceVersionField;

    private bool sinceVersionFieldSpecified;

    private byte deprecatedField;

    private bool deprecatedFieldSpecified;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort sinceVersion
    {
        get
        {
            return this.sinceVersionField;
        }
        set
        {
            this.sinceVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool sinceVersionSpecified
    {
        get
        {
            return this.sinceVersionFieldSpecified;
        }
        set
        {
            this.sinceVersionFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte deprecated
    {
        get
        {
            return this.deprecatedField;
        }
        set
        {
            this.deprecatedField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool deprecatedSpecified
    {
        get
        {
            return this.deprecatedFieldSpecified;
        }
        set
        {
            this.deprecatedFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value
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

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fixprotocol.io/2016/sbe")]
public partial class messageSchemaMessage
{

    private field[] fieldField;

    private group[] groupField;

    private string nameField;

    private byte idField;

    private ushort sinceVersionField;

    private bool sinceVersionFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("field", Namespace = "")]
    public field[] field
    {
        get
        {
            return this.fieldField;
        }
        set
        {
            this.fieldField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("group", Namespace = "")]
    public group[] group
    {
        get
        {
            return this.groupField;
        }
        set
        {
            this.groupField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort sinceVersion
    {
        get
        {
            return this.sinceVersionField;
        }
        set
        {
            this.sinceVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool sinceVersionSpecified
    {
        get
        {
            return this.sinceVersionFieldSpecified;
        }
        set
        {
            this.sinceVersionFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class field
{

    private byte idField;

    private string nameField;

    private string typeField;

    private string presenceField;

    private ushort sinceVersionField;

    private bool sinceVersionFieldSpecified;

    private byte deprecatedField;

    private bool deprecatedFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string presence
    {
        get
        {
            return this.presenceField;
        }
        set
        {
            this.presenceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort sinceVersion
    {
        get
        {
            return this.sinceVersionField;
        }
        set
        {
            this.sinceVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool sinceVersionSpecified
    {
        get
        {
            return this.sinceVersionFieldSpecified;
        }
        set
        {
            this.sinceVersionFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte deprecated
    {
        get
        {
            return this.deprecatedField;
        }
        set
        {
            this.deprecatedField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool deprecatedSpecified
    {
        get
        {
            return this.deprecatedFieldSpecified;
        }
        set
        {
            this.deprecatedFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class group
{

    private groupField[] fieldField;

    private byte idField;

    private string dimensionTypeField;

    private string nameField;

    private byte sinceVersionField;

    private bool sinceVersionFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("field")]
    public groupField[] field
    {
        get
        {
            return this.fieldField;
        }
        set
        {
            this.fieldField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string dimensionType
    {
        get
        {
            return this.dimensionTypeField;
        }
        set
        {
            this.dimensionTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte sinceVersion
    {
        get
        {
            return this.sinceVersionField;
        }
        set
        {
            this.sinceVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool sinceVersionSpecified
    {
        get
        {
            return this.sinceVersionFieldSpecified;
        }
        set
        {
            this.sinceVersionFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class groupField
{

    private byte idField;

    private string nameField;

    private string presenceField;

    private string typeField;

    private ushort sinceVersionField;

    private bool sinceVersionFieldSpecified;

    private byte deprecatedField;

    private bool deprecatedFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string presence
    {
        get
        {
            return this.presenceField;
        }
        set
        {
            this.presenceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort sinceVersion
    {
        get
        {
            return this.sinceVersionField;
        }
        set
        {
            this.sinceVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool sinceVersionSpecified
    {
        get
        {
            return this.sinceVersionFieldSpecified;
        }
        set
        {
            this.sinceVersionFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte deprecated
    {
        get
        {
            return this.deprecatedField;
        }
        set
        {
            this.deprecatedField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool deprecatedSpecified
    {
        get
        {
            return this.deprecatedFieldSpecified;
        }
        set
        {
            this.deprecatedFieldSpecified = value;
        }
    }
}

