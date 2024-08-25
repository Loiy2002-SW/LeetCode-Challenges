/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var nodes = new List<int>();
        var stack = new Stack<TreeNode>();
        var visited = new HashSet<TreeNode>();

        while (root != null || stack.Any())
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }

            root = stack.Pop();
            if (root.right == null || visited.Contains(root.right))
            {
                nodes.Add(root.val);
                visited.Add(root);
                root = null;
            }
            else
            {
                stack.Push(root);
                root = root.right;
            }
        }

        return nodes;
    }
}