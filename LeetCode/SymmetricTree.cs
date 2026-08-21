namespace LeetCode;

public class SymmetricTree
{
    public bool IsSymmetric(TreeNode root) => Mirror(root.left, root.right);

    private bool Mirror(TreeNode a, TreeNode b)
    {
        if (a == null && b == null) return true;
        if (a == null || b == null) return false;      
        if (a.val != b.val) return false;
        
        return Mirror(a.left, b.right) && Mirror(a.right, b.left);
    }
}