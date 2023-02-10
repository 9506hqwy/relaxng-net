namespace RelaxNg.Schema;

public class OneOrMore : Pattern, IHasChildren
{
    private OneOrMore(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static OneOrMore Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new OneOrMore(element, file, context);
    }
}
