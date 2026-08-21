// using System.Collections.Concurrent;
//
// namespace LeetCode;
//
// public static class AverageOfLevelsBTree
// {
//     private class TreeNode {
//         public int val;
//         public TreeNode left;
//         public TreeNode right;
//         
//         public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
//             this.val = val;
//             this.left = left;
//             this.right = right;
//         }
//     }
//
//     public static void Test()
//     {
//         // var tree1 = new TreeNode(3,
//         //     new TreeNode(9),
//         //     new TreeNode(20,
//         //         new TreeNode(15),
//         //         new TreeNode(7)));
//
//         // Тест 2: один вузол → очікується [1.0]
//         var tree2 = new TreeNode(1);
//         var result = AverageOfLevels(tree2);
//         foreach (var v in result)
//         {
//             Console.Write(v+", ");
//         }
//         // Тест 3: переповнення int — два вузли int.MaxValue на одному рівні
//         // → очікується [1.0, 2147483647.0]
//         // (сума рівня 1 = 4294967294 — в int не влазить; якщо буде -1.0, у тебе overflow)
//         // var tree3 = new TreeNode(1,
//         //     new TreeNode(int.MaxValue),
//         //     new TreeNode(int.MaxValue));
//   
//         // Тест 4: несиметричне "зигзаг"-дерево — рівні з дірками
//         //        1
//         //       / \
//         //      2   3
//         //       \    \
//         //        4    5
//         //       /
//         //      6
//         // → очікується [1.0, 2.5, 4.5, 6.0]
//         // var tree4 = new TreeNode(1,
//         //     new TreeNode(2, null, new TreeNode(4, new TreeNode(6), null)),
//         //     new TreeNode(3, null, new TreeNode(5)));
//
//         // foreach (var (tree, name) in new[] { (tree1, "tree1"), (tree2, "tree2"), (tree3, "tree3"), (tree4, "tree4") })
//         // {
//         //     Console.WriteLine($"{name}: [{string.Join(", ", AverageOfLevels(tree))}]");
//         // }
//     }
//
//     public IList<double> AverageOfLevels(TreeNode root)
//     {
//         var result = new List<double>();
//         var queue = new Queue<TreeNode>();
//         queue.Enqueue(root);
//
//         while (queue.Count > 0)              // поки є непройдений рівень
//         {
//             int levelSize = queue.Count;
//             int levelSizeDecr = queue.Count;
//             long sum = 0;
//             while (levelSizeDecr != 0)
//             {
//                 levelSizeDecr--;
//                 var node = queue.Dequeue();
//                 sum += node.val;
//
//                 if (node.left != null)
//                 {
//                     queue.Enqueue(node.left);
//                 }
//                 
//                 if (node.right != null)
//                 {
//                     queue.Enqueue(node.right);
//                 }
//             }
//             
//             // TODO 1: рівно levelSize разів —
//             //   дістань вузол через Dequeue,
//             //   додай node.val у long-суму рівня,
//             //   поклади в чергу не-null дітей (це вже наступний рівень).
//
//             // TODO 2: рівень оброблено — поклади середнє у result.
//             //   Пам'ятай про цілочисельне ділення.
//             result.Add(sum / (double)levelSize);
//         }
//
//         return result;
//     }
// }