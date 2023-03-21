namespace RelaxNg.Schema;

public class Choice : Pattern, IHasChildren
{
    private Choice(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static Choice Parse(RngElement element, SchemaContext context)
    {
        return new Choice(element, context);
    }
}
