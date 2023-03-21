namespace RelaxNg.Schema;

public class ExceptName : Node
{
    private ExceptName(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public INameBase[] Children => this.Self.Elements().Select(this.ToNameBase).ToArray();

    internal static ExceptName Parse(RngElement element, SchemaContext context)
    {
        return new ExceptName(element, context);
    }
}
