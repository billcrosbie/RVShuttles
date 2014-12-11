using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shuttles
{
    public class BoardSquare
    {
        public int xLocation;
        public int yLocation;
        public enum Wall {NORTH, EAST, SOUTH, WEST, NONE};
        public enum Occupant { PLAYER1, PLAYER2, NONE };
        Wall iswall1 = Wall.NONE;
        Wall iswall2 = Wall.NONE;
        Occupant whosPiece;

        public BoardSquare(int xCoord, int yCoord, Wall wall1, Wall wall2, Occupant currentPiece)
        {
            xLocation = xCoord;
            yLocation = yCoord;
            wall1 = iswall1;
            wall2 = iswall2;
            whosPiece = currentPiece;
        }

        public void setWall(Wall wallDirection1, Wall wallDirection2)
        {
            iswall1 = wallDirection1;
            iswall2 = wallDirection2;
        }
    }
}
