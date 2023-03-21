namespace RelaxNg.Schema;

public class Value : Pattern
{
    private Value(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    public string? Type => this.Self.Attribute("type")?.Value;

    public string Val => this.Self.Values.Single();

    internal static Value Parse(RngElement element, SchemaContext context)
    {
        return new Value(element, context);
    }
}
