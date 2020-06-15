using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Delegate
{
    public static class Anonymous
    {
        public static void Caught()
        {
            var greaterThanN = new Predicate<int>[10];
            for (int i = 0; i < greaterThanN.Length; ++i)
            {
                var current = i;
                greaterThanN[i] = value => value > current; // Bad use of i
            }
            var aa = (greaterThanN[5](20));
            var cc = (greaterThanN[5](6));
        }
    }
}
