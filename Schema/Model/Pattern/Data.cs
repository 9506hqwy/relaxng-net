namespace RelaxNg.Schema;

public class Data : Pattern
{
    internal Data(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    public override IEnumerable<INode> ChildNodes => this.GetChildNodes();

    public ExceptPattern? ExceptPattern => this.Self.Elements()
        .SkipWhile(e => e.Name.LocalName == Param.TagName)
        .Select(this.ToExceptPattern)
        .FirstOrDefault();

    public Param[] Parameters => this.Self.Elements()
        .TakeWhile(e => e.Name.LocalName == Param.TagName)
        .Select(this.ToParam)
        .ToArray();

    public string Type => this.Self.Attribute("type").Value;

    internal static Data Parse(XElement element, RngFile file, SchemaContext context)
    {
        return new Data(element, file, context);
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
