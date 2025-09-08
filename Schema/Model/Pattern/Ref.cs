namespace RelaxNg.Schema;

public class Ref : Pattern
{
    private Ref(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => [];

    public string Name => this.Self.Attribute("name").Value;

    public Define Resolve(RngFile start)
    {
        return start.Resolve(this.Context, this.Name);
    }

    internal static Ref Parse(RngElement element, SchemaContext context)
    {
        return new Ref(element, context);
    }
}
