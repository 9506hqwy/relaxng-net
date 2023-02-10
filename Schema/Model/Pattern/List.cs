namespace RelaxNg.Schema;

public class List : Pattern, IHasChildren
{
    private List(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static List Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new List(element, file, context);
    }
}
