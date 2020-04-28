using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Base_Equlity
{
    public class MyCompare
    {
        private void ComapreDatetimes()
        {
            var dt1 = new DateTimeOffset(2010, 1, 1, 1, 1, 1, TimeSpan.FromHours(8));
            var dt2 = new DateTimeOffset(2010, 1, 1, 2, 1, 1, TimeSpan.FromHours(9));
            Console.WriteLine(dt1 == dt2); // True
            Console.WriteLine(dt1.Equals(dt2));
        } 

    }
}
