﻿using Omi.Fix.Specification;

namespace Omi.Fix.Specification;

/// <summary>
///  Merge intermediate FIX specifications
/// </summary>

public static class Merge
{
    /// <summary>
    /// Combine a list of specifications. Uses field in duplicates set if available to remove duplicates. Uses name in updatedNames if available.
    /// </summary>
    public static Document AllClean(IEnumerable<Document> specifications, HashSet<string> duplicates, Dictionary<string, string> updatedNames)
    {
        var merged = new Document();

        foreach (var specification in specifications)
        {
            merged.AddClean(specification, duplicates, updatedNames);
        }

        return merged;
    }

    /// <summary>
    /// Add a fix specification to a another, making sure to not add duplicates from duplicates HashSet
    /// </summary>
    public static void AddClean(this Document merged, Document specification, HashSet<string> duplicates, Dictionary<string, string> updatedNames)
    { // this can be better
        merged.Components.AddRange(specification.Components.Where(component => !merged.Components.Contains(component)));
        merged.Header.AddRange(specification.Header.Where(header => !merged.Header.Contains(header)));
        merged.Trailer.AddRange(specification.Trailer.Where(trailer => !merged.Trailer.Contains(trailer)));
        merged.Messages.AddRange(specification.Messages.Where(message => !merged.Messages.Select(message => message.Name).Contains(message.Name)));
        merged.Types = Specification.Types.ToTypes(merged.Types.Concat(specification.Types.Where(field => !merged.Types.Contains(field) && !duplicates.Contains(field.Key))), updatedNames);
    }

    /// <summary>
    /// Combine a list of specifications
    /// </summary>
    public static Document All(IEnumerable<Document> specifications)
    {
        var merged = new Document();

        foreach (var specification in specifications)
        {
            merged.Add(specification);
        }

        return merged;
    }

    /// <summary>
    ///  Discrete types list for a list specifications (keep first tag, merge enum values)
    /// </summary>
    public static List<Type> DiscreteTypesByTag(IEnumerable<Document> specifications)
    {
        var types = new Dictionary<uint, Type>();

        foreach (var specification in specifications)
        {
            foreach (var type in specification.Types.Values)
            {
                if (types.TryGetValue(type.Tag, out var existing))
                {
                    if (type.Enums.Count > 0) // make a merge?
                    {
                        existing.Enums.Merge(type.Enums); // this is a bug
                    }
                }
                else
                {
                    types.Add(type.Tag, type.Clone());
                }
            }
        }

        return types.Values.OrderBy(type => type.Tag).ToList();
    }

    /// <summary>
    ///  Message types list
    /// </summary>
    public static List<MessageType> MessageTypesFor(Document specification)
    {
        var messages = new List<MessageType>();

        if (specification.Messages.Any())
        {
            foreach (var message in specification.Messages)
            {
                var info = new MessageType
                {
                    Name = message.Name,
                    Type = message.Type,
                    Category = "Standard",
                };

                messages.Add(info);
            }
        }
        else if (specification.Types.TryGetValue("MsgType", out var type))
        {
            foreach (var value in type.Enums)
            {
                var info = new MessageType
                {
                    Name = value.Name,
                    Type = value.Value,
                    Category = "Standard",
                };

                messages.Add(info);
            }
        }

        return messages.OrderBy(message => message.Name).ToList();
    }

    /// <summary>
    ///  Discrete types list for a list specifications (keep first tag, merge enum values)
    /// </summary>
    public static List<AggregatedType> AggregatedTypes(IEnumerable<Document> specifications)
    {
        var types = new AggregatedTypes();

        foreach (var specification in specifications)
        {
            types.Add(specification.Types);
        }

        return types.Values.OrderBy(type => type.Tag).ToList();
    }
/*
                    if (types.TryGetValue(type.Tag, out var existing))
                {
                    if (type.Enums.Count > 0) // make a merge?
                    {
                        existing.Enums.Merge(type.Enums);
                    }
                }
                else
{
    types.Add(type.Tag, type);
}
*/

/// <summary>
/// Add a fix specification to a another
/// </summary>
public static void Add(this Document merged, Document specification)
    { // this can be better
        merged.Components.AddRange(specification.Components.Where(component => !merged.Components.Contains(component)));
        merged.Header.AddRange(specification.Header.Where(header => !merged.Header.Contains(header)));
        merged.Trailer.AddRange(specification.Trailer.Where(trailer => !merged.Trailer.Contains(trailer)));
        merged.Messages.AddRange(specification.Messages.Where(message => !merged.Messages.Select(message => message.Name).Contains(message.Name)));
        merged.Types = Specification.Types.ToTypes(merged.Types.Concat(specification.Types.Where(type => !merged.Types.Contains(type))));
    }

    /// <summary>
    /// Add a fix specification to a another
    /// </summary>
    public static void NoDuplicates(this Document merged, Document specification)
    { // this can be better
        merged.Components.AddRange(specification.Components.Where(component => !merged.Components.Contains(component)));
        merged.Header.AddRange(specification.Header.Where(header => !merged.Header.Contains(header)));
        merged.Trailer.AddRange(specification.Trailer.Where(trailer => !merged.Trailer.Contains(trailer)));
        merged.Messages.AddRange(specification.Messages.Where(message => !merged.Messages.Select(message => message.Name).Contains(message.Name)));
        merged.Types = Specification.Types.ToTypes(merged.Types.Concat(specification.Types.Where(type => !merged.Types.Contains(type))));
    }


    /// <summary>
    /// Add a fix specification to a another
    /// </summary>
    public static Document Combine(Document merged, Document specification)
    { // this can be better
        merged.Add(specification);

        return merged;
    }
}