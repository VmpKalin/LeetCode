namespace LeetCode;

public class MinCostClimbingStairsClass
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var memo = new int[cost.Length];
        return Math.Min(Calculate(cost, 0, memo), Calculate(cost, 1, memo));
    }

    int Calculate(int[] cost, int possition, int[] memo)
    {
        if (possition >= cost.Length)
            return 0;

        if (memo[possition] != 0)
            return memo[possition];
        
        var min = Math.Min(Calculate(cost, possition + 1, memo), Calculate(cost, possition + 2, memo));

        memo[possition] = cost[possition] + min;
        
        return memo[possition];
    }
}