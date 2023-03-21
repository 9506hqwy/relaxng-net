namespace RelaxNg.Schema;

public interface INode
{
    IEnumerable<INode> ChildNodes { get; }

    IEnumerable<INode> DescendantNodes { get; }

    IEnumerable<INode> DescendantNodesAndSelf { get; }

    RngPosition Position { get; }
}
