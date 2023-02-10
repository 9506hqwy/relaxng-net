namespace RelaxNg.Schema;

public class ChoiceName : NameBase
{
    private ChoiceName(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public INameBase[] Children => this.Self.Elements().Select(this.ToNameBase).ToArray();

    internal static ChoiceName Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new ChoiceName(element, file, context);
    }
}
