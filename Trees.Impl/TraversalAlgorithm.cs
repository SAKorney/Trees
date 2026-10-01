namespace Trees.Impl;

public class TraversalAlgorithm
{
    class DFSAlgo<T> : ITraversalAlgorithm<T>
    {
        private Stack<Tree<T>> _stack = new();

        public DFSAlgo(Tree<T> root)
        {
            _stack.Push(root);
        }

        public void AddNext(Tree<T> node)
        {
            _stack.Push(node);
        }

        public Tree<T> CurrentNode =>_stack.Pop();
    }

    class BFSAlgo<T> : ITraversalAlgorithm<T>
    {
        private Queue<Tree<T>> _queue = new();

        public BFSAlgo(Tree<T> root)
        {
            _queue.Enqueue(root);
        }

        public Tree<T> CurrentNode => _queue.Dequeue();

        public void AddNext(Tree<T> node)
        {
            _queue.Enqueue(node);
        }
    }

    public ITraversalAlgorithm<T> DFS<T>(Tree<T> root)
    {
        return new DFSAlgo<T>(root);
    }

    public ITraversalAlgorithm<T> BFS<T>(Tree<T> root)
    {
        return new BFSAlgo<T>(root);
    }
}
