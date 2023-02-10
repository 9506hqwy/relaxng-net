namespace RelaxNg.Schema;

public class ZeroOrMore : Pattern, IHasChildren
{
    private ZeroOrMore(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static ZeroOrMore Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new ZeroOrMore(element, file, context);
    }
}
