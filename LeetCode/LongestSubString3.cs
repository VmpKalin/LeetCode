namespace LeetCode;

public class LongestSubString3
{
    public LongestSubString3(string str)
    {
        
        Console.WriteLine(Execute(str));
    }

    private int Execute(string str)
    {
        str = "bpfbhmipx";
        var set = new Dictionary<char, int>();
        var lastSymbol = char.MinValue;
        var maxCounter = 0;
        var left = 0;
        for (int i = 0; i < str.Length; i++)
        {
            var ch = str[i];
            if (!set.TryAdd(ch, i))
            {
                if (set.Count > maxCounter)
                {
                    maxCounter = set.Count;
                }

                if (lastSymbol == ch)
                {
                    set.Clear();
                    set.Add(ch, i);
                    lastSymbol = str[i];
                    continue;
                }

                var symbolIndexToDeleteTo = set[ch];
                if (symbolIndexToDeleteTo > 0)
                {
                    for (int j = left; j <= symbolIndexToDeleteTo; j++)
                    {
                        var chToDelete = str[j];
                        set.Remove(chToDelete);
                    }    
                }

                left = symbolIndexToDeleteTo + 1;

                set[ch] = i;
            }
            
            lastSymbol = str[i];
        }

        return maxCounter < set.Count ? set.Count : maxCounter;
    }
    
    private int ExecuteV2(string str)
    {
        str = "bpfbhmipx";
        var set = new Dictionary<char, int>();
        var maxCounter = 0;
        var left = 0;

        for (int i = 0; i < str.Length; i++)
        {
            var ch = str[i];
    
            if (!set.TryAdd(ch, i))
            {
                maxCounter = Math.Max(maxCounter, set.Count);

                var symbolIndexToDeleteTo = set[ch];
        
                // Видаляємо від left до дубліката включно
                for (int j = left; j <= symbolIndexToDeleteTo; j++)
                {
                    set.Remove(str[j]);
                }
        
                left = symbolIndexToDeleteTo + 1;
                set.Add(ch, i);
            }
        }

        return Math.Max(maxCounter, set.Count);
    }
    
    
}