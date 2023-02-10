namespace RelaxNg.Schema;

public class Value : Pattern
{
    private Value(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    public string? Type => this.Self.Attribute("type")?.Value;

    public string Val => this.Self.Value;

    internal static Value Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Value(element, file, context);
    }
}
