namespace RelaxNg.Schema;

public class Define : Node, IHasChildren
{
    private Define(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => [.. this.Self.Elements().Select(this.ToPattern)];

    public string? Combine => this.Self.Attribute("combine")?.Value;

    public string Name => this.Self.Attribute("name").Value;

    internal static Define Parse(RngElement element, SchemaContext context)
    {
        return new Define(element, context);
    }
}
