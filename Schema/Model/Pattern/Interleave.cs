namespace RelaxNg.Schema;

public class Interleave : Pattern, IHasChildren
{
    private Interleave(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static Interleave Parse(RngElement element, SchemaContext context)
    {
        return new Interleave(element, context);
    }
}
