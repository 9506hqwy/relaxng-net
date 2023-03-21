namespace RelaxNg.Schema;

public class ZeroOrMore : Pattern, IHasChildren
{
    private ZeroOrMore(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static ZeroOrMore Parse(RngElement element, SchemaContext context)
    {
        return new ZeroOrMore(element, context);
    }
}
