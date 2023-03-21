namespace RelaxNg.Schema;

public class Empty : Pattern
{
    private Empty(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    internal static Empty Parse(RngElement element, SchemaContext context)
    {
        return new Empty(element, context);
    }
}
