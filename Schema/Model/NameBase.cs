namespace RelaxNg.Schema;

public abstract class NameBase : Node, INameBase
{
    internal NameBase(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    internal static INameBase ConvertFrom(RngElement element, SchemaContext context)
    {
        return element.NamespaceUri != Schema.RelaxNgNs
            ? Unknown.Parse(element, context)
            : element.Name switch
            {
                "anyName" => AnyName.Parse(element, context),
                "choice" => ChoiceName.Parse(element, context),
                "name" => Name.Parse(element, context),
                "nsName" => NsName.Parse(element, context),
                _ => throw new NotSupportedException($"Not supported element `{element.Name}`"),
            };
    }
}
