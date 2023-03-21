namespace RelaxNg.Schema;

public class Text : Pattern
{
    private Text(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    internal static Text Parse(RngElement element, SchemaContext context)
    {
        return new Text(element, context);
    }
}
