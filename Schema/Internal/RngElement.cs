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
        RngElement? parent)
    {
        this.Position = position;
        this.NamespaceUri = ns;
        this.Name = name;
        this.attributes = new List<RngAttribute>();
        this.children = new List<RngElement>();
        this.values = new List<string>();
        this.Parent = parent;
    }

    internal RngAttribute[] Attributes => this.attributes.ToArray();

    internal RngElement[] Children => this.children.ToArray();

    internal string Name { get; }

    internal string NamespaceUri { get; }

    internal RngElement? Parent { get; }

    internal RngPosition Position { get; }

    internal string[] Values => this.values.ToArray();

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
            parent);

        var curDepth = reader.Depth;
        var childDepth = curDepth + 1;

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

            if (reader.Depth == curDepth && reader.NodeType == XmlNodeType.EndElement)
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
                    element.children.Add(RngElement.Create(reader, element));
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
        string value,
        RngElement? parent)
    {
        var element = new RngElement(position, ns, name, parent);
        element.values.Add(value);
        return element;
    }

    internal RngElement? Ancestors(string ns, string name)
    {
        if (this.Parent is null)
        {
            return null;
        }

        if (this.Parent.NamespaceUri == ns && this.Parent.Name == name)
        {
            return this.Parent;
        }

        return this.Parent.Ancestors(ns, name);
    }

    internal RngAttribute Attribute(string name)
    {
        return this.Attributes.FirstOrDefault(a => a.Name == name);
    }

    internal IEnumerable<RngElement> Elements() => this.Children;
}
