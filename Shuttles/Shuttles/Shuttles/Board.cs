﻿using System;
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
        public const int boardWidth = 12; //left to right
        public const int boardHeight = 10; //top to bottom
        public BoardSquare[,] boardArray = new BoardSquare[boardWidth, boardHeight];

        //fills array with boardsquares
        public Board(int width, int height)
        {
            width = boardWidth;
            height = boardHeight;
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    boardArray[i , j] = new BoardSquare(i, j, BoardSquare.Wall.NONE, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
                }
            }
            boardArray[5, 9] = new BoardSquare(5, 9, BoardSquare.Wall.EAST, BoardSquare.Wall.NORTH, BoardSquare.Occupant.NONE);
            boardArray[4, 9] = new BoardSquare(4, 9, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[3, 8] = new BoardSquare(3, 8, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[2, 8] = new BoardSquare(2, 8, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[6, 9] = new BoardSquare(6, 9, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[8, 9] = new BoardSquare(8, 9, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[2, 2] = new BoardSquare(2, 2, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[3, 6] = new BoardSquare(3, 6, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[3, 3] = new BoardSquare(3, 3, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[4, 7] = new BoardSquare(4, 7, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[4, 6] = new BoardSquare(4, 6, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[4, 4] = new BoardSquare(4, 4, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[4, 3] = new BoardSquare(4, 3, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[4, 1] = new BoardSquare(4, 1, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[5, 7] = new BoardSquare(5, 7, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[5, 4] = new BoardSquare(5, 4, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[5, 2] = new BoardSquare(5, 2, BoardSquare.Wall.SOUTH, BoardSquare.Wall.EAST, BoardSquare.Occupant.NONE);
            boardArray[5, 1] = new BoardSquare(5, 1, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[5, 6] = new BoardSquare(5, 6, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[5, 5] = new BoardSquare(5, 5, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[5, 3] = new BoardSquare(5, 3, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[6, 8] = new BoardSquare(6, 8, BoardSquare.Wall.NORTH, BoardSquare.Wall.EAST, BoardSquare.Occupant.NONE);
            boardArray[6, 7] = new BoardSquare(6, 7, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[6, 3] = new BoardSquare(6, 3, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[6, 1] = new BoardSquare(6, 1, BoardSquare.Wall.EAST, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[7, 7] = new BoardSquare(7, 7, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[7, 5] = new BoardSquare(7, 5, BoardSquare.Wall.SOUTH, BoardSquare.Wall.WEST, BoardSquare.Occupant.NONE);
            boardArray[7, 4] = new BoardSquare(7, 5, BoardSquare.Wall.NORTH, BoardSquare.Wall.WEST, BoardSquare.Occupant.NONE);
            boardArray[7, 1] = new BoardSquare(7, 1, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[8, 7] = new BoardSquare(8, 7, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[8, 5] = new BoardSquare(8, 5, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NORTH, BoardSquare.Occupant.NONE);
            boardArray[8, 4] = new BoardSquare(8, 4, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[8, 1] = new BoardSquare(8, 1, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[9, 7] = new BoardSquare(9, 7, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[9, 5] = new BoardSquare(9, 5, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[9, 2] = new BoardSquare(9, 2, BoardSquare.Wall.WEST, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[10, 8] = new BoardSquare(10, 8, BoardSquare.Wall.NORTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
            boardArray[10, 2] = new BoardSquare(10, 2, BoardSquare.Wall.SOUTH, BoardSquare.Wall.NONE, BoardSquare.Occupant.NONE);
        }


                          
        }
    }

