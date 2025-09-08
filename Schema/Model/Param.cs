namespace RelaxNg.Schema;

public class Param : Node
{
    internal const string TagName = "param";

    private Param(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => [];

    public string Name => this.Self.Attribute("name").Value;

    public string Val => this.Self.Values.Single();

    internal static Param Parse(RngElement element, SchemaContext context)
    {
        return new Param(element, context);
    }
}
