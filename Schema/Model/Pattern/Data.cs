namespace RelaxNg.Schema;

public class Data : Pattern
{
    internal Data(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.GetChildNodes();

    public ExceptPattern? ExceptPattern => this.Self.Elements()
        .SkipWhile(e => e.Name == Param.TagName)
        .Select(this.ToExceptPattern)
        .FirstOrDefault();

    public Param[] Parameters => [.. this.Self.Elements()
        .TakeWhile(e => e.Name == Param.TagName)
        .Select(this.ToParam)];

    public string Type => this.Self.Attribute("type").Value;

    internal static Data Parse(RngElement element, SchemaContext context)
    {
        return new Data(element, context);
    }

    private IEnumerable<INode> GetChildNodes()
    {
        foreach (var p in this.Parameters)
        {
            yield return p;
        }

        if (this.ExceptPattern is not null)
        {
            yield return this.ExceptPattern;
        }
    }
}
