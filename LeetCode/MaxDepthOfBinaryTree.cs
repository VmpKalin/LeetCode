namespace LeetCode;

public class MaxDepthOfBinaryTree
{
    public MaxDepthOfBinaryTree(TreeNode root)
    {
        MaxDepthV2(root);
    }

    public int MaxDepthV2(TreeNode? head)
    {
        var callstack = new Stack<(TreeNode, int)>();
        callstack.Push((head, 1));
        
        while (callstack.Count != 0)
        {
            //what do we need to check, left and right
            
            var current = callstack.Pop();

            if (head.left == null & head.right == null)
            {
                return 0;
            }

            if (current.Item1.left != null)
            {
                callstack.Push((current.Item1.left, current.Item2++));
            }
            if (current.Item1.right != null)
            {
                callstack.Push((current.Item1.right, current.Item2++));
            }
        }
    }
    
    public int MaxDepthV3(TreeNode? head)
    {
        //main case, where we can say that the deepest node in our tree
        if (head == null)
        {
            return 0;
        }
        
        //here we firstly will go step by step to the end of tree, and just after we will do calculations
        /* Sample:
         call chain:
         [1,null,2] - result should be 2, because of 2 levels and on the second we have one value
             1 first call here
            /\
           /  \
         null  2 here we will do two chains, seperate and we will go till this condition "if (head == null)"
          
        LEFT:  
        MaxDepthV3(head.left - where value is null)
        here we will check and see that head is null and we will return null
        
        RIGHT:
        MaxDepthV3(head.right - where value is 2)
        Here we will pass and head is not null, so we will try to do two more call to face our candition and return back
        MaxDepthV3(head.left - where value is null)
        MaxDepthV3(head.right - where value is null)
        
        For both of them we will face with condition and return 0 but, here is the case:
        This execution is at the end of it`s chain and we should return back and with each return we will do + 1
        Depth of func execution chain for right part was 2
        Depth of func execution chain for left part was 1
        
        */
        return Math.Max(MaxDepthV3(head.left) + 1, MaxDepthV3(head.right) + 1);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    public int MaxDepthMain(TreeNode? root)
    {
        return root == null ? 0 : Math.Max(MaxDepthMain(root.left), MaxDepthMain(root.right)) + 1;
    }
}