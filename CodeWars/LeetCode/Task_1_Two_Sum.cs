namespace CodeWars.LeetCode
{
    /// <summary>
    ///     Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    ///     You may assume that each input would have exactly one solution, and you may not use the same element twice.
    ///     You can return the answer in any order.
    /// </summary>
    [TestFixture]
    public class Task_1_Two_Sum
    {
        private static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(new int[] { 2, 7, 11, 15 }, 9).Returns(new int[] { 0, 1 });
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public static int[] SolutionBad(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                var current = nums[i];
                for (var j = 0; j < nums.Length; j++)
                {
                    if (current + nums[j] == target)
                        return new int[] { i, j };
                }
            }

            return Array.Empty<int>();
        }


        [Test, TestCaseSource(nameof(TestCases))]
        public static int[] SolutionNormal(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var current = target - nums[i];
                if (dict.ContainsKey(current))
                    return new int[] { dict[current], i };

                dict[nums[i]] = i;
            }

            return Array.Empty<int>();
        }
    }
}
