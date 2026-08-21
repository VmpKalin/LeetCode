namespace LeetCode;

public class KthLargestElementInStream
{
    private int[] _nums;
    private int count;
    private int k;
    public KthLargestElementInStream(int k, int[] nums)
    {
        this.k = k;
        _nums = new int[k];

        foreach (var val in nums)
            Add(val);
    }

    public int Add(int val)
    {
        if (count < k)
        {
            int i = count - 1;
            while (i >= 0 && _nums[i] > val)
            {
                _nums[i + 1] = _nums[i];
                i--;
            }

            _nums[i+1] = val;
            count++;
        }
        else if(val > _nums[0])
        {
            int i = 0;
            while (i + 1 < k && _nums[i + 1] < val)
            {
                _nums[i] = _nums[i + 1];
                i++;
            }

            _nums[i] = val;
        }

        return _nums[0];
    }
}