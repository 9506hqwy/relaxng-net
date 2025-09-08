namespace RelaxNg.Schema;

public class Optional : Pattern, IHasChildren
{
    private Optional(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => [.. this.Self.Elements().Select(this.ToPattern)];

    internal static Optional Parse(RngElement element, SchemaContext context)
    {
        return new Optional(element, context);
    }
}
