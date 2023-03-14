using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shouldly;
using BH.oM.Maths;
using BH.Engine.Maths;
using NUnit.Framework;

namespace BH.Tests.Maths
{
    public class MatrixSize
    {
        [SetUp]
        public void SetUp()
        {
            BH.Engine.Base.Compute.ClearCurrentEvents();
        }

        [Test]
        public void ColumnCount()
        {
            List<List<double>> values = new List<List<double>>();
            values.Add(new List<double>() { 1, 2, 3 });

            Matrix matrix = new Matrix();
            matrix.Values = values;

            int cols = matrix.MatrixNumberOfColumns();
            cols.ShouldBe(3);

            Random rand = new Random();
            int max = rand.Next(1, 100);
            for(int x = 0; x < max; x++)
                values[0].Add((double)x);

            matrix.Values = values;
            cols = matrix.MatrixNumberOfColumns();
            cols.ShouldBe(values[0].Count);
        }

        [Test]
        public void RowCount()
        {
            List<List<double>> values = new List<List<double>>();
            values.Add(new List<double>() { 1, 2, 3 });
            values.Add(new List<double>() { 1, 2, 3 });

            Matrix matrix = new Matrix();
            matrix.Values = values;

            int rows = matrix.MatrixNumberOfRows();
            rows.ShouldBe(2);

            Random rand = new Random();
            int max = rand.Next(1, 100);
            for (int x = 0; x < max; x++)
                values.Add(new List<double>() { 1, 2, 3 });

            matrix.Values = values;
            rows = matrix.MatrixNumberOfRows();
            rows.ShouldBe(values.Count);
        }

        [Test]
        public void TestFullSize()
        {
            List<List<double>> values = new List<List<double>>();
            values.Add(new List<double>() { 1, 2, 3 });
            values.Add(new List<double>() { 1, 2, 3 });

            Matrix matrix = new Matrix();
            matrix.Values = values;

            var size = matrix.MatrixSize();
            size.Item1.ShouldBe(3);
            size.Item2.ShouldBe(2);

            Random rand = new Random();
            int max = rand.Next(1, 100);
            int max2 = rand.Next(1, 50);
            values = new List<List<double>>();
            for (int x = 0; x < max; x++)
            {
                List<double> moreVals = new List<double>();
                for(int y = 0; y < max2; y++)
                {
                    moreVals.Add((double)y);
                }
                values.Add(moreVals);
            }

            matrix.Values = values;
            size = matrix.MatrixSize();
            size.Item1.ShouldBe(values[0].Count);
            size.Item2.ShouldBe(values.Count);
        }
    }
}
