namespace Omi.Fix.T7.Xml;

#pragma warning disable CS8618

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Model
{

    private ModelMessageFlow[] messageFlowsField;

    private ModelApplicationMessage[] applicationMessagesField;

    private ModelStructure[] structuresField;

    private ModelDataType[] dataTypesField;

    private string nameField;

    private decimal versionField;

    private string subVersionField;

    private string buildNumberField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("MessageFlow", IsNullable = false)]
    public ModelMessageFlow[] MessageFlows
    {
        get
        {
            return this.messageFlowsField;
        }
        set
        {
            this.messageFlowsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ApplicationMessage", IsNullable = false)]
    public ModelApplicationMessage[] ApplicationMessages
    {
        get
        {
            return this.applicationMessagesField;
        }
        set
        {
            this.applicationMessagesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Structure", IsNullable = false)]
    public ModelStructure[] Structures
    {
        get
        {
            return this.structuresField;
        }
        set
        {
            this.structuresField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("DataType", IsNullable = false)]
    public ModelDataType[] DataTypes
    {
        get
        {
            return this.dataTypesField;
        }
        set
        {
            this.dataTypesField = value;
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
    public decimal version
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
    public string subVersion
    {
        get
        {
            return this.subVersionField;
        }
        set
        {
            this.subVersionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string buildNumber
    {
        get
        {
            return this.buildNumberField;
        }
        set
        {
            this.buildNumberField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlow
{

    private ModelMessageFlowMessage messageField;

    private string nameField;

    private string descriptionField;

    /// <remarks/>
    public ModelMessageFlowMessage Message
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
public partial class ModelMessageFlowMessage
{

    private object[] itemsField;

    private string nameField;

    private string applicationMessageRefField;

    private string descriptionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Message", typeof(ModelMessageFlowMessageMessage))]
    [System.Xml.Serialization.XmlElementAttribute("Node", typeof(ModelMessageFlowMessageNode))]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
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
public partial class ModelMessageFlowMessageMessage
{

    private ModelMessageFlowMessageMessageNode[] nodeField;

    private ModelMessageFlowMessageMessageMessage[] messageField;

    private string nameField;

    private string applicationMessageRefField;

    private string descriptionField;

    private string streamField;

    private string conditionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Node")]
    public ModelMessageFlowMessageMessageNode[] Node
    {
        get
        {
            return this.nodeField;
        }
        set
        {
            this.nodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Message")]
    public ModelMessageFlowMessageMessageMessage[] Message
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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageMessageNode
{

    private ModelMessageFlowMessageMessageNodeMessage[] messageField;

    private string nameField;

    private string descriptionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Message")]
    public ModelMessageFlowMessageMessageNodeMessage[] Message
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
public partial class ModelMessageFlowMessageMessageNodeMessage
{

    private ModelMessageFlowMessageMessageNodeMessageMessage messageField;

    private string nameField;

    private string applicationMessageRefField;

    private string descriptionField;

    private string streamField;

    private string conditionField;

    /// <remarks/>
    public ModelMessageFlowMessageMessageNodeMessageMessage Message
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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageMessageNodeMessageMessage
{

    private string nameField;

    private string applicationMessageRefField;

    private string descriptionField;

    private string streamField;

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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageMessageMessage
{

    private ModelMessageFlowMessageMessageMessageMessage messageField;

    private ModelMessageFlowMessageMessageMessageNode nodeField;

    private string nameField;

    private string applicationMessageRefField;

    private string descriptionField;

    private string streamField;

    private string conditionField;

    /// <remarks/>
    public ModelMessageFlowMessageMessageMessageMessage Message
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
    public ModelMessageFlowMessageMessageMessageNode Node
    {
        get
        {
            return this.nodeField;
        }
        set
        {
            this.nodeField = value;
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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageMessageMessageMessage
{

    private string nameField;

    private string applicationMessageRefField;

    private string descriptionField;

    private string streamField;

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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageMessageMessageNode
{

    private ModelMessageFlowMessageMessageMessageNodeMessage messageField;

    private string nameField;

    private string descriptionField;

    private string conditionField;

    /// <remarks/>
    public ModelMessageFlowMessageMessageMessageNodeMessage Message
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

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageMessageMessageNodeMessage
{

    private ModelMessageFlowMessageMessageMessageNodeMessageMessage messageField;

    private string nameField;

    private string applicationMessageRefField;

    private string conditionField;

    private string descriptionField;

    private string streamField;

    /// <remarks/>
    public ModelMessageFlowMessageMessageMessageNodeMessageMessage Message
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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageMessageMessageNodeMessageMessage
{

    private string nameField;

    private string applicationMessageRefField;

    private string descriptionField;

    private string streamField;

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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageNode
{

    private ModelMessageFlowMessageNodeNode[] nodeField;

    private ModelMessageFlowMessageNodeMessage[] messageField;

    private string nameField;

    private string descriptionField;

    private string conditionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Node")]
    public ModelMessageFlowMessageNodeNode[] Node
    {
        get
        {
            return this.nodeField;
        }
        set
        {
            this.nodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Message")]
    public ModelMessageFlowMessageNodeMessage[] Message
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

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageNodeNode
{

    private ModelMessageFlowMessageNodeNodeMessage[] messageField;

    private string nameField;

    private string conditionField;

    private string descriptionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Message")]
    public ModelMessageFlowMessageNodeNodeMessage[] Message
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
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
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
public partial class ModelMessageFlowMessageNodeNodeMessage
{

    private ModelMessageFlowMessageNodeNodeMessageMessage messageField;

    private string nameField;

    private string applicationMessageRefField;

    private string conditionField;

    private string descriptionField;

    private string streamField;

    /// <remarks/>
    public ModelMessageFlowMessageNodeNodeMessageMessage Message
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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageNodeNodeMessageMessage
{

    private ModelMessageFlowMessageNodeNodeMessageMessageMessage messageField;

    private string nameField;

    private string applicationMessageRefField;

    private string descriptionField;

    private string streamField;

    /// <remarks/>
    public ModelMessageFlowMessageNodeNodeMessageMessageMessage Message
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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageNodeNodeMessageMessageMessage
{

    private string nameField;

    private string applicationMessageRefField;

    private string descriptionField;

    private string streamField;

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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageNodeMessage
{

    private ModelMessageFlowMessageNodeMessageMessage messageField;

    private ModelMessageFlowMessageNodeMessageNode nodeField;

    private string nameField;

    private string applicationMessageRefField;

    private string conditionField;

    private string descriptionField;

    private string streamField;

    /// <remarks/>
    public ModelMessageFlowMessageNodeMessageMessage Message
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
    public ModelMessageFlowMessageNodeMessageNode Node
    {
        get
        {
            return this.nodeField;
        }
        set
        {
            this.nodeField = value;
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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageNodeMessageMessage
{

    private string nameField;

    private string applicationMessageRefField;

    private string descriptionField;

    private string streamField;

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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelMessageFlowMessageNodeMessageNode
{

    private ModelMessageFlowMessageNodeMessageNodeMessage messageField;

    private string nameField;

    private string descriptionField;

    /// <remarks/>
    public ModelMessageFlowMessageNodeMessageNodeMessage Message
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
public partial class ModelMessageFlowMessageNodeMessageNodeMessage
{

    private string nameField;

    private string applicationMessageRefField;

    private string conditionField;

    private string descriptionField;

    private string streamField;

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
    public string applicationMessageRef
    {
        get
        {
            return this.applicationMessageRefField;
        }
        set
        {
            this.applicationMessageRefField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
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
    public string stream
    {
        get
        {
            return this.streamField;
        }
        set
        {
            this.streamField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelApplicationMessage
{

    private object[] itemsField;

    private string nameField;

    private string packageField;

    private string typeField;

    private ushort numericIDField;

    private string descriptionField;

    private string functionalCategoryField;

    private string aliasField;

    private string serviceField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Group", typeof(ModelApplicationMessageGroup))]
    [System.Xml.Serialization.XmlElementAttribute("Member", typeof(ModelApplicationMessageMember))]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
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
    public ushort numericID
    {
        get
        {
            return this.numericIDField;
        }
        set
        {
            this.numericIDField = value;
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
    public string functionalCategory
    {
        get
        {
            return this.functionalCategoryField;
        }
        set
        {
            this.functionalCategoryField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string alias
    {
        get
        {
            return this.aliasField;
        }
        set
        {
            this.aliasField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string service
    {
        get
        {
            return this.serviceField;
        }
        set
        {
            this.serviceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelApplicationMessageGroup
{

    private ModelApplicationMessageGroupMember[] memberField;

    private string nameField;

    private string typeField;

    private string packageField;

    private ushort cardinalityField;

    private string descriptionField;

    private byte minCardinalityField;

    private bool minCardinalityFieldSpecified;

    private string counterField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Member")]
    public ModelApplicationMessageGroupMember[] Member
    {
        get
        {
            return this.memberField;
        }
        set
        {
            this.memberField = value;
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
    public ushort cardinality
    {
        get
        {
            return this.cardinalityField;
        }
        set
        {
            this.cardinalityField = value;
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
    public byte minCardinality
    {
        get
        {
            return this.minCardinalityField;
        }
        set
        {
            this.minCardinalityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool minCardinalitySpecified
    {
        get
        {
            return this.minCardinalityFieldSpecified;
        }
        set
        {
            this.minCardinalityFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string counter
    {
        get
        {
            return this.counterField;
        }
        set
        {
            this.counterField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelApplicationMessageGroupMember
{

    private ModelApplicationMessageGroupMemberValidValue[] validValueField;

    private string nameField;

    private string typeField;

    private string packageField;

    private ushort numericIDField;

    private string usageField;

    private ushort offsetField;

    private byte cardinalityField;

    private string descriptionField;

    private string offsetBaseField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ValidValue")]
    public ModelApplicationMessageGroupMemberValidValue[] ValidValue
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
    public ushort numericID
    {
        get
        {
            return this.numericIDField;
        }
        set
        {
            this.numericIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string usage
    {
        get
        {
            return this.usageField;
        }
        set
        {
            this.usageField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort offset
    {
        get
        {
            return this.offsetField;
        }
        set
        {
            this.offsetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte cardinality
    {
        get
        {
            return this.cardinalityField;
        }
        set
        {
            this.cardinalityField = value;
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
    public string offsetBase
    {
        get
        {
            return this.offsetBaseField;
        }
        set
        {
            this.offsetBaseField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelApplicationMessageGroupMemberValidValue
{

    private string nameField;

    private string valueField;

    private string descriptionField;

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
    public string value
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
public partial class ModelApplicationMessageMember
{

    private ModelApplicationMessageMemberValidValue[] validValueField;

    private string nameField;

    private bool hiddenField;

    private bool hiddenFieldSpecified;

    private string typeField;

    private string packageField;

    private ushort numericIDField;

    private string usageField;

    private ushort offsetField;

    private byte cardinalityField;

    private string descriptionField;

    private string counterField;

    private string offsetBaseField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ValidValue")]
    public ModelApplicationMessageMemberValidValue[] ValidValue
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
    public bool hidden
    {
        get
        {
            return this.hiddenField;
        }
        set
        {
            this.hiddenField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool hiddenSpecified
    {
        get
        {
            return this.hiddenFieldSpecified;
        }
        set
        {
            this.hiddenFieldSpecified = value;
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
    public ushort numericID
    {
        get
        {
            return this.numericIDField;
        }
        set
        {
            this.numericIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string usage
    {
        get
        {
            return this.usageField;
        }
        set
        {
            this.usageField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort offset
    {
        get
        {
            return this.offsetField;
        }
        set
        {
            this.offsetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte cardinality
    {
        get
        {
            return this.cardinalityField;
        }
        set
        {
            this.cardinalityField = value;
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
    public string counter
    {
        get
        {
            return this.counterField;
        }
        set
        {
            this.counterField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string offsetBase
    {
        get
        {
            return this.offsetBaseField;
        }
        set
        {
            this.offsetBaseField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelApplicationMessageMemberValidValue
{

    private string nameField;

    private string valueField;

    private string descriptionField;

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
    public string value
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
public partial class ModelStructure
{

    private ModelStructureMember[] memberField;

    private string nameField;

    private string typeField;

    private ushort numericIDField;

    private bool numericIDFieldSpecified;

    private string packageField;

    private string descriptionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Member")]
    public ModelStructureMember[] Member
    {
        get
        {
            return this.memberField;
        }
        set
        {
            this.memberField = value;
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
    public ushort numericID
    {
        get
        {
            return this.numericIDField;
        }
        set
        {
            this.numericIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool numericIDSpecified
    {
        get
        {
            return this.numericIDFieldSpecified;
        }
        set
        {
            this.numericIDFieldSpecified = value;
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
public partial class ModelStructureMember
{

    private string nameField;

    private string typeField;

    private string packageField;

    private ushort cardinalityField;

    private string descriptionField;

    private byte minCardinalityField;

    private bool minCardinalityFieldSpecified;

    private string counterField;

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
    public ushort cardinality
    {
        get
        {
            return this.cardinalityField;
        }
        set
        {
            this.cardinalityField = value;
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
    public byte minCardinality
    {
        get
        {
            return this.minCardinalityField;
        }
        set
        {
            this.minCardinalityField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool minCardinalitySpecified
    {
        get
        {
            return this.minCardinalityFieldSpecified;
        }
        set
        {
            this.minCardinalityFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string counter
    {
        get
        {
            return this.counterField;
        }
        set
        {
            this.counterField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelDataType
{

    private ModelDataTypeValidValue[] validValueField;

    private string nameField;

    private string typeField;

    private string rootTypeField;

    private string packageField;

    private string descriptionField;

    private string rangeField;

    private string noValueField;

    private ushort sizeField;

    private bool sizeFieldSpecified;

    private decimal minValueField;

    private bool minValueFieldSpecified;

    private decimal maxValueField;

    private bool maxValueFieldSpecified;

    private byte precisionField;

    private bool precisionFieldSpecified;

    private ushort numericIDField;

    private bool numericIDFieldSpecified;

    private bool nonStrictField;

    private bool nonStrictFieldSpecified;

    private bool isTerminableField;

    private bool isTerminableFieldSpecified;

    private bool variableSizeField;

    private bool variableSizeFieldSpecified;

    private string counterField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ValidValue")]
    public ModelDataTypeValidValue[] ValidValue
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
    public string rootType
    {
        get
        {
            return this.rootTypeField;
        }
        set
        {
            this.rootTypeField = value;
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
    public string range
    {
        get
        {
            return this.rangeField;
        }
        set
        {
            this.rangeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string noValue
    {
        get
        {
            return this.noValueField;
        }
        set
        {
            this.noValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort size
    {
        get
        {
            return this.sizeField;
        }
        set
        {
            this.sizeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool sizeSpecified
    {
        get
        {
            return this.sizeFieldSpecified;
        }
        set
        {
            this.sizeFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal minValue
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
    public decimal maxValue
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
    public byte precision
    {
        get
        {
            return this.precisionField;
        }
        set
        {
            this.precisionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool precisionSpecified
    {
        get
        {
            return this.precisionFieldSpecified;
        }
        set
        {
            this.precisionFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort numericID
    {
        get
        {
            return this.numericIDField;
        }
        set
        {
            this.numericIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool numericIDSpecified
    {
        get
        {
            return this.numericIDFieldSpecified;
        }
        set
        {
            this.numericIDFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool nonStrict
    {
        get
        {
            return this.nonStrictField;
        }
        set
        {
            this.nonStrictField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool nonStrictSpecified
    {
        get
        {
            return this.nonStrictFieldSpecified;
        }
        set
        {
            this.nonStrictFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool isTerminable
    {
        get
        {
            return this.isTerminableField;
        }
        set
        {
            this.isTerminableField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool isTerminableSpecified
    {
        get
        {
            return this.isTerminableFieldSpecified;
        }
        set
        {
            this.isTerminableFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool variableSize
    {
        get
        {
            return this.variableSizeField;
        }
        set
        {
            this.variableSizeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool variableSizeSpecified
    {
        get
        {
            return this.variableSizeFieldSpecified;
        }
        set
        {
            this.variableSizeFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string counter
    {
        get
        {
            return this.counterField;
        }
        set
        {
            this.counterField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ModelDataTypeValidValue
{

    private string nameField;

    private string valueField;

    private string descriptionField;

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
    public string value
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


