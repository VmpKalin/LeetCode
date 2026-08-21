namespace LeetCode;

public class InseartInterval
{
/*
    Example 1:
       Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
       Output: [[1,5],[6,9]]

    Example 2:       
       Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
       Output: [[1,2],[3,10],[12,16]]
       
    Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
*/

    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();
        bool inserted = false;
        for (int i = 0; i < intervals.Length; i++)
        {
            var interval = intervals[i];
            if (interval[1] < newInterval[0])
            {
                // інтервал повністю ЛІВОРУЧ від нового
                result.Add(interval);
            }
            else if (interval[0] > newInterval[1])
            {   
                // повністю праворуч: спочатку (один раз) новий, потім цей
                if (!inserted)
                {
                    result.Add(newInterval); 
                    inserted = true;
                }
                result.Add(interval);
            }
            else
            {
                // перетин — розширюємо newInterval, у result нічого не кладемо
                newInterval[0] = Math.Min(newInterval[0], interval[0]);
                newInterval[1] = Math.Max(newInterval[1], interval[1]);
            }
        }
        
        if (!inserted) result.Add(newInterval);

        return result.ToArray();
    }
}