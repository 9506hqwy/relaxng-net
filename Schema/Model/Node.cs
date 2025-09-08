namespace RelaxNg.Schema;

public abstract class Node : INode
{
    internal Node(RngElement element, SchemaContext context)
    {
        this.Self = element;
        this.Context = context;
    }

    public abstract IEnumerable<INode> ChildNodes { get; }

    public int Depth => this.Self.Depth;

    public IEnumerable<INode> DescendantNodes => this.GetDescendant();

    public IEnumerable<INode> DescendantNodesAndSelf => this.GetDescendantAndSelf();

    public RngPosition Position => this.Self.Position;

    internal SchemaContext Context { get; }

    internal RngElement Self { get; }

    public sealed override string ToString()
    {
        return this.Self.ToString();
    }

    internal IEnumerable<INode> ToChildArray(INode? node)
    {
        return node is null ? Array.Empty<INode>() : [node];
    }

    internal ExceptName ToExceptName(RngElement element)
    {
        return ExceptName.Parse(element, this.Context);
    }

    internal ExceptPattern ToExceptPattern(RngElement element)
    {
        return ExceptPattern.Parse(element, this.Context);
    }

    internal GrammarContent ToGrammarContent(RngElement element)
    {
        return GrammarContent.Parse(element, this.Context);
    }

    internal IncludeContent ToIncludeContent(RngElement element)
    {
        return IncludeContent.Parse(element, this.Context);
    }

    internal INameBase ToNameBase(RngElement element)
    {
        return NameBase.ConvertFrom(element, this.Context);
    }

    internal Param ToParam(RngElement element)
    {
        return Param.Parse(element, this.Context);
    }

    internal IPattern ToPattern(RngElement element)
    {
        return Pattern.ConvertFrom(element, this.Context);
    }

    private IEnumerable<INode> GetDescendant()
    {
        return this.ChildNodes.Cast<Node>().SelectMany(c => c.GetDescendantAndSelf());
    }

    private IEnumerable<INode> GetDescendantAndSelf()
    {
        foreach (var descendant in this.GetDescendant())
        {
            yield return descendant;
        }

        yield return this;
    }
}
