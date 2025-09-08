namespace RelaxNg.Schema;

public class OneOrMore : Pattern, IHasChildren
{
    private OneOrMore(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => [.. this.Self.Elements().Select(this.ToPattern)];

    internal static OneOrMore Parse(RngElement element, SchemaContext context)
    {
        return new OneOrMore(element, context);
    }
}
