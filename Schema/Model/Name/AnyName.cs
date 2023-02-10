namespace RelaxNg.Schema;

public class AnyName : NameBase
{
    private AnyName(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.ExceptName);

    public ExceptName? ExceptName => this.Self.Elements().Select(this.ToExceptName).FirstOrDefault();

    internal static AnyName Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new AnyName(element, file, context);
    }
}
