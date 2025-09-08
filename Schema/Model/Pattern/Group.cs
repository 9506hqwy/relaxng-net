namespace RelaxNg.Schema;

public class Group : Pattern, IHasChildren
{
    private Group(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => [.. this.Self.Elements().Select(this.ToPattern)];

    internal static Group Parse(RngElement element, SchemaContext context)
    {
        return new Group(element, context);
    }
}
