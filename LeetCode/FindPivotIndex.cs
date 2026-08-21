namespace LeetCode;

public static class FindPivotIndex
{
    public static int PivotIndex(int[] nums)
    {
        var index = 0;
        var left = 0;
        var right = nums.Sum() - nums[0];
        if (left == right)
        {
            return index;
        }   
        while (index < nums.Length-1)
        {
            left += nums[index];
            right -= nums[index+1];
            
            index++;
            if (left == right)
            {
                return index;
            }
        }

        return -1;
    }
}