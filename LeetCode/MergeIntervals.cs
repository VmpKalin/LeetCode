namespace LeetCode;

public class MergeIntervals
{
    public MergeIntervals()
    {
        // int[][] intervals = [[1, 3], [2, 6], [8, 10], [15, 18]];;
        // int[][] intervals = [[1, 3], [3, 5]];;
        // int[][] intervals = [[4, 7], [1, 4]];;
        // int[][] intervals = [[1, 4], [0, 0]];
        // int[][] intervals = [[2, 3], [4, 5], [6, 7], [8, 9], [1, 10]];
        int[][] intervals = [[1, 4], [0, 2]];
        // int[][] intervals = [[2, 3], [5, 5], [2, 2], [3, 4], [3, 4]];
        // int[][] intervals = [[5, 5], [1, 3], [3, 5], [4, 6], [1, 1], [3, 3], [5, 6], [3, 3], [2, 4], [0, 0]];
        // int[][] intervals = [[0,0],[1,2],[5,5],[2,4],[3,3],[5,6],[5,6],[4,6],[0,0],[1,2],[0,2],[4,5]];
        // int[][] intervals = [[2, 4], [4, 7]];
        // int[][] intervals = [[2, 3], [4, 6], [5, 7], [3, 4]];
        var result = Merge(intervals);
    }
    public int[][] MergeV2(int[][] intervals) {
        if (intervals.Length == 0)
        {
            return [];
        }
        //спочатку сортуй, потім один прохід.
        
        var min = intervals[0][0];
        var max = intervals[0][1];
        List<int[]> result = [intervals[0]];
        // var jStart = 0;
        for (int i = 1; i < intervals.Length; i++)
        {
            //[2,6]
            // var current = Normilize(intervals[i]);
            var current = intervals[i];
            
            var found = false;
            for (int j = 0; j < result.Count; j++)
            {
                // [[2,3],[4,5],[6,7],[8,9],[1,10]]
                
                if (current[0] <= min && current[1] > max)
                {
                    var count = result.Count;
                    for (int k = j; k < count; k++)
                    {
                        result.RemoveAt(0);
                    }

                    if (result.Count == 0)
                    {
                        result.Add(current);
                        found = true;
                        break;
                    }
                }

                //[1,3]
                var inTheseRange = result[j];
                // 3>2
                if (current[0] > inTheseRange[1])
                {
                    continue;
                }
                else if (current[0] < inTheseRange[0] && current[1] !< inTheseRange[0])
                {
                    var temp = result[j];
                    result[j] = current;
                    result.Add(temp);
                    found = true;
                    break;
                }
                else
                {
                    //2 < 1
                    if (current[0] <= inTheseRange[0])
                    {
                        result[j][0] = current[0];
                        //result[0] = [1, 6]
                    }

                    if (current[1] > inTheseRange[1])
                    {
                        result[j][1] = current[1];
                    }

                    min = Math.Min(min, result[j][0]);
                    max = Math.Max(max, result[j][1]);
                    found = true;
                    break;
                }

                // int[][] intervals = [[1, 3], [2, 6], [8, 10], [15, 18]];;
            }

            if (!found)
            {
                result.Add(current);
                max = current[1];
            }
        }

        for (int i = 0; i < result.Count - 1; i++)
        {
            if (result[i][1] <= result[i + 1][0])
            {
                result[i][1] = result[i + 1][1];
                result.RemoveAt(i + 1);
            }
        }
        for (int i = 0; i < result.Count - 1; i++)
        {
            if (result[i][0] >= result[i + 1][0] && result[i][1] <= result[i + 1][1])
            {
                result.RemoveAt(i);
            } 
        }
        
        for (int i = 0; i < result.Count; i++)
        {
            Console.WriteLine(result[i][0] + "," + result[i][1] + "\n");
        }
        return result.ToArray();
    }
    
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length == 0)
        {
            return [];
        }

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        List<int[]> result = [intervals[0]];    
        for (int i = 1; i < intervals.Length; i++)
        {
            var current = intervals[i];
            var last = result[^1];

            if (current[0] <= last[1])
            {
                last[1] = Math.Max(last[1], current[1]);
            }
            else
            {
                result.Add(current);
            }
        }
        
        return result.ToArray();
    }

    private int[][] Sort(int[][] intervals)
    {
        return intervals;
    }
}