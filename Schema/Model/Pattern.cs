namespace RelaxNg.Schema;

public abstract class Pattern : Node, IPattern
{
    internal Pattern(XElement element, RngFile file, SchemaContext context)
        : base(element, file, context)
    {
    }

    internal static IPattern ConvertFrom(XElement element, RngFile file, SchemaContext context)
    {
        if (element.Name.NamespaceName != Schema.RelaxNgNs)
        {
            return Unknown.Parse(element, file, context);
        }

        return element.Name.LocalName switch
        {
            "attribute" => Attribute.Parse(element, file, context),
            "choice" => Choice.Parse(element, file, context),
            "data" => Data.Parse(element, file, context),
            "element" => Element.Parse(element, file, context),
            "empty" => Empty.Parse(element, file, context),
            "externalRef" => ExternalRef.Parse(element, file, context),
            "grammar" => Grammar.Parse(element, file, context),
            "group" => Group.Parse(element, file, context),
            "interleave" => Interleave.Parse(element, file, context),
            "list" => List.Parse(element, file, context),
            "mixed" => Mixed.Parse(element, file, context),
            "notAllowed" => NotAllowed.Parse(element, file, context),
            "oneOrMore" => OneOrMore.Parse(element, file, context),
            "optional" => Optional.Parse(element, file, context),
            "parentRef" => ParentRef.Parse(element, file, context),
            "ref" => Ref.Parse(element, file, context),
            "text" => Text.Parse(element, file, context),
            "value" => Value.Parse(element, file, context),
            "zeroOrMore" => ZeroOrMore.Parse(element, file, context),
            _ => throw new NotSupportedException($"Not supported element `{element.Name}`"),
        };
    }
}
