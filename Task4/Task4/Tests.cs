using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Triangle
    {
        public enum TriangleType
        {
            Scalene, // įvairiakraštis
            Isosceles, // lygiašonis
            Equilateral // lygiagraštis
        }

        public TriangleType GetTriangleType(int a, int b, int c)
        {
            if (a == b && b == c)
            {
                return TriangleType.Equilateral;
            }
            else if (a == b || a == c || b == c)
            {
                return TriangleType.Isosceles;
            }
            else
            {
                return TriangleType.Scalene;
            }
        }
    }

    [TestFixture]
    public class TriangleTests
    {
        private readonly Triangle triangle = new Triangle();

        [TestCase(10, 10, 10)]
        public void Should_Be_Equilateral_Triangle(int a, int b, int c)
        {
            Assert.AreEqual(Triangle.TriangleType.Equilateral, triangle.GetTriangleType(a, b, c));
        }

        [TestCase(10, 10, 20)]
        public void Should_Be_Isosceles_Triangle(int a, int b, int c)
        {
            Assert.AreEqual(Triangle.TriangleType.Isosceles, triangle.GetTriangleType(a, b, c));
        }

        [TestCase(10, 20, 30)]
        public void Should_Be_Scalene_Triangle(int a, int b, int c)
        {
            Assert.AreEqual(Triangle.TriangleType.Scalene, triangle.GetTriangleType(a, b, c));
        }

    }
}
