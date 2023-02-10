namespace RelaxNg.Schema;

public class Name : NameBase
{
    private Name(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    public string Val => this.Self.Value;

    internal static Name Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Name(element, file, context);
    }
}
