namespace RelaxNg.Schema;

public class Unknown : Node, INameBase, IPattern
{
    private Unknown(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    internal static Unknown Parse(RngElement element, SchemaContext context)
    {
        return new Unknown(element, context);
    }
}
