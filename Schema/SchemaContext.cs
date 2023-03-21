namespace RelaxNg.Schema;

internal class SchemaContext
{
    private readonly Dictionary<FileInfo, IPattern[]> patterns;

    internal SchemaContext()
    {
        this.patterns = new Dictionary<FileInfo, IPattern[]>();
    }

    internal void Add(FileInfo file, IPattern[] patterns)
    {
        this.patterns.Add(file, patterns);
    }

    internal IPattern[] AddByInclude(Include include)
    {
        var file = include.Position.File;

        // TODO: Add URI support.
        var path = Path.Combine(
            Path.GetDirectoryName(file.Info.FullName),
            include.Href);

        var rng = new RngFile(new FileInfo(path));
        rng.Parse(this);

        return this.Find(rng.Info)!;
    }

    internal IEnumerable<T> Enumerate<T>()
        where T : INode
    {
        return this.patterns.Values
            .SelectMany(p => p)
            .SelectMany(p => p.DescendantNodes)
            .OfType<T>();
    }

    internal IPattern[]? Find(string file)
    {
        return this.patterns.FirstOrDefault(p => p.Key.Name == file).Value;
    }

    internal IPattern[]? Find(FileInfo file)
    {
        this.patterns.TryGetValue(file, out var patterns);
        return patterns;
    }
}
