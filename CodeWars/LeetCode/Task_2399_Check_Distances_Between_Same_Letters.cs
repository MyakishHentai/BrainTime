using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.LeetCode
{
    [TestFixture]
    internal class Task_2399_Check_Distances_Between_Same_Letters
    {
        private static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData("abaccb", new int[] { 1, 3, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }).Returns(true);
                yield return new TestCaseData("aa", new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }).Returns(false);
                yield return new TestCaseData("zz", new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }).Returns(false);
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public bool Solution(string s, int[] distance)
        {
            var mapLetterToDist = new Dictionary<char, (int Index, int Cut)>(distance.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (mapLetterToDist.TryGetValue(s[i], out var value))
                {
                    if (value.Cut != i - value.Index - 1)
                        return false;
                    continue;
                }
                mapLetterToDist.Add(s[i], (Index: i, Cut: distance[s[i] - 97]));
            }

            return true;
        }
    }
}
