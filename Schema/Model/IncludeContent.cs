namespace RelaxNg.Schema;

public class IncludeContent : Node
{
    private IncludeContent(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.Inner);

    public INode Inner => this.GetInner();

    internal static IncludeContent Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new IncludeContent(element, file, context);
    }

    private INode GetInner()
    {
        if (this.Self.Name.NamespaceName != Schema.RelaxNgNs)
        {
            return Unknown.Parse(this.Self, this.File, this.Context);
        }

        return this.Self.Name.LocalName switch
        {
            "define" => Define.Parse(this.Self, this.File, this.Context),
            "div" => Div<IncludeContent>.Parse(this.Self, this.File, this.Context, IncludeContent.Parse),
            "start" => Start.Parse(this.Self, this.File, this.Context),
            _ => throw new NotSupportedException($"Not supported element `{this.Self.Name}`"),
        };
    }
}
