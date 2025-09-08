namespace RelaxNg.Schema;

public class ExceptPattern : Node, IHasChildren
{
    private ExceptPattern(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => [.. this.Self.Elements().Select(this.ToPattern)];

    internal static ExceptPattern Parse(RngElement element, SchemaContext context)
    {
        return new ExceptPattern(element, context);
    }
}
