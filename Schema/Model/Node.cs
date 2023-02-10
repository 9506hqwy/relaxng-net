namespace RelaxNg.Schema;

public abstract class Node : INode
{
    internal Node(XElement element, RngFile file, SchemaContext context)
    {
        this.Self = element;
        this.File = file;
        this.Context = context;
    }

    public abstract IEnumerable<INode> ChildNodes { get; }

    public IEnumerable<INode> DescendantNodes => this.GetDescendant();

    public IEnumerable<INode> DescendantNodesAndSelf => this.GetDescendantAndSelf();

    public RngFile File { get; }

    internal SchemaContext Context { get; }

    internal XElement Self { get; }

    public override sealed string ToString()
    {
        return this.Self.ToString();
    }

    internal IEnumerable<INode> ToChildArray(INode? node)
    {
        return node is null ? Array.Empty<INode>() : new[] { node };
    }

    internal ExceptName ToExceptName(XElement element)
    {
        return ExceptName.Parse(element, this.File, this.Context);
    }

    internal ExceptPattern ToExceptPattern(XElement element)
    {
        return ExceptPattern.Parse(element, this.File, this.Context);
    }

    internal GrammarContent ToGrammarContent(XElement element)
    {
        return GrammarContent.Parse(element, this.File, this.Context);
    }

    internal IncludeContent ToIncludeContent(XElement element)
    {
        return IncludeContent.Parse(element, this.File, this.Context);
    }

    internal INameBase ToNameBase(XElement element)
    {
        return NameBase.ConvertFrom(element, this.File, this.Context);
    }

    internal Param ToParam(XElement element)
    {
        return Param.Parse(element, this.File, this.Context);
    }

    internal IPattern ToPattern(XElement element)
    {
        return Pattern.ConvertFrom(element, this.File, this.Context);
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
