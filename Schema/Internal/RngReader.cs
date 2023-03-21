namespace RelaxNg.Schema;

internal class RngReader : XmlTextReader
{
    internal RngReader(RngFile file)
        : base(file.Info.FullName)
    {
        this.File = file;
        this.WhitespaceHandling = WhitespaceHandling.Significant;
    }

    internal RngFile File { get; }

    internal bool ThrowIfNextNode()
    {
        if (!this.Read())
        {
            var pos = RngPosition.Create(this);
            throw new InvalidOperationException($"Unexpected EOF. {pos}");
        }

        return true;
    }
}
