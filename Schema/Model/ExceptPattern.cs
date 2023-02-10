namespace RelaxNg.Schema;

public class ExceptPattern : Node, IHasChildren
{
    private ExceptPattern(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static ExceptPattern Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new ExceptPattern(element, file, context);
    }
}
