namespace RelaxNg.Schema;

public class NsName : NameBase
{
    private NsName(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.ExceptName);

    public ExceptName? ExceptName => this.Self.Elements().Select(this.ToExceptName).FirstOrDefault();

    internal static NsName Parse(RngElement element, SchemaContext context)
    {
        return new NsName(element, context);
    }
}
