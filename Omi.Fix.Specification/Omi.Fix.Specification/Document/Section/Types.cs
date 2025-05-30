﻿namespace Omi.Fix.Specification;

using System.Collections.Generic;

/// <summary>
///  Normalized Fix Specification Field Types List
/// </summary>

public class Types : Dictionary<string, Type>
{
    /// <summary>
    ///  Default Constructor
    /// </summary>
    public Types()
    { }

    /// <summary>
    ///  Initialize from IEnumerable types 
    /// </summary>
    public Types(IEnumerable<Type> types)
    {
        foreach (var type in types)
        {
            Add(type.Name, type);
        }
    }

    /// <summary>
    ///  Add type
    /// </summary>
    public void Add(Type type)
    {
        // how to handle enums?

        this[type.Name] = type;
    }

    /// <summary>
    ///  Add Types, overwrite in case of same name
    /// </summary>
    public void AddOverwrite(Types types)
    {
        foreach (var type in types.Values)
        {
            Add(type);
        }
    }

    /// <summary>
    ///  Try get type by name
    /// </summary>
    public bool TryGetByName(string name, out Type type)
        => TryGetValue(name, out type);

    /// <summary>
    ///  Convert Dictionary of types to Specification
    /// </summary>
    public static Types ToTypes(Dictionary<string, Type> type)
    {
        var types = new Types();

        foreach (var pair in type)
        {
            types.Add(pair.Key, pair.Value);
        }

        return types;
    }

    /// <summary>
    ///  Remove Enums
    /// </summary>
    public void RemoveEnumValues(string name)
    {
        if (TryGetValue(name, out var type))
        {
            type.Enums = new Enums();
        }
    }

    /// <summary>
    ///  Remove all types that meet a predicate
    /// </summary>
    public void RemoveAll(Predicate<Type> match)
    {
        foreach (var pair in this)
        {
            if (!match(pair.Value))
            {
                Remove(pair.Key);
            }
        }
    }

    /// <summary>
    ///  Convert types to fields list
    /// </summary>
    public List<Field> ToFields()
    {
        var fields = new List<Field>();

        foreach (var type in Values)
        {
            fields.Add(type.ToField());
        }

        return fields;
    }

    /// <summary>
    ///  Convert types to fields list with predicate
    /// </summary>
    public List<Field> ToFields(Predicate<Type> match)
    {
        var fields = new List<Field>();

        foreach (var type in Values)
        {
            if (match(type))
            {
                fields.Add(type.ToField());
            }
        }

        return fields;
    }



    /// <summary>
    ///  Convert Dictionary of types to Specification Types
    /// </summary>
    public static Types ToTypes(IEnumerable<KeyValuePair<string, Type>> type)
    {
        var types = new Types();

        foreach (var pair in type)
        {
            if (types.ContainsKey(pair.Key))
            {
                continue;
            }

            types.Add(pair.Key, pair.Value);
        }

        return types;
    }

    /// <summary>
    ///  Convert Dictionary of types to Specification Types, using the updated name in updatedName if available
    /// </summary>
    public static Types ToTypes(IEnumerable<KeyValuePair<string, Type>> type, Dictionary<string, string> updatedNames)
    {
        var types = new Types();

        foreach (var pair in type)
        {
            if (types.ContainsKey(pair.Key))
            {
                continue;
            }
            if (updatedNames.ContainsKey(pair.Key))
            {
                types.Add(updatedNames[pair.Key], pair.Value);
            }
            else
            {
                types.Add(pair.Key, pair.Value);
            }
        }

        return types;
    }

    /// <summary>
    ///  Return types as ordered list
    /// </summary>
    public List<Type> ToList()
        => Values.OrderBy(field => field.Tag).ToList();
}