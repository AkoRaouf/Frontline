using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Delegate
{
    public class TestClass
    {
        public int GetIndexOfFirtsNonEmptyBin(int[] Bins) => Array.FindIndex(Bins, IsGreaterThanZero);

        public int GetIndexOfFirtsNonEmptyBinlambda(int[] Bins) => Array.FindIndex(Bins, value => value > 0);

        private bool IsGreaterThanZero(int value) => value > 0;

        private Predicate<int> IsGreaterThanZeroP(int threshold)
        {
            return value => value > threshold;
        }
        private Predicate<int> IsGreaterThanZeroPp(int threshold) => value => value > 0;

        public void FindMyItem()
        {
            var p = new Predicate<int>(IsGreaterThanZero);
            p.Invoke(10);

            Func<int, bool> func = IsGreaterThanZero;
            var res = func(1);

            Predicate<string> isEq = s => s == "1";

            DoMyPredicate(10, s => s == 1);
        }

        public void DoMyPredicate<T>(T aa, Predicate<T> predicate) { }

        public void DoMyFunc<T>(Func<T, bool> func)
        {

        }
    }
}
