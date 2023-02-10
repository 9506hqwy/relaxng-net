namespace RelaxNg.Schema;

public class NotAllowed : Pattern
{
    private NotAllowed(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    internal static NotAllowed Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new NotAllowed(element, file, context);
    }
}
