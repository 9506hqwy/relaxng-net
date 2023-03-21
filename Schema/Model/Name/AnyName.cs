namespace RelaxNg.Schema;

public class AnyName : NameBase
{
    private AnyName(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.ExceptName);

    public ExceptName? ExceptName => this.Self.Elements().Select(this.ToExceptName).FirstOrDefault();

    internal static AnyName Parse(RngElement element, SchemaContext context)
    {
        return new AnyName(element, context);
    }
}
