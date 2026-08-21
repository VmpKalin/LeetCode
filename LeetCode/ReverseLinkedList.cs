namespace LeetCode;

public static class ReverseLinkedList
{
  public class ListNode {
      public int val;
      public ListNode? next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
  public static ListNode Build(params int[] values)
  {
      ListNode head = null;
      for (int i = values.Length - 1; i >= 0; i--)
          head = new ListNode(values[i], head);
      return head;
  }
  
  public static ListNode ReverseList(ListNode head)
  {
      ListNode prev = null;              // було: new ListNode(head.val)
      while (head != null)               // було: head.next != null
      {
          var tmp = head.next;
          head.next = prev;
          prev = head;
          head = tmp;
      }
      return prev;
  }
}