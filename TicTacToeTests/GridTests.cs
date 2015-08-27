using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Tests
{
    [TestClass()]
    public class GridTests
    {
        Grid grid;

        [TestMethod()]
        public void SetSpotTests()
        {
            grid = new Grid();

            Assert.IsTrue(grid.setSpot(new Spot(), Pieces.X));
            Assert.IsFalse(grid.setSpot(new Spot(1, 1), Pieces.None));
        }
    }

    [TestClass()]
    public class SpotTests
    {
        Spot spot;

        [TestMethod()]
        public void NewSpotTests()
        {
            spot = new Spot();

            Assert.AreEqual(spot.x, 0);
            Assert.AreEqual(spot.y, 0);

            try
            {
                spot = new Spot(3, -1);
                Assert.Fail("Spot() failed to stop input");
            } catch(Exception) {}
        }
    }
}
