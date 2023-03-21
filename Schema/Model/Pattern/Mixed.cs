namespace RelaxNg.Schema;

public class Mixed : Pattern, IHasChildren
{
    private Mixed(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static Mixed Parse(RngElement element, SchemaContext context)
    {
        return new Mixed(element, context);
    }
}
