public class NumArray
{

    private Dictionary<int, int> values;
    
    public NumArray(int[] nums = null)
    {
        nums = new[] { -2,0,3,-5,2,-1 };
        values = new Dictionary<int, int>(nums.Length) { { 0, 0 } };
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var index = i + 1;
            sum += nums[i];
            values[index] = sum;
        }}

    public int SumRange(int left, int right)
    {
        return values[right + 1] - values[left];
    }
}