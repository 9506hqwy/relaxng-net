namespace RelaxNg.Schema;

public class RngPosition
{
    private RngPosition(RngFile file, int line, int column)
    {
        this.File = file;
        this.Line = line;
        this.Column = column;
    }

    public int Column { get; }

    public RngFile File { get; }

    public int Line { get; }

    public override bool Equals(object obj)
    {
        if (obj is RngPosition other)
        {
            return
                this.File.Info.FullName == other.File.Info.FullName &&
                this.Line == other.Line &&
                this.Column == other.Column;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return $"{this.File.Info.Name}:{this.Line}:{this.Column}";
    }

    internal static RngPosition Create(RngReader reader)
    {
        return new RngPosition(reader.File, reader.LineNumber, reader.LinePosition);
    }
}
