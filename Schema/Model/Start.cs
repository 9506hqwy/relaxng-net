namespace RelaxNg.Schema;

public class Start : Node
{
    private Start(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.Child);

    public IPattern Child => this.Self.Elements().Select(this.ToPattern).Single();

    public string? Combine => this.Self.Attribute("combine")?.Value;

    internal static Start Parse(RngElement element, SchemaContext context)
    {
        return new Start(element, context);
    }
}
