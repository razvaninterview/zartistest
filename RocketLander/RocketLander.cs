using System;

namespace ZartisRocketLander
{
    public class RocketLander : IRocketLander
    {
        private int platformXstart, platformXend, platformYstart, platformYend; //// platform size
        private bool[,] visited; //array to check previous Rocket positions


        /// <summary>
        /// platformX and platformY are the Platform's starting position
        /// </summary>
        /// <param name="areaLength"></param>
        /// <param name="areaWidth"></param>
        /// <param name="platformLength"></param>
        /// <param name="platformWidth"></param>
        /// <param name="platformX"></param>
        /// <param name="platformY"></param>
        public RocketLander(int areaLength, int areaWidth, int platformLength, int platformWidth, int platformX , int platformY)
        {
            this.platformXstart = platformX;
            this.platformXend = platformXstart + platformLength;

            this.platformYstart = platformY;
            this.platformYend = platformYstart + platformWidth;

            this.visited = new bool[areaLength, areaWidth]; // can be optimized to platform size;
        }

        public string QueryPosition(int x, int y)
        {
            if (!PositionOnPlatform(x, y))
                return "out of platform";
            else if (PositionOnPlatform(x, y))
            {
                if (visited[x, y])
                    return "clash";
                else if( !PositionHasNeighboors(x,y))
                {
                    visited[x, y] = true;
                    return "ok for landing";
                }
            }

            return "clash";

            //question: if several consecutive positions are identical but out of platform, will I return "out of platform"?
        }

        private bool PositionOnPlatform(int x, int y)
        {
            if (x >= platformXstart && x <= platformXend && y >= platformYstart && y <= platformYend)
                return true;
            return false;
        }

        /// <summary>
        /// we check for previous positions only on the platform
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool PositionHasNeighboors(int x, int y)
        {
            //init cell check range
            int startX, endX, startY, endY;

            startX = x - 1;
            endX = x + 1;
            startY = y - 1;
            endY = y + 1;

            //corner cases for top,botton lines and columns
            if (x == platformXstart)
                startX = x;
            if (x == platformYend)
                endX = x;
            if (y == platformYstart)
                startY = y;
            if (y == platformYend)
                endY = y;

            for (int i = startX; i <= endX; i++)
            {
                for (int j = startY; j <= endY; j++)
                {
                    if (i == x && j == y)
                    {
                        continue;
                    }
                    if (visited[i, j] == true)
                        return true;
                }
            }

            return false;
        }
    }
}
