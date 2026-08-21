namespace LeetCode;

public class MyLinkedList
{
    class Node
    {
        public int value;
        public Node next;
        public Node prev;
    }
    
    private Node head;
    private Node current;
    private Node last;
    public int max_index = -1;
    
    public int Get(int index) {
        if (index > max_index)
        {
            return -1;
        }

        var currentNode = GetNode(index);
        var result = currentNode.value;
        current = null;
        return result;
    }

    private Node GetNode(int index)
    {
        if (index == 0)
        {
            return head;
        }
        var mid = max_index / 2;
        if (index < mid)
        {
            current = head;
            int current_index = 0;
            while (current_index != index)
            {
                current = current.next;
                current_index++;
            }
        }
        else
        {
            current = last;
            var current_index = max_index;
            while (current_index != index)
            {
                current = current.prev;
                current_index--;
            }
        }

        return current;
    }

    public void AddAtHead(int val)
    {
        var newHead = new Node()
        {
            next = head,
            value = val,
        };
        
        max_index++;
        if (max_index == 0)
        {
            head = newHead;
            last = newHead;
            return;
        }
        
        head.prev = newHead;
        head = newHead;
    }
    
    public void AddAtTail(int val) {
        var newLast = new Node()
        {
            prev = last,
            value = val,
        };
        max_index++;
        if (max_index == 0)
        {
            head = newLast;
            last = newLast;
            return;
        }
        last.next = newLast;
        last = newLast;
    }
    
    public void AddAtIndex(int index, int val) {
        if (index > max_index + 1) return;
        
        if (index == 0)
        {
            AddAtHead(val);
            return;
        }

        if (index == max_index+1)
        {
            AddAtTail(val);
            return;
        }

        var nodeToChange = GetNode(index);

        var newNode = new Node
        {
            value = val,
            next = nodeToChange,
            prev = nodeToChange.prev
        };

        nodeToChange.prev.next = newNode;
        nodeToChange.prev = newNode;
        max_index++;
    }

    private bool ResetIfNeeded(int index)
    {
        if (max_index == 0 && index == 0)
        {
            head = null;
            last = null;
            return true;
        }

        return false;
    }

    public void DeleteAtIndex(int index) {
        if (index < 0 || index > max_index) return;

        var nodeToDelete = GetNode(index);
        
        if (nodeToDelete.prev == null) head = nodeToDelete.next; // видаляємо голову
        else nodeToDelete.prev.next = nodeToDelete.next;
  
        if (nodeToDelete.next == null) last = nodeToDelete.prev; // видаляємо хвіст
        else nodeToDelete.next.prev = nodeToDelete.prev;

        max_index--;
    }
}