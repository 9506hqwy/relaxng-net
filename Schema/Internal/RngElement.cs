namespace RelaxNg.Schema;

internal class RngElement
{
    private readonly List<RngAttribute> attributes;

    private readonly List<RngElement> children;

    private readonly List<string> values;

    private RngElement(
        RngPosition position,
        string ns,
        string name,
        int depth,
        RngElement? parent)
    {
        this.Position = position;
        this.NamespaceUri = ns;
        this.Name = name;
        this.Depth = depth;
        this.attributes = [];
        this.children = [];
        this.values = [];
        this.Parent = parent;
    }

    internal RngAttribute[] Attributes => [.. this.attributes];

    internal RngElement[] Children => [.. this.children];

    internal int Depth { get; }

    internal string Name { get; }

    internal string NamespaceUri { get; }

    internal RngElement? Parent { get; }

    internal RngPosition Position { get; }

    internal string[] Values => [.. this.values];

    public override string ToString()
    {
        return string.IsNullOrWhiteSpace(this.NamespaceUri) ?
            $"<{this.Name}>" :
            $"<{{{this.NamespaceUri}}}{this.Name}>";
    }

    internal static RngElement Create(RngReader reader, RngElement? parent)
    {
        var position = RngPosition.Create(reader);

        var element = new RngElement(
            position,
            reader.NamespaceURI,
            reader.Name,
            reader.Depth,
            parent);

        var childDepth = element.Depth + 1;

        if (reader.HasAttributes)
        {
            for (var i = 0; i < reader.AttributeCount; i++)
            {
                reader.MoveToAttribute(i);
                element.attributes.Add(RngAttribute.Create(reader, element));
            }
        }

        var skipRead = false;
        while (!reader.EOF && (skipRead || reader.ThrowIfNextNode()))
        {
            skipRead = false;

            if (reader.Depth == element.Depth && reader.NodeType == XmlNodeType.EndElement)
            {
                break;
            }
            else if (reader.Depth != childDepth)
            {
                break;
            }

            switch (reader.NodeType)
            {
                case XmlNodeType.Attribute:
                    throw new InvalidProgramException();

                case XmlNodeType.CDATA:
                    break;

                case XmlNodeType.Comment:
                    break;

                case XmlNodeType.Document:
                    throw new InvalidProgramException();

                case XmlNodeType.DocumentFragment:
                    throw new InvalidProgramException();

                case XmlNodeType.DocumentType:
                    throw new InvalidProgramException();

                case XmlNodeType.Element:
                    element.children.Add(Create(reader, element));
                    skipRead = true;
                    break;

                case XmlNodeType.EndElement:
                    break;

                case XmlNodeType.EndEntity:
                    break;

                case XmlNodeType.Entity:
                    break;

                case XmlNodeType.EntityReference:
                    break;

                case XmlNodeType.None:
                    throw new InvalidProgramException();

                case XmlNodeType.Notation:
                    break;

                case XmlNodeType.ProcessingInstruction:
                    break;

                case XmlNodeType.SignificantWhitespace:
                    break;

                case XmlNodeType.Text:
                    element.values.Add(reader.Value);
                    break;

                case XmlNodeType.Whitespace:
                    throw new InvalidProgramException();

                case XmlNodeType.XmlDeclaration:
                    throw new InvalidProgramException();

                default:
                    throw new InvalidProgramException();
            }
        }

        return element;
    }

    internal static RngElement Create(
        RngPosition position,
        string ns,
        string name,
        int depth,
        string value,
        RngElement? parent)
    {
        var element = new RngElement(position, ns, name, depth, parent);
        element.values.Add(value);
        return element;
    }

    internal RngElement? Ancestors(string ns, string name)
    {
        return this.Parent is null
            ? null
            : this.Parent.NamespaceUri == ns && this.Parent.Name == name ? this.Parent : this.Parent.Ancestors(ns, name);
    }

    internal RngAttribute Attribute(string name)
    {
        return this.Attributes.FirstOrDefault(a => a.Name == name);
    }

    internal IEnumerable<RngElement> Elements() => this.Children;
}
