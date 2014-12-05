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

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
         Vector2 gameBoardDisplayOrigin = new Vector2(60, 60);
        Vector2 GamePiece = new Vector2(60, 60);
        Vector2 currentPiece = new Vector2(60, 60);
        Vector2 theBoard = new Vector2(600, 600);
        Texture2D highlight;
        Texture2D board;
        Texture2D peg;
        Rectangle boardRect = new Rectangle(0, 0, 600, 600);
        Rectangle thePeg = new Rectangle(0, 0, 60, 60);
        Rectangle mouseRect;


        Boolean canMoveY = true;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            board = Content.Load<Texture2D>(@"Textures\board");
            highlight = Content.Load<Texture2D>(@"Textures\highlight.fw");
            peg = Content.Load<Texture2D>(@"Textures\peg.fw");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            HandleMouseInput(Mouse.GetState());
          
            base.Update(gameTime);
        }
           private void HandleMouseInput(MouseState mouseState)
        {

            int x = ((mouseState.X -
                (int)gameBoardDisplayOrigin.X));

            int y = ((mouseState.Y -
                (int)gameBoardDisplayOrigin.Y));

               Vector2 mouseLocation = new Vector2(x, y);
               int tempX = x % 60;
               int tempY = y % 60;

               if (mouseLocation.X %60 < 30)
               {
                   mouseLocation.X -= tempX;
               }
               if (mouseLocation.X % 60 >= 30)
               {
                   mouseLocation.X += (60 - tempX);
               }
                if (mouseLocation.Y % 60 < 30)
               {
                   mouseLocation.Y -= tempY;
               }
               if (mouseLocation.Y % 60 >= 30)
               {
                   mouseLocation.Y += (60 - tempY);
               }

               int rectangleX = (int)mouseLocation.X;
               int rectangleY = (int)mouseLocation.Y;
               mouseRect = new Rectangle(rectangleX, rectangleY, 60, 60);
               this.Window.Title = ("Mouse X " + mouseLocation.X + " Mouse Y " + mouseLocation.Y);

               if (mouseState.LeftButton == ButtonState.Pressed)
               {
                   int currentX = (int)mouseLocation.X;
                   int currentY = (int)mouseLocation.Y;
                   int pegX = (int)thePeg.X;
                   int pegY = (int)thePeg.Y;

                   if (mouseRect.Equals(thePeg))
                   {
                       if (currentY.Equals(pegY))
                       {
                           canMoveY = false;
                           if (!canMoveY)
                           {
                               mouseLocation.Y = pegY;
                           }
                       }
                   }
               }
           }

       
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(board, boardRect, Color.White);
            spriteBatch.Draw(peg, thePeg, Color.White);
            spriteBatch.Draw(highlight, mouseRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
