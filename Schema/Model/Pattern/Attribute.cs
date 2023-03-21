namespace RelaxNg.Schema;

public class Attribute : Pattern, IHasName
{
    private Attribute(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public IPattern? Child => this.GetChild();

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.Child);

    public INameBase Name => this.GetName();

    internal static Attribute Parse(RngElement element, SchemaContext context)
    {
        return new Attribute(element, context);
    }

    private IPattern? GetChild()
    {
        if (this.TryGetNameAttr(out var attr))
        {
            return this.Self.Elements().Select(this.ToPattern).FirstOrDefault();
        }
        else
        {
            return this.Self.Elements().Skip(1).Select(this.ToPattern).FirstOrDefault();
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

    private bool TryGetNameAttr(out RngAttribute attr)
    {
        attr = this.Self.Attribute("name");
        return attr is not null;
    }
}
