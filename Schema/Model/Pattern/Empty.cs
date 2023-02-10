namespace RelaxNg.Schema;

public class Empty : Pattern
{
    private Empty(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    internal static Empty Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Empty(element, file, context);
    }
}
