namespace LeetCode;

public static class MaximumAverageSubarray {
    public static double FindMaxAverage(int[] nums, int k)
    {
        var right = k-1;
        double currentSum = 0;
        for (int i = 0; i < k; i++)
            currentSum += nums[i];
        double maxSum = currentSum;
        while (right < nums.Length-1)
        {
            var nextSum = currentSum - nums[right-k+1] + nums[right+1];
            
            if (nextSum > maxSum)
            {
                maxSum = nextSum;
            }

            currentSum = nextSum;
            right++;
        }

        return maxSum / k;
    }
}