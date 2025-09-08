namespace RelaxNg.Schema;

public class ExternalRef : Pattern
{
    private ExternalRef(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => [];

    public string Href => this.Self.Attribute("href").Value;

    internal static ExternalRef Parse(RngElement element, SchemaContext context)
    {
        return new ExternalRef(element, context);
    }
}
