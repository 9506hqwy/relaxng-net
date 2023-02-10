namespace RelaxNg.Schema;

public class Schema
{
    internal const string RelaxNgNs = "http://relaxng.org/ns/structure/1.0";

    public Schema()
    {
        this.Context = new SchemaContext();
    }

    internal SchemaContext Context { get; }

    public Define GetDefine(string name)
    {
        return this.Context.Enumerate<Define>().First(d => d.Name == name);
    }
}
