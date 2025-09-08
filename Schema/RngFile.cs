namespace RelaxNg.Schema;

public class RngFile(FileInfo file)
{
    public FileInfo Info { get; } = file;

    public IPattern[]? Enumerate(Schema schema)
    {
        return schema.Context.Find(this.Info);
    }

    public void Parse(Schema schema)
    {
        this.Parse(schema.Context);
    }

    public Define Resolve(Schema schema, string name)
    {
        return this.Resolve(schema.Context, name);
    }

    internal void Parse(SchemaContext context)
    {
        if (context.Find(this.Info) is not null)
        {
            return;
        }

        var roots = this.GetRoots();

        var pattens = roots.Select(e => Pattern.ConvertFrom(e, context)).ToArray();

        context.Add(this.Info, pattens);
    }

    internal Define Resolve(SchemaContext context, string name)
    {
        var patterns = context.Find(this.Info);

        if (patterns is not null)
        {
            var define = this.FindDefine(context, patterns, name);

            if (define is not null)
            {
                return define;
            }
        }

        throw new Exception($"Not found `{name}` in `{this.Info.FullName}`.");
    }

    private Define? FindDefine(SchemaContext context, Include[] includes, string name)
    {
        foreach (var include in includes)
        {
            var refPatterns = context.Find(include.Href) ?? context.AddByInclude(include);
            var define = this.FindDefine(context, refPatterns, name);

            if (define is not null)
            {
                return define;
            }
        }

        return null;
    }

    private Define? FindDefine(SchemaContext context, IPattern[] patterns, string name)
    {
        var define = patterns
            .SelectMany(p => p.DescendantNodes)
            .OfType<Define>()
            .FirstOrDefault(d => d.Name == name);

        if (define is null)
        {
            var refIncludes = patterns
                .SelectMany(p => p.DescendantNodes)
                .OfType<Include>();
            if (refIncludes.Any())
            {
                define = this.FindDefine(context, refIncludes.ToArray(), name);
            }
        }

        return define;
    }

    private IEnumerable<RngElement> GetRoots()
    {
        using var reader = new RngReader(this);

        while (!reader.EOF)
        {
            while (reader.NodeType != XmlNodeType.Element)
            {
                if (!reader.Read())
                {
                    yield break;
                }
            }

            yield return RngElement.Create(reader, null);
        }
    }
}
