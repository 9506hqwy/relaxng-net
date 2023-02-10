namespace RelaxNg.Schema;

public class Mixed : Pattern, IHasChildren
{
    private Mixed(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static Mixed Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Mixed(element, file, context);
    }
}
