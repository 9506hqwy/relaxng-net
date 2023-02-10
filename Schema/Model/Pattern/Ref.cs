namespace RelaxNg.Schema;

public class Ref : Pattern
{
    private Ref(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    public string Name => this.Self.Attribute("name").Value;

    public Define Resolve(RngFile start)
    {
        return start.Resolve(this.Context, this.Name);
    }

    internal static Ref Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Ref(element, file, context);
    }
}
