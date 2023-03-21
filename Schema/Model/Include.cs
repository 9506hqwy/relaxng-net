namespace RelaxNg.Schema;

public class Include : Node
{
    private Include(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Includes;

    public string Href => this.Self.Attribute("href").Value;

    public IncludeContent[] Includes => this.Self.Elements().Select(this.ToIncludeContent).ToArray();

    internal static Include Parse(RngElement element, SchemaContext context)
    {
        return new Include(element, context);
    }
}
