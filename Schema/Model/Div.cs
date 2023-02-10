namespace RelaxNg.Schema;

public class Div<T> : Node
    where T : Node
{
    private readonly Func<XElement, RngFile, SchemaContext, T> conv;

    private Div(XElement element, RngFile file, SchemaContext context, Func<XElement, RngFile, SchemaContext, T> conv)
        : base(element, file, context)
    {
        this.conv = conv;
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public T[] Children => this.Self.Elements().Select(this.ConvertFrom).ToArray();

    internal static Div<T> Parse(XElement element, RngFile file, SchemaContext context, Func<XElement, RngFile, SchemaContext, T> conv)
    {
        return new Div<T>(element, file, context, conv);
    }

    private T ConvertFrom(XElement element)
    {
        return this.conv(element, this.File, this.Context);
    }
}
