namespace RelaxNg.Schema;

public class Interleave : Pattern, IHasChildren
{
    private Interleave(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public IPattern[] Children => this.Self.Elements().Select(this.ToPattern).ToArray();

    internal static Interleave Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Interleave(element, file, context);
    }
}
