namespace RelaxNg.Schema;

internal class RngAttribute
{
    private RngAttribute(
        RngPosition position,
        string ns,
        string name,
        string value,
        RngElement parent)
    {
        this.Position = position;
        this.NamespaceUri = ns;
        this.Name = name;
        this.Value = value;
        this.Parent = parent;
    }

    internal string Name { get; }

    internal string NamespaceUri { get; }

    internal RngElement Parent { get; }

    internal RngPosition Position { get; }

    internal string Value { get; }

    public override string ToString()
    {
        return string.IsNullOrWhiteSpace(this.NamespaceUri) ?
            $"{this.Name}={this.Value}" :
            $"{{{this.NamespaceUri}}}{this.Name}={this.Value}";
    }

    internal static RngAttribute Create(RngReader reader, RngElement parent)
    {
        var position = RngPosition.Create(reader);

        return new RngAttribute(
            position,
            reader.NamespaceURI,
            reader.Name,
            reader.Value,
            parent);
    }
}
