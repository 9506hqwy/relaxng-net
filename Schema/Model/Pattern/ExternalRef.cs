namespace RelaxNg.Schema;

public class ExternalRef : Pattern
{
    private ExternalRef(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    public string Href => this.Self.Attribute("href").Value;

    internal static ExternalRef Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new ExternalRef(element, file, context);
    }
}
