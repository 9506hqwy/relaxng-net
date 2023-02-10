namespace RelaxNg.Schema;

public abstract class NameBase : Node, INameBase
{
    internal NameBase(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    internal static INameBase ConvertFrom(XElement element, RngFile file, SchemaContext context)
    {
        if (element.Name.NamespaceName != Schema.RelaxNgNs)
        {
            return Unknown.Parse(element, file, context);
        }

        return element.Name.LocalName switch
        {
            "anyName" => AnyName.Parse(element, file, context),
            "choice" => ChoiceName.Parse(element, file, context),
            "name" => Name.Parse(element, file, context),
            "nsName" => NsName.Parse(element, file, context),
            _ => throw new NotSupportedException($"Not supported element `{element.Name}`"),
        };
    }
}
