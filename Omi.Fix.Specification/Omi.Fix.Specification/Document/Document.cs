﻿namespace Omi.Fix.Specification;

/// <summary>
///  Normalized Fix Specification Document
/// </summary>

public class Document
{
    #region Properties
    ///////////////////////////////////////////////////////

    /// <summary>
    ///  Normalized Fix Specification Information
    /// </summary>
    public Information Information = new();

    /// <summary>
    ///  Normalized Fix Specification Headers
    /// </summary>
    public Header Header = new();

    /// <summary>
    ///  Normalized Fix Specification Trailers
    /// </summary>
    public Trailer Trailer = new();

    /// <summary>
    ///  Normalized Fix Specification Messages
    /// </summary>
    public Messages Messages = new();

    /// <summary>
    ///  Normalized Fix Specification Components
    /// </summary>
    public Components Components = new();

    /// <summary>
    ///  Normalized Fix intermediate specification field types
    /// </summary>
    public Types Types = new();

    #endregion

    #region Operations
    ///////////////////////////////////////////////////////

    /// <summary>
    ///  Filter messages 
    /// </summary>
    public void Filter(Predicate<Message> predicate)
        => Messages.RemoveAll(predicate);

    /// <summary>
    ///  Filter types
    /// </summary>
    public void Filter(Predicate<Type> predicate)
        => Types.RemoveAll(predicate);

    /// <summary>
    ///  Normalize/clean Fix Specification
    /// </summary>
    public void Normalize()
        => Clean.Document(this);

    /// <summary>
    ///  Add Overwrite Type (minimal)
    /// </summary>
    public void Set(Type type)
        => Types[type.Name] = type;

    /// <summary>
    ///  Add Overwrite Type (minimal)
    /// </summary>
    public void Set(string name, uint tag, string  type)
        => Set(new Type { Name = name, Tag = tag, DataType = Convert.TypeFor(type) });

    /// <summary>
    ///  Add Overwrite Type (minimal)
    /// </summary>
    public void Set(string name, uint tag, DataType type = DataType.String)
        => Set(new Type { Name = name, Tag = tag, DataType = type});

    /// <summary>
    ///  Add Overwrite Type (minimal)
    /// </summary>
    public void Set(string name, string type)
    {
        if (Types.TryGetValue(name, out var field))
        { 
            // TODO: this is not likely correct

            field.DataType = Convert.TypeFor(type);
        }
    }

    /// <summary>
    ///  Add enumerated value to type
    /// </summary>
    public void Set(string field, string value, string name)
    {
        // add ability to order these
        if (Types.TryGetValue(field, out var type))
        {
            var @enum = type.Enums.Find(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (@enum != null)
            {
                @enum.Name = name;
                @enum.Value = value;
            }
            else
            {
                type.Enums.Add(new Enum { Name = name, Value = value });
            }
        }
    }

    /// <summary>
    ///  Set a field to not required in all of specification
    /// </summary>
    public void SetNotRequired(string name)
    {
        // add some checks?
        foreach (var message in Messages)
        {
            message.SetNotRequired(name);
        }
    }

    /// <summary>
    ///  Add field to message (need one with placement)
    /// </summary>
    public void AddField(string message, string name, bool required)
    {
        // add some checks?


    }

    /// <summary>
    ///  Add field to message (need one with placement)
    /// </summary>
    public void RemoveEnumValues(string name)
        => Types.RemoveEnumValues(name);

    /// <summary>
    ///  Try Get Message
    /// </summary>
    public bool TryGetMessage(string name, out Message message)
        => Messages.TryGetByName(name, out message);

    /// <summary>
    ///  Get message by name
    /// </summary>
    public Message GetMessage(string name)
        => Messages.First(current => current.Name == name);

    /// <summary>
    ///  Add/Overwrite Types
    /// </summary>
    public void Set(Types types)
        => Types.AddOverwrite(types);

    /// <summary>
    ///  Try get type by name
    /// </summary>
    public bool TryGet(string name, out Type type)
        => Types.TryGetByName(name, out type);

    /// <summary>
    ///  Display Normalized Fix Specification
    /// </summary>
    public override string ToString()
        => $"{Information}, Messages = {Messages.Count}";

    #endregion
}
