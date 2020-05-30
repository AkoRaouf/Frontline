using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Delegate
{
    public class TestClass
    {
        public static int GetIndexOfFirtsNonEmptyBin(int[] Bins) => Array.FindIndex(Bins, IsGreaterThanZero);

        private static bool IsGreaterThanZero(int value) => value > 0;

        public static void FindMyItem()
        {
            var p = new Predicate<int>(IsGreaterThanZero);
            p.Invoke(10);

            Func<int, bool> func = IsGreaterThanZero;
            var res = func(1);
        }
    }
}
