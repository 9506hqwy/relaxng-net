namespace RelaxNg.Schema;

public class Optional : Pattern, IHasChildren
{
    private Optional(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static Optional Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Optional(element, file, context);
    }
}
