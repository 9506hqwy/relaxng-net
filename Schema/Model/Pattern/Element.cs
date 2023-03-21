namespace RelaxNg.Schema;

public class Element : Pattern, IHasChildren, IHasName
{
    private Element(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.GetChildren();

    public INameBase Name => this.GetName();

    public string? Namespace => this.FindNamespace();

    internal static Element Parse(RngElement element, SchemaContext context)
    {
        return new Element(element, context);
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
            var elem = RngElement.Create(attr.Position, Schema.RelaxNgNs, "name", attr.Value, attr.Parent);
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

    private string? FindNamespace(RngElement element)
    {
        var item = element;

        do
        {
            var ns = item.Attribute("ns");
            if (ns is not null)
            {
                return ns.Value;
            }

            item = item.Ancestors(Schema.RelaxNgNs, "element");
        }
        while (item is not null);

        return null;
    }

    private bool TryGetNameAttr(out RngAttribute attr)
    {
        attr = this.Self.Attribute("name");
        return attr is not null;
    }
}
