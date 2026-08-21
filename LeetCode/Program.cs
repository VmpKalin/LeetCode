// int[] nums = [-1,0,3,5,-4,9,-20,12];
// var target = 9;
//     
// Console.WriteLine(BinarySearchLeftRightAprroach(nums, target));

using LeetCode;

int[][] matrix = new int[][] { [1,1,1],[1,1,1],[1,1,1]};
//[[1,1,1],[1,1,0],[1,0,1]]
// 
// int[][] matrix = new int[][] { [0,0,0],[0,1,0]};
new FloodFillTask(matrix, 1, 1, 2);

// int[] nums = [1,2,3,5,12];
// int[] nums = [-1,-1,0,1,1,0];
// int[] nums = [];

// var obj = new KthLargestElementInStream(1, nums);
// Console.WriteLine(obj.Add(-4));
// Console.WriteLine(obj.Add(-3));
// Console.WriteLine(obj.Add(-3));
// Console.WriteLine(obj.Add(0));

// ReverseLinkedList.ReverseList(ReverseLinkedList.Build(1, 2,3));
// var result =  FindPivotIndex.PivotIndex(nums);
// Console.WriteLine(result);
// new NumArray();
// AverageOfLevelsBTree.Test();
// Console.WriteLine(MaximumAverageSubarray.FindMaxAverage([4,2,1,3,3], 2));
// new Parentheses20("[]");
// new Parentheses20("[[}}");
// new Parentheses20("[{}]");
// new ClimbingStairs(44);
// new MergeIntervals();
return;


int[] BinarySearchLeftRightAprroach(int[] nums)
{
    if (nums.Length == 0)
    {
        return [];
    }
    
    var arr = new int[0];
    
    var maxSum = nums[0];
    var currentSum = nums[0];
    var temp = nums[0];
    
    for (int i = 1; i < nums.Length; i++)
    {
        var x = nums[i];
        if (x > maxSum)
        {
            currentSum = x;
        }
    }
    
    return arr;
}

int Search(int[] nums, int target)
{
    int middleIndex = nums.Length / 2;
    int len = nums.Length; 
    
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[middleIndex] == target)
        {
            return middleIndex;
        }
        
        if (nums[middleIndex] < target)
        {
            middleIndex = (middleIndex + len) / 2;
        }
        else
        {
            len = middleIndex;
            middleIndex /= 2;
        }
    }
    
    return -1;
}

// static int BinarySearchLeftRightAprroach(int[] nums, int target)
// {
//     int left = 0;
//     int right = nums.Length - 1;
//
//     while (left <= right)
//     {
//         int middle = left + (right - left) / 2;
//         
//         if (nums[middle] == target)
//         {
//             return middle;
//         }
//
//         if (nums[middle] > target)
//         {
//             right = middle - 1;
//         }
//         else
//         {
//             left = middle + 1;
//         }
//     }
//     
//     return -1;
// }


static int[] TwoSum(int[] nums, int target) {
    var dict = new Dictionary<int, int>(nums.Count());
    var index = 0;

    for (; index < nums.Length; index++)
    {
        var current = nums[index];

        if (dict.ContainsKey(current))
        {
            return new[] { dict[current], index };
        }

        var search = target - current;
        if (!dict.ContainsKey(search))
        {
            dict[search] = index;    
        }
    }
    
    return [];
}