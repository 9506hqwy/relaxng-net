namespace RelaxNg.Schema;

public class GrammarContent : Node
{
    private GrammarContent(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.ToChildArray(this.Inner);

    public INode Inner => this.GetInner();

    internal static GrammarContent Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new GrammarContent(element, file, context);
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
            "div" => Div<GrammarContent>.Parse(this.Self, this.File, this.Context, GrammarContent.Parse),
            "include" => Include.Parse(this.Self, this.File, this.Context),
            "start" => Start.Parse(this.Self, this.File, this.Context),
            _ => throw new NotSupportedException($"Not supported element `{this.Self.Name}`"),
        };
    }
}
