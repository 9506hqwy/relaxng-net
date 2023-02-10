namespace RelaxNg.Schema;

public class Start : Node
{
    private Start(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.Child);

    public IPattern Child => this.Self.Elements().Select(this.ToPattern).Single();

    public string? Combine => this.Self.Attribute("combine")?.Value;

    internal static Start Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Start(element, file, context);
    }
}
