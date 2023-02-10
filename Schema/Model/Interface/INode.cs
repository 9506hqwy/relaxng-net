namespace RelaxNg.Schema;

public interface INode
{
    IEnumerable<INode> ChildNodes { get; }

    IEnumerable<INode> DescendantNodes { get; }

    IEnumerable<INode> DescendantNodesAndSelf { get; }

    RngFile File { get; }
}
