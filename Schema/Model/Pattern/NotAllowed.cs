namespace RelaxNg.Schema;

public class NotAllowed : Pattern
{
    private NotAllowed(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => [];

    internal static NotAllowed Parse(RngElement element, SchemaContext context)
    {
        return new NotAllowed(element, context);
    }
}
