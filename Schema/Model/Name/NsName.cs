namespace RelaxNg.Schema;

public class NsName : NameBase
{
    private NsName(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.ExceptName);

    public ExceptName? ExceptName => this.Self.Elements().Select(this.ToExceptName).FirstOrDefault();

    internal static NsName Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new NsName(element, file, context);
    }
}
