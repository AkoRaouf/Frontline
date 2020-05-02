using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Base_Equlity
{
    public class MyCompare
    {
        public void ComapreDatetimes()
        {
            var dt1 = new DateTimeOffset(2010, 1, 1, 1, 1, 1, TimeSpan.FromHours(8));
            var dt2 = new DateTimeOffset(2010, 1, 1, 2, 1, 1, TimeSpan.FromHours(9));
            var res1 = (dt1 == dt2); // True
            var res2 = (dt1.Equals(dt2));
        }

        class foo { public int X; }
        public void ObjectComare()
        {
            var f1 = new foo();
            var f2 = new foo();
            var f3 = f2;
            var res1 = f1 == f2;
            var res2 = f1.Equals(f2);
            var res3 = f2.Equals(f3);
        }

        public void UrlEquality()
        {
            Uri uri1 = new Uri("http://www.google.com");
            Uri uri2 = new Uri("http://www.google.com");
            var res = uri1.Equals(uri2);
            var res2 = uri1 == uri2;
        }

        public void Hardwire()
        {
            //Compiler hard-wire to int comparison.
            int x = 5;
            int y = 5;
            var res = x == y;

            //Compiler hrad-wire to the object comaprison. because xo and yo are objects the object 
            object xo = 5;
            object yo = 5;
            var res2 = xo == yo;
            var res3 = xo.Equals(yo); //At runtime the type is resolved as int, therefore the equality is done based on value type.
        }

        public void EqualityComplexsity()
        {
            object x = 3, y = 3;

            var res1 = object.Equals(x, y);

            x = null;
            var res2 = object.Equals(x, y);

            y = null;
            var res3 = object.Equals(x, y);
        }

        public class Test<T>
        {
            T _value;
            public void SetValue(T newValue)
            {
                if(object.Equals(_value, newValue))
                    _value = newValue;

                EqualityComparer<T>.Default.Equals(_value, newValue);
            }
        }

    }
}