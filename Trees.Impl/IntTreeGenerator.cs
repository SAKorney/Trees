namespace Trees.Impl;

public class IntTreeGenerator
{
    public static Tree<int> Generate()
    {
        var root = new Tree<int>() { Value = 0 };
        GenerateInternal(root, level: 0, maxLevel: 3);
        return root;
    }

    private static void GenerateInternal(Tree<int> root, int level, int maxLevel)
    {
        if (level > maxLevel) return;

        root.Children = Enumerable.Range(root.Value + level, 3)
            .Select(x => new Tree<int>() { Value = x })
            .ToList();

        foreach (var child in root.Children)
        {
            GenerateInternal(child, level+1, maxLevel);
        }
    }
}
