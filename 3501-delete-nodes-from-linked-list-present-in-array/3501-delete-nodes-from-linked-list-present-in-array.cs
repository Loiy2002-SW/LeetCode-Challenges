/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ModifiedList(int[] nums, ListNode head) {
        var set = new HashSet<int>(nums);

        var cur = head;
        while (cur != null && set.Contains(cur.val)) {
            cur = cur.next;
        }

        var curr = cur;

        while ( curr.next != null) {
            if (set.Contains(curr.next.val)) {
                curr.next = curr.next.next;
                continue;
            }

            curr = curr.next;
        }

        return cur;
    }
}