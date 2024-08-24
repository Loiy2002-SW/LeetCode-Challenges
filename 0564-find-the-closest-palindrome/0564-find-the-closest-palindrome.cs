public class Solution
{
  public string NearestPalindromic(string n)
  {
    if (n.Length == 1)
    {
      if (n == "0") return "1";
      return (int.Parse(n) - 1).ToString();
    }
    if (n.Length == 2)
    {
      var two = int.Parse(n);
      // for two digits every 11 is a palindrome
      if (two <= 11) return "9"; // 10 11
      if (two == 99) return "101";
      var lo = 11 * (two/11);
      if (lo == two)
        lo = 11 * ((two - 1) / 11);
      var up = 11 * (two/11+1);
      return (up - two < two - lo ? up : lo).ToString();
    }

    if (n.Length == 3)
    {
      if (n == "100" || n == "101") return "99";
      if (n == "999") return "1001";
      if (n == "998" || n == "997") return "999";
      if (n == "909") return "919";
      if (n == "808") return "818";
      if (n == "707") return "717";
      if (n == "606") return "606";
      if (n == "202") return "212";

    //   // 102 103 104 105 106 --> 101
    //   // 107 108 109 110 112
    //   // 111 --> 101
      var three = int.Parse(n);
      // if (three % 10 == 0) return (three + 1).ToString();
      // var x = (three / 10) + (three / 100);
      // // handle 111
      // if (x == three)
      // {
      //   if ((x/10)%10 == 0)
      //     return (x +10).ToString();
      //   return (x - 10).ToString();
      // }
      // 909 --> 919 or 898
    }
    
    
    var ori = long.Parse(n);
    var length = n.Length;
    // if (n == "9999") return "10001";
    // if (n == "99999") return "100001";
    if (n.Count(ch => ch == '9') == n.Count())
      return '1' + new string('0', length - 1) + '1';

    long leftHalf = long.Parse(n.Substring(0, (length +1)/2));
    long[] cand = new long[5];
    cand[0] = gPFL(leftHalf - 1, length % 2 == 0);
    cand[1] = gPFL(leftHalf, length % 2 == 0);
    cand[2] = gPFL(leftHalf + 1, length % 2 == 0);
    cand[3] = (long)Math.Pow(10, length - 1) - 1;
    cand[4] = (long)Math.Pow(10, length) - 1;

    long ans = long.MaxValue;
    long minDiff = long.MaxValue;
    foreach (var c in cand)
    {
      if (c == ori) continue;
      long diff = Math.Abs(c - ori);
      if (diff < minDiff || (diff == minDiff && c < ans))
      {
        ans = c;
        minDiff = diff;
      }
    }
    return ans.ToString();
  }
// generate P from left
  private long gPFL(long leftHalf, bool isEvenLength)
  {
    var pa = leftHalf;
    if (!isEvenLength)
      leftHalf /= 10;
    while (leftHalf > 0)
    {
      pa = pa * 10 + leftHalf % 10;
      leftHalf /= 10;
    }
    return pa;
  }
}