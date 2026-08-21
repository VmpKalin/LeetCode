namespace LeetCode;

public class NumberOfIslands
{
    /* Input:       Output:
     * 1 1 1 0 1    3
       1 1 0 0 1
       1 0 1 0 0 

       Input:
       1 1 1        Output:
       1 1 0        2
       1 0 1
     */
    public int NumIslands(char[][] grid)
    {
        if (grid.Length < 1 || grid[0].Length < 1)
        {
            throw new ArgumentOutOfRangeException();
        }

        var result = 0;
        int i = 0;
        while (i != grid.Length)
        {
            int j = 0;
            while (j != grid[i].Length)
            {
                if (grid[i][j] == '1')
                {
                    result++;
                    // BFS:
                    DestroyIslandV1(grid, i, j);
                    
                    // DFS:
                    // In this case it's 2 times faster
                    // SinkV2(grid, i, j); //With recursive it's faster, but we should think about call stack, to not create out of memory ex 
                }
                j++;
            }
            i++;
        }

        return result;
    }

    static int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    private static void DestroyIslandV1(char[][] grid, int i, int j)
    {
        var head = new Queue<(int row,int col)>();
        grid[i][j] = '0';
        head.Enqueue((i, j));
        while (head.Count > 0)
        {
            var current = head.Dequeue();
            // BFS
            SinkV1(grid, current, head);
        }
    }

    private static void SinkV2(char[][] grid, int row, int col)
    {
        if ((row < 0 || row >= grid.Length ||
             col < 0 || col >= grid[row].Length) ||
            grid[row][col] != '1') 
        {
            return;
        }

        grid[row][col] = '0';
        
        SinkV2(grid, row+1, col);
        SinkV2(grid, row-1, col);
        SinkV2(grid, row, col+1);
        SinkV2(grid, row, col-1);
    }

    private static void SinkV1(char[][] grid, (int row, int col) current, Queue<(int row,int col)> head)
    {
        foreach (var dir in directions)
        {
            var newRow = current.row + dir[0];
            var newCol = current.col + dir[1];
            
            if (newRow >= 0 && newRow < grid.Length &&
                newCol >= 0 && newCol < grid[newRow].Length &&
                grid[newRow][newCol] == '1')
            {
                grid[newRow][newCol] = '0';
                head.Enqueue((newRow, newCol));
            }
        }
    }
}