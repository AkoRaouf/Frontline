using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Frontline.Expression
{
    public class Lambda
    {
        public void TestIt()
        {
            Expression<Func<int, bool>> greaterThanN = value => value > 10;


        }
    }
}
