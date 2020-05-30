using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            string st = "aa";
            string st2 = "aa";

            StringBuilder stringBuilder1 = new StringBuilder("aa");
            StringBuilder stringBuilder2 = new StringBuilder("aa");

            var res7 = stringBuilder1 == stringBuilder2;
            var res8 = stringBuilder1.Equals(stringBuilder2);

            var res5 = st == st2;
            var res6 = st.Equals(st2);

            var res4 = 5.Equals(5);
            object x = 3, y = 3;

            var res1 = object.Equals(x, y);

            x = null;
            var res2 = object.Equals(x, y);

            y = null;
            var res3 = object.Equals(x, y);
        }

        public class Test<T> : IEquatable<T>
        {
            T _value;
            public void SetValue(T newValue)
            {
                if(object.Equals(_value, newValue))
                    _value = newValue;

                EqualityComparer<T>.Default.Equals(_value, newValue);
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public bool Equals(T other)
            {
                return this.Equals(other);
            }
        }

        public class TestEquality<T> where T : IEquatable<T>
        {
            public bool IsEqual(T a, T b)
            {
                return a.Equals(b);
            }
        }

        public class EqualityEntrance1<T> : IEquatable<T>
        {
            public int a;

            public bool Equals([AllowNull] T other)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class A
    {
        int a;
        public B MyB { get; set; }
        
    }
    public class B
    {

    }
}