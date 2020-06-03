using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.CovarianceAndContravariance
{
    public class TestClass
    {
        public void TestMethod()
        {
            // Assignment compatibility.
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type.
            object obj = str;

            // Covariance.
            IEnumerable<string> strings = new List<string>();

            // An object that is instantiated with a more derived type argument
            // is assigned to an object instantiated with a less derived type argument.
            // Assignment compatibility is preserved.
            IEnumerable<object> objects = strings;

            // Contravariance.
            // Assume that the following method is in the class:
            static void SetObject(object o) { }
            Action<object> actObject = SetObject;
            // An object that is instantiated with a less derived type argument
            // is assigned to an object instantiated with a more derived type argument.
            // Assignment compatibility is reversed.
            Action<string> actString = actObject;
        }

        public void TestMethod2()
        {
            object[] array = new String[10];
            // The following statement produces a run-time exception.  
            // array[0] = 10;  
        }

         object GetObject() { return null; }
         void SetObject(object obj) { }

         string GetString() { return ""; }
        void SetString(string str) { }

        public void TestMethodForDelegate()
        {
            // Covariance. A delegate specifies a return type as object,  
            // but you can assign a method that returns a string.  
            Func<object> fn = GetString;

            // Contravariance. A delegate specifies a parameter type as string,  
            // but you can assign a method that takes an object.  
            Action<string> ac = SetObject;
        }

        public void TestMethodForInterfaceAndDelegate()
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();

            string str = "adsasd";

        }
    }

    
}
