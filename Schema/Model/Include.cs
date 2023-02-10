namespace RelaxNg.Schema;

public class Include : Node
{
    private Include(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Includes;

    public string Href => this.Self.Attribute("href").Value;

    public IncludeContent[] Includes => this.Self.Elements().Select(this.ToIncludeContent).ToArray();

    internal static Include Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Include(element, file, context);
    }
}
