using System;
using System.Collections.Generic;
using System.Linq;

namespace Shuttles
{
    public class BoardSquare
    {
        public int xLocation;
        public int yLocation;
        public enum Wall {NORTH, EAST, SOUTH, WEST, NONE};
        //should be 0 for empty, 1 for player 1, 2 for player 2
        public int piece;
        Wall wall1 = Wall.NONE;
        Wall wall2 = Wall.NONE;

        public BoardSquare(int xCoord, int yCoord, Wall iswall1, Wall iswall2, int currentPiece)
        {
            xLocation = xCoord;
            yLocation = yCoord;
            iswall1 = wall1;
            iswall2 = wall2;
            piece = currentPiece;
            if (currentPiece < 0 || currentPiece > 2)
            {
                piece = 0;
            }
        }

        public void setWall(Wall wallDirection1, Wall wallDirection2)
        {
            wall1 = wallDirection1;
            wall2 = wallDirection2;
        }

        public Wall getWall1()
        {
            return wall1;
        }
        public Wall getWall2()
        {
            return wall2;
        }

        public int getPiece()
        {
            return piece;
        }

        public void setPiece(int forWhom)
        {
            //lol at that name
            piece = forWhom;
            if (forWhom < 0 || forWhom > 2)
            {
                piece = 0;
            }
        }

        public int getRow()
        {
            return yLocation;
        }

        public int getColumn()
        {
            return xLocation;
        }

        public bool isOccupied()
        {
            bool full = false;
            if (getPiece() == 0)
                return full;
            else
            {
                full = true;
                return full;
            }
        }
                




    }
}
