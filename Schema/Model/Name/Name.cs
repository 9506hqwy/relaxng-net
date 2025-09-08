namespace RelaxNg.Schema;

public class Name : NameBase
{
    private Name(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => [];

    public string Val => this.Self.Values.Single();

    internal static Name Parse(RngElement element, SchemaContext context)
    {
        return new Name(element, context);
    }
}
