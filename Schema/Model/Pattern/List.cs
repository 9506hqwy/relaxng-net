namespace RelaxNg.Schema;

public class List : Pattern, IHasChildren
{
    private List(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => [.. this.Self.Elements().Select(this.ToPattern)];

    internal static List Parse(RngElement element, SchemaContext context)
    {
        return new List(element, context);
    }
}
