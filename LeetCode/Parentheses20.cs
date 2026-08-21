namespace LeetCode;

public class Parentheses20
{
    public Parentheses20(string testCase)
    {
        Execute(testCase);
    }
    //
    // private Dictionary<char, Tuple<char,int>> _pairs = new Dictionary<char, Tuple<char,int>>()
    // {
    //     { '{', new Tuple<char, int>('}', 0) },
    //     { '(', new Tuple<char, int>(')', 0) },
    //     { '[', new Tuple<char, int>(']', 0) },
    //     { '}', new Tuple<char, int>('{', 0) },
    //     { ')', new Tuple<char, int>('(', 0) },
    //     { ']', new Tuple<char, int>('[', 0) },
    // };
    //
    private bool Execute(string testCase)
    {
        var result = true;
        var open = new char[] { '{', '(', '[' };
        var close = new char[] { '}', ')', ']' };
        var openPairCounter = new Dictionary<char, int>()
        {
            { '{', 0 },
            { '(', 0 },
            { '[', 0 },
        };
        var closeToOpenPair = new Dictionary<char, char>()
        {
            { '}', '{' },
            { ')', '(' },
            { ']', '[' },
        };
        var total = 0;
        Stack<char> lastOpenPair = new Stack<char>();
        for (int i = 0; i < testCase.Length; i++)
        {
            var ch = testCase[i];
            if (open.Contains(ch))
            {
                total++;
                openPairCounter[ch] = openPairCounter[ch]+1;
                lastOpenPair.Push(ch);
                continue;
            }
            
            if (close.Contains(ch))
            {
                var openCh = closeToOpenPair[ch];
                if (openPairCounter[openCh] == 0)
                {
                    return false;
                }

                var lop = lastOpenPair.Pop();
                if (lop != openCh)
                {
                    return false;
                }
                
                openPairCounter[openCh] = openPairCounter[openCh]-1;
                total--;
            }
        }
        
        Console.WriteLine($"Result = {result}");
        return total == 0;
    }
    
    private bool ExecuteV2(string testCase)
    {
        if (testCase.Length % 2 != 0 || testCase.Length < 2)
        {
            return false;
        }
        
        var lastOpenPair = new Stack<char>();
        var closeToOpenPair = new Dictionary<char, char>()
        {
            { '}', '{' },
            { ')', '(' },
            { ']', '[' },
        };
        
        for (int i = 0; i < testCase.Length; i++)
        {
            if (testCase[i] is '{' or '[' or '(')
            {
                lastOpenPair.Push(testCase[i]);
                continue;
            }

            if (lastOpenPair.Count == 0)
            {
                return false;
            }
            
            if (lastOpenPair.Pop() != closeToOpenPair[testCase[i]])
            {
                return false;
            }
        }
        
        return lastOpenPair.Count == 0;
    }
}