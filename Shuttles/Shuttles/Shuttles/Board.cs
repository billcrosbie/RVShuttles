using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Shuttles
{
    public class Board
    {
        //looking from piece end to piece end
        public const int boardWidth = 13; //left to right
        public const int boardHeight = 11; //top to bottom
        public BoardSquare[,] boardArray = new BoardSquare[boardWidth, boardHeight];
        int activePlayer = 1; 

        //fills array with boardsquares
        public Board()
        {
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    boardArray[i , j] = new BoardSquare(i, j, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 0);
                }
            }

            //set walls up manually
            boardArray[5, 9] = new BoardSquare(5, 9, BoardSquare.Wall.EAST, BoardSquare.Wall.NORTH, 0);
            boardArray[4, 9] = new BoardSquare(4, 9, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[3, 8] = new BoardSquare(3, 8, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, 0);
            boardArray[2, 8] = new BoardSquare(2, 8, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[6, 9] = new BoardSquare(6, 9, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, 0);
            boardArray[8, 9] = new BoardSquare(8, 9, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[2, 2] = new BoardSquare(2, 2, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, 0);
            boardArray[3, 6] = new BoardSquare(3, 6, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[3, 3] = new BoardSquare(3, 3, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, 0);
            boardArray[4, 7] = new BoardSquare(4, 7, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[4, 6] = new BoardSquare(4, 6, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[4, 4] = new BoardSquare(4, 4, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, 0);
            boardArray[4, 3] = new BoardSquare(4, 3, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, 0);
            boardArray[4, 1] = new BoardSquare(4, 1, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, 0);
            boardArray[5, 7] = new BoardSquare(5, 7, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[5, 4] = new BoardSquare(5, 4, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, 0);
            boardArray[5, 2] = new BoardSquare(5, 2, BoardSquare.Wall.SOUTH, BoardSquare.Wall.EAST, 0);
            boardArray[5, 1] = new BoardSquare(5, 1, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, 0);
            boardArray[5, 6] = new BoardSquare(5, 6, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, 0);
            boardArray[5, 5] = new BoardSquare(5, 5, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, 0);
            boardArray[5, 3] = new BoardSquare(5, 3, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, 0);
            boardArray[6, 8] = new BoardSquare(6, 8, BoardSquare.Wall.NORTH, BoardSquare.Wall.EAST, 0);
            boardArray[6, 7] = new BoardSquare(6, 7, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, 0);
            boardArray[6, 3] = new BoardSquare(6, 3, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[6, 1] = new BoardSquare(6, 1, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, 0);
            boardArray[7, 7] = new BoardSquare(7, 7, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, 0);
            boardArray[7, 5] = new BoardSquare(7, 5, BoardSquare.Wall.SOUTH, BoardSquare.Wall.WEST, 0);
            boardArray[7, 4] = new BoardSquare(7, 4, BoardSquare.Wall.NORTH, BoardSquare.Wall.WEST, 0);
            boardArray[7, 1] = new BoardSquare(7, 1, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, 0);
            boardArray[8, 7] = new BoardSquare(8, 7, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[8, 5] = new BoardSquare(8, 5, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NORTH, 0);
            boardArray[8, 4] = new BoardSquare(8, 4, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[8, 1] = new BoardSquare(8, 1, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, 0);
            boardArray[9, 7] = new BoardSquare(9, 7, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[9, 5] = new BoardSquare(9, 5, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[9, 2] = new BoardSquare(9, 2, BoardSquare.Wall.WEST, BoardSquare.Wall.NONE, 0);
            boardArray[10, 8] = new BoardSquare(10, 8, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, 0);
            boardArray[10, 2] = new BoardSquare(10, 2, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, 0);

            //put pieces in end rows
            //first group player1
            boardArray[4, 10] = new BoardSquare(4, 10, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 1);
            boardArray[5, 10] = new BoardSquare(4, 10, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 1);
            boardArray[6, 10] = new BoardSquare(4, 10, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 1);
            boardArray[7, 10] = new BoardSquare(4, 10, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 1);
            boardArray[8, 10] = new BoardSquare(4, 10, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 1);

            //second group player2
            boardArray[4, 0] = new BoardSquare(4, 0, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 2);
            boardArray[5, 0] = new BoardSquare(4, 0, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 2);
            boardArray[6, 0] = new BoardSquare(4, 0, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 2);
            boardArray[7, 0] = new BoardSquare(4, 0, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 2);
            boardArray[8, 0] = new BoardSquare(4, 0, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, 2);

            
        }

        //fills dictionary of valid moves for given direction
        //i.e. for String, should return all valid squares in which you can place your piece as a vector2
        public void fillMoveDict(int xCoord, int yCoord)
        {
            Dictionary<string, List<Vector2>> validDict = new Dictionary<string, List<Vector2>>();
            List<Vector2> validMoves = new List<Vector2>();

            //east first
            //currentsquare is where you are
            //checkedsquare is ideally where we are checking for jumps and what not
            for(int i = xCoord; i <= boardWidth; i++)
            {
                BoardSquare currentSquare = boardArray[xCoord, yCoord];
                BoardSquare checkedSquare  = boardArray[i, yCoord];
                
                if(currentSquare.getWall1().Equals(BoardSquare.Wall.EAST) || currentSquare.getWall2().Equals(BoardSquare.Wall.EAST))
                {
                    validMoves = validMoves;
                }
                else if(checkedSquare.getWall1().Equals(BoardSquare.Wall.EAST) || checkedSquare.getWall2().Equals(BoardSquare.Wall.EAST))
                {
                	validMoves
                }
                else if(checkedSquare.isOccupied() == true)
                {
                    if(checkedSquare.getPiece() == activePlayer)
                    {
                        validMoves = validMoves;
                    }
                    else if(checkedSquare.getPiece() != activePlayer)
                    {   
                        /*
                         * accounts for some weird conditions such as:
                         * jumping over player, jumping over player to find wall on other side, jumping over player to find other player on other side
                         */
                        if(checkedSquare.getWall1().Equals(BoardSquare.Wall.EAST) ||
                            checkedSquare.getWall2().Equals(BoardSquare.Wall.EAST) ||
                            checkedSquare.isOccupied() == true)
                        {
                            validMoves = validMoves;
                        }
                        else
                        {
                            validMoves.Add(new Vector2(checkedSquare.getX(), checkedSquare.getY()));
                        }



        }




















        public void moveShuttle(int row)
        {
            for (int i = 0; i <= boardWidth; i++)
            {
                boardArray[i, row] = boardArray[(i + 1), row];
            }
        }

        public int gameWon()
        {
            int winner = 0;
            if (boardArray[4, 0].getPiece() == 1 && boardArray[5, 0].getPiece() == 1 && boardArray[6, 0].getPiece() == 1 && boardArray[7, 0].getPiece() == 1 && boardArray[8, 0].getPiece() == 1)
            {
                winner = 1;
                return winner;
            }
            else if (boardArray[4, 10].getPiece() == 2 && boardArray[5, 10].getPiece() == 2 && boardArray[6, 10].getPiece() == 2 && boardArray[7, 10].getPiece() == 2 && boardArray[8, 10].getPiece() == 2)
            {
                winner = 2;
                return winner;
            }
            return winner;
        }



    }

}
                          

