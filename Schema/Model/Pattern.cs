namespace RelaxNg.Schema;

public abstract class Pattern : Node, IPattern
{
    internal Pattern(RngElement element, SchemaContext context)
        : base(element, context)
    {
    }

    internal static IPattern ConvertFrom(RngElement element, SchemaContext context)
    {
        return element.NamespaceUri != Schema.RelaxNgNs
            ? Unknown.Parse(element, context)
            : element.Name switch
            {
                "attribute" => Attribute.Parse(element, context),
                "choice" => Choice.Parse(element, context),
                "data" => Data.Parse(element, context),
                "element" => Element.Parse(element, context),
                "empty" => Empty.Parse(element, context),
                "externalRef" => ExternalRef.Parse(element, context),
                "grammar" => Grammar.Parse(element, context),
                "group" => Group.Parse(element, context),
                "interleave" => Interleave.Parse(element, context),
                "list" => List.Parse(element, context),
                "mixed" => Mixed.Parse(element, context),
                "notAllowed" => NotAllowed.Parse(element, context),
                "oneOrMore" => OneOrMore.Parse(element, context),
                "optional" => Optional.Parse(element, context),
                "parentRef" => ParentRef.Parse(element, context),
                "ref" => Ref.Parse(element, context),
                "text" => Text.Parse(element, context),
                "value" => Value.Parse(element, context),
                "zeroOrMore" => ZeroOrMore.Parse(element, context),
                _ => throw new NotSupportedException($"Not supported element `{element.Name}`"),
            };
    }
}
