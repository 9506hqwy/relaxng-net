namespace RelaxNg.Schema;

public class Group : Pattern, IHasChildren
{
    private Group(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static Group Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Group(element, file, context);
    }
}
