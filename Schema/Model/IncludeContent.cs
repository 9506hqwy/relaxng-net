namespace RelaxNg.Schema;

public class IncludeContent : Node
{
    private IncludeContent(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.Inner);

    public INode Inner => this.GetInner();

    internal static IncludeContent Parse(RngElement element, SchemaContext context)
    {
        return new IncludeContent(element, context);
    }

    private INode GetInner()
    {
        return this.Self.NamespaceUri != Schema.RelaxNgNs
            ? Unknown.Parse(this.Self, this.Context)
            : this.Self.Name switch
            {
                "define" => Define.Parse(this.Self, this.Context),
                "div" => Div<IncludeContent>.Parse(this.Self, this.Context, IncludeContent.Parse),
                "start" => Start.Parse(this.Self, this.Context),
                _ => throw new NotSupportedException($"Not supported element `{this.Self.Name}`"),
            };
    }
}
