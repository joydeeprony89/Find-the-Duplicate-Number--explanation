using System;

namespace Find_the_Duplicate_Number
{
  class Program
  {
    /*
     * Take the array [1,3,4,2] as an example, the index of this array is [0, 1, 2, 3], we can map the index to the nums[n].
     *0->1
      1->3
      2->4
      3->2
    * 0->1->3->2->4->null
    * If there are a repeated numbers in the array, take the array [1,3,4,2,2] as an example,
    * 0->1
      1->3
      2->4
      3->2
      4->2
    *Similarly, a linked list is like this : 0->1->3->2->4->2->4->2->….......................
    *Here 2->4 is a cycle,
     */
    static void Main(string[] args)
    {
      var nums = new int[5] { 1, 3, 4, 2, 2 }; // 4, 3, 1, 4, 2
      Solution s = new Solution();
      var answer = s.Find(nums);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int FindDuplicate(int[] nums)
    {
      int slow = 0;
      int fast = 0;
      do
      {
        slow = nums[slow];
        fast = nums[nums[fast]];
      } while (slow != fast);

      slow = 0;
      while(slow != fast)
      {
        slow = nums[slow];
        fast = nums[fast];
      }

      return slow;
    }

    public int Find(int[] nums)
    {
      int ans = int.MinValue;
      for (int i = 0; i < nums.Length; i++)
      {
        var idx = nums[i];
        idx = Math.Abs(idx);
        var val = nums[idx];
        if (val < 0)
        {
          ans = idx;
          break;
        }
        nums[idx] = val * -1;
      }
      return ans;
    }
  }
}
