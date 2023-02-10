namespace RelaxNg.Schema;

public class Unknown : Node, INameBase, IPattern
{
    private Unknown(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    internal static Unknown Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Unknown(element, file, context);
    }
}
