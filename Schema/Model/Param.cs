namespace RelaxNg.Schema;

public class Param : Node
{
    internal const string TagName = "param";

    private Param(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => Array.Empty<Node>();

    public string Name => this.Self.Attribute("name").Value;

    public string Val => this.Self.Value;

    internal static Param Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Param(element, file, context);
    }
}
