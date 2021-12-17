using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Animation2D;

namespace Snakes_and_Ladders_to_haven
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>

        public class Keyboard
{
    static KeyboardState currentKeyState;
    static KeyboardState previousKeyState;

    public static KeyboardState GetState()
    {
        previousKeyState = currentKeyState;
        currentKeyState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        return currentKeyState;
    }

    public static bool IsPressed(Keys key)
    {
        return currentKeyState.IsKeyDown(key);
    }

    public static bool HasBeenPressed(Keys key)
    {
        return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
    }
}
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        int screenWidth;
        int screenHeight;

        Texture2D SnakeBackground;
        Rectangle SnakeRectangle;
        SpriteFont titleFont;
        Texture2D pressStart;
        Rectangle pressRec;
        Song bgMusic;
        Vector2 titleLoc = new Vector2(50, 20);
       

        Texture2D boardGame;
        Rectangle boardRectangle;
        Texture2D picbRedPawn;
        Rectangle picbRedRec;
        Texture2D picbBluePawn;
        Rectangle picbBlueRec;
       
        bool inMenu = true;
        bool theBoardGame = true;

        Vector2[] spaceLoc = new Vector2[100]; 
        int p1space = 1;
        int p2space = 1;
        static int playerXVictory = 0;

       

        Random rng = new Random();
        int dice = 1;
        KeyboardState kb;

  


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

            screenWidth = graphics.GraphicsDevice.Viewport.Width;
            screenHeight = graphics.GraphicsDevice.Viewport.Height;

           
                spaceLoc[1] = new Vector2(20, 420);
                spaceLoc[2] = new Vector2(25, 420);
                spaceLoc[3] = new Vector2(30, 420);
                spaceLoc[4] = new Vector2(35, 420);
                spaceLoc[5] = new Vector2(40, 420);
                spaceLoc[6] = new Vector2(45, 420);
                spaceLoc[7] = new Vector2(50, 420);
                spaceLoc[8] = new Vector2(55, 420);
                spaceLoc[9] = new Vector2(60, 420);
                spaceLoc[10] = new Vector2(65, 420);
                spaceLoc[11] = new Vector2(65, 380);
                spaceLoc[12] = new Vector2(60, 380);
                spaceLoc[13] = new Vector2(55, 380);
                spaceLoc[14] = new Vector2(50, 380);
                spaceLoc[15] = new Vector2(45, 380);
                spaceLoc[16] = new Vector2(40, 380);
                spaceLoc[17] = new Vector2(35, 380);
                spaceLoc[18] = new Vector2(30, 380);
                spaceLoc[19] = new Vector2(25, 380);
                spaceLoc[20] = new Vector2(20, 380);
                spaceLoc[21] = new Vector2(20, 340);
                spaceLoc[22] = new Vector2(25, 340);
                spaceLoc[23] = new Vector2(30, 340);
                spaceLoc[24] = new Vector2(35, 340);
                spaceLoc[25] = new Vector2(40, 340);
                spaceLoc[26] = new Vector2(45, 340);
                spaceLoc[27] = new Vector2(50, 340);
                spaceLoc[28] = new Vector2(55, 340);
                spaceLoc[29] = new Vector2(60, 340);
                spaceLoc[30] = new Vector2(65, 340);
                spaceLoc[31] = new Vector2(65, 300);
                spaceLoc[32] = new Vector2(60, 300);
                spaceLoc[33] = new Vector2(55, 300);
                spaceLoc[34] = new Vector2(50, 300);
                spaceLoc[35] = new Vector2(45, 300);
                spaceLoc[36] = new Vector2(40, 300);
                spaceLoc[37] = new Vector2(35, 300);
                spaceLoc[38] = new Vector2(30, 300);
                spaceLoc[39] = new Vector2(25, 300);
                spaceLoc[40] = new Vector2(20, 300);
                spaceLoc[41] = new Vector2(20, 260);
                spaceLoc[42] = new Vector2(25, 260);
                spaceLoc[43] = new Vector2(30, 260);
                spaceLoc[44] = new Vector2(35, 260);
                spaceLoc[45] = new Vector2(40, 260);
                spaceLoc[46] = new Vector2(45, 260);
                spaceLoc[47] = new Vector2(50, 260);
                spaceLoc[48] = new Vector2(55, 260);
                spaceLoc[49] = new Vector2(60, 260);
                spaceLoc[50] = new Vector2(65, 260);           
                spaceLoc[51] = new Vector2(65, 220);
                spaceLoc[52] = new Vector2(60, 220);
                spaceLoc[53] = new Vector2(55, 220);
                spaceLoc[54] = new Vector2(50, 220);
                spaceLoc[55] = new Vector2(45, 220);
                spaceLoc[56] = new Vector2(40, 220);
                spaceLoc[57] = new Vector2(35, 220);
                spaceLoc[58] = new Vector2(30, 220);
                spaceLoc[59] = new Vector2(25, 220);
                spaceLoc[60] = new Vector2(20, 220);
                spaceLoc[61] = new Vector2(20, 180);
                spaceLoc[62] = new Vector2(25, 180);
                spaceLoc[63] = new Vector2(30, 180);
                spaceLoc[64] = new Vector2(35, 180);
                spaceLoc[65] = new Vector2(40, 180);
                spaceLoc[66] = new Vector2(45, 180);
                spaceLoc[67] = new Vector2(50, 180);
                spaceLoc[68] = new Vector2(55, 180);
                spaceLoc[69] = new Vector2(60, 180);
                spaceLoc[70] = new Vector2(65, 180);
                spaceLoc[71] = new Vector2(65, 140);
                spaceLoc[72] = new Vector2(60, 140);
                spaceLoc[73] = new Vector2(55, 140);
                spaceLoc[74] = new Vector2(50, 140);
                spaceLoc[75] = new Vector2(45, 140);
                spaceLoc[76] = new Vector2(40, 140);
                spaceLoc[77] = new Vector2(35, 140);
                spaceLoc[78] = new Vector2(30, 140);
                spaceLoc[79] = new Vector2(25, 140);
                spaceLoc[80] = new Vector2(20, 140);
                spaceLoc[81] = new Vector2(20, 100);
                spaceLoc[82] = new Vector2(25, 100);
                spaceLoc[83] = new Vector2(30, 100);
                spaceLoc[84] = new Vector2(35, 100);
                spaceLoc[85] = new Vector2(40, 100);
                spaceLoc[86] = new Vector2(45, 100);
                spaceLoc[87] = new Vector2(50, 100);
                spaceLoc[88] = new Vector2(55, 100);
                spaceLoc[89] = new Vector2(60, 100);
                spaceLoc[90] = new Vector2(65, 100);
                spaceLoc[91] = new Vector2(65, 60);
                spaceLoc[92] = new Vector2(60, 60);
                spaceLoc[93] = new Vector2(55, 60);
                spaceLoc[94] = new Vector2(50, 60);
                spaceLoc[95] = new Vector2(45, 60);
                spaceLoc[96] = new Vector2(40, 60);
                spaceLoc[97] = new Vector2(35, 60);
                spaceLoc[98] = new Vector2(30, 60);
                spaceLoc[99] = new Vector2(25, 60);
               

                boardGame = Content.Load<Texture2D>("Images/Game/snakesandladders");
                boardRectangle = new Rectangle(0, 0, 510, 480);
                picbRedPawn = Content.Load<Texture2D>("images/Sprites/katniss-everdeen-peeta-mellark-mockingjay-drawing-cartoon-png-favpng-mkDTnsxsSDy8eJ8PaRhZPqHzm");
                picbBluePawn = Content.Load<Texture2D>("images/Sprites/png-transparent-peeta-mellark-chibi-the-hunger-games-drawing-manga-the-hunger-games-child-face-hand-thumbnail");
                picbRedRec = new Rectangle(15, 380, 30, 30);
                picbBlueRec = new Rectangle(15, 420, 30, 30);
                theBoardGame = true;

                SnakeBackground = Content.Load<Texture2D>("Images/backgrounds/SnakeBackground");
                SnakeRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
                pressStart = Content.Load<Texture2D>("Images/press/239-2398008_transparent-start-button-png-press-space-to-start");
                pressRec = new Rectangle(50, 60, 500, 300);
                titleFont = Content.Load<SpriteFont>("Fonts/Title Font");


                bgMusic = Content.Load<Song>("background music/kibishi_time_s_arrow_-9095581066354777626");
                MediaPlayer.Volume = 0.8f;
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(bgMusic);
         

            // TODO: use this.Content to load your game content here


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            kb = Keyboard.GetState();



            if (kb.IsKeyDown(Keys.Enter))
            {
                
                dice = rng.Next(1, 7);
                p1space = p1space + dice;
                picbBlueRec.X = (int)spaceLoc[p1space - 1].X;
                picbBlueRec.Y = (int)spaceLoc[p1space - 1].Y;
               
            
               
            }
            // TODO: Add your update logic here




            if (inMenu == true)
            {

                spriteBatch.Begin();
                spriteBatch.Draw(SnakeBackground, SnakeRectangle, Color.White);
                spriteBatch.DrawString(titleFont, "Welcome to the deadly game of Snakes and Ladders!!", titleLoc, Color.Black);
                spriteBatch.Draw(pressStart, pressRec, Color.White);
                spriteBatch.End();

                if (kb.IsKeyDown(Keys.Space))
                {
                    inMenu = false;
                }

            }

            else
            {


                inMenu = false;
                spriteBatch.Begin();
                spriteBatch.Draw(boardGame, boardRectangle, Color.White);
                spriteBatch.Draw(picbRedPawn, picbRedRec, Color.White);
                spriteBatch.Draw(picbBluePawn, picbBlueRec, Color.White);
                spriteBatch.End();

            }

            
                base.Update(gameTime);
            }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here


          if (inMenu == true)
         {

            spriteBatch.Begin();
            spriteBatch.Draw(SnakeBackground, SnakeRectangle, Color.White);
            spriteBatch.DrawString(titleFont, "Welcome to the deadly game of Snakes and Ladders!!", titleLoc, Color.Black);
            spriteBatch.Draw(pressStart, pressRec, Color.White);    
            spriteBatch.End();
                
         }

         else
         {


                inMenu = false;
                spriteBatch.Begin();
                spriteBatch.Draw(boardGame, boardRectangle, Color.White);
                spriteBatch.Draw(picbRedPawn, picbRedRec, Color.White);
                spriteBatch.Draw(picbBluePawn, picbBlueRec, Color.White); 
                spriteBatch.End();
                
         }
       



            base.Draw(gameTime);


        }
    }

}