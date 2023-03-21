namespace RelaxNg.Schema;

public class ParentRef : Pattern
{
    private ParentRef(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    public string Name => this.Self.Attribute("name").Value;

    internal static ParentRef Parse(RngElement element, SchemaContext context)
    {
        return new ParentRef(element, context);
    }
}
