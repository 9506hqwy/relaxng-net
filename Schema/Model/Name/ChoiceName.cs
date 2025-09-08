namespace RelaxNg.Schema;

public class ChoiceName : NameBase
{
    private ChoiceName(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public INameBase[] Children => [.. this.Self.Elements().Select(this.ToNameBase)];

    internal static ChoiceName Parse(RngElement element, SchemaContext context)
    {
        return new ChoiceName(element, context);
    }
}
