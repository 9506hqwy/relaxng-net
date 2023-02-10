﻿namespace RelaxNg.Schema;

public class RngFile
{
    private readonly FileInfo file;

    public RngFile(FileInfo file)
    {
        this.file = file;
    }

    public FileInfo Info => this.file;

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
        if (context.Find(this.file) is not null)
        {
            return;
        }

        using var stream = this.file.OpenRead();

        var root = XDocument.Load(stream);

        var pattens = root.Elements().Select(e => Pattern.ConvertFrom(e, this, context)).ToArray();

        context.Add(this.file, pattens);
    }

    internal Define Resolve(SchemaContext context, string name)
    {
        var patterns = context.Find(this.file);

        if (patterns is not null)
        {
            var define = this.FindDefine(context, patterns, name);

            if (define is not null)
            {
                return define;
            }
        }

        throw new Exception($"Not found `{name}` in `{this.file.FullName}`.");
    }

    private Define? FindDefine(SchemaContext context, Include[] includes, string name)
    {
        foreach (var include in includes)
        {
            var refPatterns = context.Find(include.Href);

            if (refPatterns is null)
            {
                refPatterns = context.AddByInclude(include);
            }

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
}
