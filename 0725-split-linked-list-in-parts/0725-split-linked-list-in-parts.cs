public class Solution 
{
    public ListNode[] SplitListToParts(ListNode head, int k)
    {
        if (k == 1) { return [head]; }

        int len = 0;
        var fast = head;
        while (fast is not null && fast.next is not null)
        {
            fast = fast.next.next;
            len++;
        }

        len <<= 1;
        if (fast is not null) { len++; }

        int items_per_arr = len / k;
        int count_arr_extra_items = len % k;
        count_arr_extra_items = count_arr_extra_items == 0 || len <= k ? int.MinValue : count_arr_extra_items;

        var output = new ListNode[k];
        var curr = head;
        for (int arr_i = 0; arr_i < output.Length; arr_i++)
        {
            int arr_item_count = items_per_arr;
            if (arr_i < count_arr_extra_items) { arr_item_count++; }

            if (curr is null) { break; }

            ListNode node = new ListNode(curr.val);
            output[arr_i] = node;
            curr = curr.next;
            for (int curr_i = 1; curr_i < arr_item_count; curr_i++)
            {
                if (curr is null) { break; }
                node.next = new ListNode(curr.val);
                node = node.next;
                curr = curr.next;
            }
        }

        return output;
    }
}