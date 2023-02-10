namespace RelaxNg.Schema;

public interface IHasChildren : INode
{
    IPattern[] Children { get; }
}
