namespace LeetCode;

public class FloodFillTask
{
    public FloodFillTask(int[][] image, int sr, int sc, int color)
    {
        OutputMatrix(image);
        FloodFill(image, sr, sc, color);
        Console.WriteLine();
        OutputMatrix(image);
    }
    /*
     * 1 1 1 
       1 1 0 
       1 0 1 
       
       2 2 2 
       2 2 0 
       1 0 1 
     */
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        
        if (image[sr][sc] == color) return image;
        var defaultColor = image[sr][sc];
        image[sr][sc] = color;
        Queue<int[]> head = new Queue<int[]>();
        head.Enqueue([sr, sc]);
        var total = 0;
        
        while (head.Count != 0)
        {
            var current = head.Dequeue();
            var x = current[0];
            var y = current[1];
            
            //up
            if (x-1 >= 0)
            {
                if (image[x-1][y] == defaultColor)
                {
                    image[x-1][y] = color;
                    head.Enqueue([x-1,y]);
                }
            }
            //down
            if (x+1 < image.Length)
            {
                if (image[x+1][y] == defaultColor)
                {
                    image[x+1][y] = color;
                    head.Enqueue([x+1,y]);
                }
            }

            //right
            if (y+1 < image[x].Length)
            {
                if (image[x][y+1] == defaultColor)
                {
                    image[x][y+1] = color;
                    head.Enqueue([x, y+1]);
                }
            }
            //left
            if (y-1 >= 0)
            {
                if (image[x][y-1] == defaultColor)
                {
                    image[x][y-1] = color;
                    head.Enqueue([x,y-1]);
                }
            }


            total++;
            if (total == ((image.Length * image[0].Length) - 1))
            {
                break;
            }
        }
        
        return image;
    }
    private void OutputMatrix(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int m = 0; m < matrix[i].Length; m++)
            {
                Console.Write(matrix[i][m] + " ");
            }
            Console.WriteLine();
        }
    }
}