namespace LeetCode;

public static class BinaryTreeLevelOrderTraversal
{
    public static IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }
        var queue = new Queue<TreeNode>([root]);
        while (queue.Count > 0)
        {
            var currentLevelCount = queue.Count;
            var subArray = new List<int>(currentLevelCount);
            while (currentLevelCount != 0)
            {
                var node = queue.Dequeue();
                subArray.Add(node.val);
                
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }

                currentLevelCount--;
            }
            result.Add(subArray);
        }

        return result;
    }
}