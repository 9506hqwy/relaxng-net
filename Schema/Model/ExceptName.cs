namespace RelaxNg.Schema;

public class ExceptName : Node
{
    private ExceptName(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public INameBase[] Children => this.Self.Elements().Select(this.ToNameBase).ToArray();

    internal static ExceptName Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new ExceptName(element, file, context);
    }
}
