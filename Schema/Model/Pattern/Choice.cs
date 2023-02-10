namespace RelaxNg.Schema;

public class Choice : Pattern, IHasChildren
{
    private Choice(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static Choice Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Choice(element, file, context);
    }
}
