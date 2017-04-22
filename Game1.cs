using Android.OS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using Android.Views;
namespace Przyciskitest {

    public class Game1 : Game {
        static public int ScrWidth;
        static public int ScrHeight;
        static public bool Running = false;
        
        const int SPEED = 10;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
     public   MainMenu main = new MainMenu();
      

        List<Button> Menu;
        Bot Player;

        public Game1() {
           
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
           
           // graphics.PreferredBackBufferWidth = 800;
         //   graphics.PreferredBackBufferHeight = 600;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        protected override void Initialize() {
            Menu = new List<Button>();

          //  graphics.PreferredBackBufferHeight = 600;
        //   graphics.PreferredBackBufferWidth = 800;
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Player = new Bot(new Vector2(400, 400), "Content/Bot.png", GraphicsDevice);

            Menu.Add(new Button("Content/1.png", new Rectangle(450, 650, 200, 200), GraphicsDevice, new Vector2(1, 0)));// Prawo
            Menu.Add(new Button("Content/2.png", new Rectangle(50, 650, 200, 200), GraphicsDevice, new Vector2(-1, 0)));// Lewo

          Menu.Add(new Button("Content/3.png", new Rectangle(250, 850, 200, 200), GraphicsDevice, new Vector2(0, 1)));// Dol
          Menu.Add(new Button("Content/4.png", new Rectangle(250, 450, 200, 200), GraphicsDevice, new Vector2(0, -1)));// Gora

            main.LoadContent(Content);
          

        }

        protected override void UnloadContent() {
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            if (Running==true)
            {
                TouchCollection touchCollection = TouchPanel.GetState();

                foreach (TouchLocation tl in touchCollection)
                {
                    for (int i = 0; i < Menu.Count; i++)
                    {
                        if (Menu[i].Cords.Contains(tl.Position))
                            Player.Position += (Menu[i].Dir * SPEED);
                    }
                }

                bool TheyAreGone = true;

                for (int i = 0; i < Menu.Count; i++)
                    if (Menu[i].Paint)
                        TheyAreGone = false;

                if (TheyAreGone)
                    for (int i = 0; i < Menu.Count; i++)
                        Menu[i].Paint = true;
            }



           else main.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if(Running == true)
            {
                foreach (Button B in Menu)
                {
                    if (B.Paint)
                        spriteBatch.Draw(B.Texture, B.Cords, Color.White);
                }

                spriteBatch.Draw(Player.Texture, Player.Position, Color.White);
            }


            else main.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
