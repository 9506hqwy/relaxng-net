namespace RelaxNg.Schema;

public class Grammar : Pattern
{
    private Grammar(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.Contents;

    public GrammarContent[] Contents => this.Self.Elements().Select(this.ToGrammarContent).ToArray();

    internal static Grammar Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Grammar(element, file, context);
    }
}
