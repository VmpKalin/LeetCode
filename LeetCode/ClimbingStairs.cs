namespace LeetCode;

public class ClimbingStairs
{
    public int ClaimAdvanced(int n)
    {
        var memo = new int[n + 1];//Because of we can store max N numbers in a row, so we can easily use array here like key-value, where key=index and value=(value of array)
        return Count(n, memo);
    }

    private int Count(int i, int[] memo)
    {
        if (i <= 2) return i; // all values <=2 we know, because they equal N
        if (memo[i] != 0) return memo[i]; //here all array already has values, all of them zeros 0
        //So when we check for ex: memo[3] and if it is 0 -> we calculate it and set
        // if not, we return calculated prev value

        memo[i] = Count(i - 1, memo) + Count(i - 2, memo);
        return memo[i];
    }
    
    Dictionary<int,int> _dict = new();

    public int ClimbStairsV2(int n) {
        return Execute(0, n);
    }

    public int ExecuteV2(int n, int lookFor)
    {
        if(_dict.ContainsKey(n))
        {
            return _dict[n];
        }
        int result;
        if (n == lookFor)
        {
            result = 1;
        }
        else if (n > lookFor)
        {
            result = 0;
        }
        else
        {
            result = ExecuteV2(n+1, lookFor) + ExecuteV2(n+2, lookFor)
        }

        _dict[n] = result;
        
        return result;
    }
    
    public ClimbingStairs(int n)
    {
        int result = Execute(n, 0);
        Console.WriteLine($"Result: {result}");
    }

    public int ClimbStairs(int n) {
        if (n <= 0)
        {
            return 0;
        }

        return (ClimbStairs(n) - 1) + (ClimbStairs(n) - 2);
    }
    
    
    private int Execute(int valueThatItlooks, int current)
    {
        if (current > valueThatItlooks)
        {
            return 0;
        }

        if (current == valueThatItlooks)
        {
            return 1;
        }

        return Execute(valueThatItlooks,current + 2) + Execute(valueThatItlooks ,current + 1);
    }
    
    private int ExecuteV2(int valueThatItlooks)
    {
        if (valueThatItlooks < 4)
        {
            return valueThatItlooks;
        }

        var last = 2;
        var preLast = 1;
        for (int i = 3; i <= valueThatItlooks; i++)
        {
            var temp = last + preLast;
            preLast = last;
            last = temp;
        }

        return last;
    }
}