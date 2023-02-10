namespace RelaxNg.Schema;

public class Text : Pattern
{
    private Text(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    internal static Text Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Text(element, file, context);
    }
}
