namespace RelaxNg.Schema;

public class GrammarContent : Node
{
    private GrammarContent(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.Inner);

    public INode Inner => this.GetInner();

    internal static GrammarContent Parse(RngElement element, SchemaContext context)
    {
        return new GrammarContent(element, context);
    }

    private INode GetInner()
    {
        if (this.Self.NamespaceUri != Schema.RelaxNgNs)
        {
            return Unknown.Parse(this.Self, this.Context);
        }

        return this.Self.Name switch
        {
            "define" => Define.Parse(this.Self, this.Context),
            "div" => Div<GrammarContent>.Parse(this.Self, this.Context, GrammarContent.Parse),
            "include" => Include.Parse(this.Self, this.Context),
            "start" => Start.Parse(this.Self, this.Context),
            _ => throw new NotSupportedException($"Not supported element `{this.Self.Name}`"),
        };
    }
}
