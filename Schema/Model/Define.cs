namespace RelaxNg.Schema;

public class Define : Node, IHasChildren
{
    private Define(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    public string? Combine => this.Self.Attribute("combine")?.Value;

    public string Name => this.Self.Attribute("name").Value;

    internal static Define Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Define(element, file, context);
    }
}
