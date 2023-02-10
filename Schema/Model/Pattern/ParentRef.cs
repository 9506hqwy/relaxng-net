namespace RelaxNg.Schema;

public class ParentRef : Pattern
{
    private ParentRef(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    public string Name => this.Self.Attribute("name").Value;

    internal static ParentRef Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new ParentRef(element, file, context);
    }
}
