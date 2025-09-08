namespace RelaxNg.Schema;

public class Grammar : Pattern
{
    private Grammar(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Contents;

    public GrammarContent[] Contents => [.. this.Self.Elements().Select(this.ToGrammarContent)];

    internal static Grammar Parse(RngElement element, SchemaContext context)
    {
        return new Grammar(element, context);
    }
}
