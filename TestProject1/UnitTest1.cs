using ZartisRocketLander;
using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void When_PositionsAreInPlatform_ReturnOK()
        {
            //platform start at x=5, y=5, ends at x=15,y=15
            var myRocketLander = new RocketLander(100, 100, 10, 10, 5, 5);

            string actual1, actual2, actual3, actual4;
            var expectedOut = "out of platform";
            var expectedOK = "ok for landing";
            var expectedClash = "clash";


            actual2 = myRocketLander.QueryPosition(5, 6);
            Assert.Equal(actual2, expectedOK);
            actual3 = myRocketLander.QueryPosition(9, 9);
            Assert.Equal(actual3, expectedOK);
            actual1 = myRocketLander.QueryPosition(1, 5);
            Assert.Equal(actual1, expectedOut);
        }

        [Fact]
        public void When_PositionsAreOut_ReturnOut()
        {
            var myRocketLander = new RocketLander(100, 100, 10, 10, 5, 5);
            //platform start at x=5, y=5, ends at x=15,y=15
            string actual1, actual2, actual3, actual4;
            var expectedOut = "out of platform";

            actual1 = myRocketLander.QueryPosition(55, 6);
            Assert.Equal(actual1, expectedOut);
            actual2 = myRocketLander.QueryPosition(1, 6);
            Assert.Equal(actual2, expectedOut);
            actual3 = myRocketLander.QueryPosition(16, 9);
            Assert.Equal(actual3, expectedOut);
            actual4 = myRocketLander.QueryPosition(1, 5);
            Assert.Equal(actual4, expectedOut);
        }

        [Fact]
        public void When_PositionsAreTheSame_ReturnClash()
        {
            //platform start at x=5, y=5, ends at x=15,y=15
            var myRocketLander = new RocketLander(100, 100, 10, 10, 5, 5);

            string actual1, actual2, actual3, actual4;
            var expectedClash = "clash";


            actual1 = myRocketLander.QueryPosition(15, 15);
            actual2 = myRocketLander.QueryPosition(15, 15);
            Assert.Equal(expectedClash,actual2);

        }

        [Fact]
        public void When_PositionsHasNeighboor_OnDiagonal_ReturnClash()
        {
            //platform start at x=5, y=5, ends at x=15,y=15
            var myRocketLander = new RocketLander(100, 100, 10, 10, 5, 5);

            string actual1, actual2, actual3, actual4;
            var expectedClash = "clash";


            actual1 = myRocketLander.QueryPosition(14, 15);
            actual2 = myRocketLander.QueryPosition(15, 15);
            Assert.Equal(expectedClash, actual2);

        }

        [Fact]
        public void When_PositionsHasNeighboor_OnRightSide_ReturnClash()
        {
            //platform start at x=5, y=5, ends at x=15,y=15
            var myRocketLander = new RocketLander(100, 100, 10, 10, 5, 5);

            string actual1, actual2, actual3, actual4;
            var expectedClash = "clash";


            actual1 = myRocketLander.QueryPosition(12, 11); 
            actual2 = myRocketLander.QueryPosition(13, 11); //cell x=13 is right of x=12
            Assert.Equal(expectedClash, actual2);

        }

        [Fact]
        public void When_Positions_inLeftColumnHasNeighboor_AboveAndUnder_ReturnClash()
        {
            //platform start at x=5, y=5, ends at x=15,y=15
            var myRocketLander = new RocketLander(100, 100, 10, 10, 5, 5);

            string actual1, actual2, actual3, actual4;
            var expectedClash = "clash";


            actual1 = myRocketLander.QueryPosition(5, 13);
            actual2 = myRocketLander.QueryPosition(5, 15);
            actual3 = myRocketLander.QueryPosition(5, 14); //cell with row y=14 is between 13 and 15
            Assert.Equal(expectedClash, actual3);

        }

        [Fact]
        public void When_Positions_inMidleColumnHasNeighboor_AboveAndUnder_ReturnClash()
        {
            //platform start at x=5, y=5, ends at x=15,y=15
            var myRocketLander = new RocketLander(100, 100, 10, 10, 5, 5);

            string actual1, actual2, actual3, actual4;
            var expectedClash = "clash";


            actual1 = myRocketLander.QueryPosition(8, 10);
            actual2 = myRocketLander.QueryPosition(8, 12);
            actual3 = myRocketLander.QueryPosition(8, 11); //cell with row y=12 is between 10 and 11
            Assert.Equal(expectedClash, actual3);

        }

        [Fact]
        public void When_Positions_inTopLeftCornerHasNeighboor_LeftandUnder_ReturnClash()
        {
            //platform start at x=5, y=5, ends at x=15,y=15
            var myRocketLander = new RocketLander(100, 100, 10, 10, 5, 5);

            string actual1, actual2, actual3, actual4;
            var expectedClash = "clash";


            actual1 = myRocketLander.QueryPosition(6, 5);
            actual2 = myRocketLander.QueryPosition(5, 7);
            actual3 = myRocketLander.QueryPosition(5, 5); //cell 5,5 is in topLeft and has two neighboors, (6,5) (5,7) 
            Assert.Equal(expectedClash, actual3);

        }

        [Fact]
        public void When_Positions_inLeftColumnHasNeighboor_onRight_ReturnClash()
        {
            //platform start at x=5, y=5, ends at x=15,y=15
            var myRocketLander = new RocketLander(100, 100, 10, 10, 5, 5);

            string actual1, actual2, actual3, actual4;
            var expectedClash = "clash";



            actual2 = myRocketLander.QueryPosition(5, 7);
            actual3 = myRocketLander.QueryPosition(6, 7); //cell 6,7 is on the rightside of 5,7 and should not be occupied
            Assert.Equal(expectedClash, actual3);

        }
    }
}
