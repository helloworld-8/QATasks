using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    public class NASASecretMath
    {
        public int Max(int x, int y)
        {
            if (x > y)
            {
                return x;
            }
            else if (x < y)
            {
                return y;
            } else
            {
                return x;
            }
        }
    }


    [TestFixture]
    class NASASecretMathTests
    {
        private readonly NASASecretMath _NASASecretMath = new NASASecretMath();
        private static IEnumerable<TestCaseData> Should_Return_Highest_Value_TestData
        {
            get
            {
                yield return new TestCaseData(1, 2, 2);
                yield return new TestCaseData(-10, -5, -5);
                yield return new TestCaseData(10000, 25555, 25555);
                yield return new TestCaseData(-10000, -25555, -10000);
                yield return new TestCaseData(126547, 1215, 126547);
                yield return new TestCaseData(-100151854847, 100, 100);
                yield return new TestCaseData(100151854847, -4847878788, 100151854847);
            }
        }

        [Test, TestCaseSource(nameof(Should_Return_Highest_Value_TestData))]
        public void Should_Return_Highest_Value(int x, int y, int expectedResult)
        {
            int result = this._NASASecretMath.Max(x, y);
            Assert.AreEqual(expectedResult, result, "Expected result and calculated result are not equal");
        }


        [Test]
        public void Should_Filter_Out_Any_Negative_Values()
        {
            int[] xValues = new int[300];
            int[] result = new int[300];
            int yValue = 0;

            for (int i = 0; i < 300; i++)
            {
                xValues[i] = Convert.ToInt32(Math.Sin(i * 180 / 3.1459) * i);
                result[i] = this._NASASecretMath.Max(xValues[i], yValue);
                Assert.IsTrue(result[i] >= yValue, "Not all negative values are filtered out");
            }
        }


    }
}
