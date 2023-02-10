namespace RelaxNg.Schema;

public class Element : Pattern, IHasChildren, IHasName
{
    private Element(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.GetChildren();

    public INameBase Name => this.GetName();

    public string? Namespace => this.FindNamespace();

    internal static Element Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Element(element, file, context);
    }

    private IPattern[] GetChildren()
    {
        if (this.TryGetNameAttr(out var attr))
        {
            return this.Self.Elements().Select(this.ToPattern).ToArray();
        }
        else
        {
            return this.Self.Elements().Skip(1).Select(this.ToPattern).ToArray();
        }
    }

    private INameBase GetName()
    {
        if (this.TryGetNameAttr(out var attr))
        {
            var elem = XElement.Parse($"<name xmlns=\"{Schema.RelaxNgNs}\">{attr.Value}</name>");
            return this.ToNameBase(elem);
        }
        else
        {
            return this.ToNameBase(this.Self.Elements().First());
        }
    }

    private string? FindNamespace()
    {
        return this.FindNamespace(this.Self);
    }

    private string? FindNamespace(XElement element)
    {
        var item = element;

        do
        {
            var ns = item.Attribute("ns");
            if (ns is not null)
            {
                return ns.Value;
            }

            item = item.Ancestors(XName.Get("element", Schema.RelaxNgNs)).FirstOrDefault();
        }
        while (item is not null);

        return null;
    }

    private bool TryGetNameAttr(out XAttribute attr)
    {
        attr = this.Self.Attribute("name");
        return attr is not null;
    }
}
