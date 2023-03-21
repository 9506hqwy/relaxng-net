namespace RelaxNg.Schema;

public class Div<T> : Node
    where T : Node
{
    private readonly Func<RngElement, SchemaContext, T> conv;

    private Div(RngElement element, SchemaContext context, Func<RngElement, SchemaContext, T> conv)
        : base(element, context)
    {
        this.conv = conv;
    }

    public override IEnumerable<INode> ChildNodes => this.Children;

    public T[] Children => this.Self.Elements().Select(this.ConvertFrom).ToArray();

    internal static Div<T> Parse(RngElement element, SchemaContext context, Func<RngElement, SchemaContext, T> conv)
    {
        return new Div<T>(element, context, conv);
    }

    private T ConvertFrom(RngElement element)
    {
        return this.conv(element, this.Context);
    }
}
