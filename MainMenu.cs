using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Android.Views.InputMethods;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace Przyciskitest
{
    struct Size
    {
        public int height { get; private set; }

        public int width { get; private set; }

        public Size(int width, int height) : this()
        {
            this.height = height;
            this.width = width;

        }
    }


    public class MainMenu
    {


        private Song mor;
    
        enum GameState { MainMenu,enterName,inGame,Options}
        GameState gamestate;

        List<GUIElement> options = new List<GUIElement>();
        List<GUIElement> main = new List<GUIElement>();
      public  List<GUIElement> enterName = new List<GUIElement>();

      //  private Keys
        public MainMenu()
        {
            main.Add(new GUIElement("menu"));
            main.Add(new GUIElement("play"));
            main.Add(new GUIElement("nameBtn"));
            main.Add(new GUIElement("2"));

          //  options.Add(new GUIElement("2"));
            options.Add(new GUIElement("Bot"));

            enterName.Add(new GUIElement("name"));
            enterName.Add(new GUIElement("done"));
        }

        public void LoadContent(ContentManager content)
        {
           
            foreach (GUIElement element in main)
            {
                element.LoadContent(content);
                element.CenterElement(600,800);
                //  element.CenterElement(Game1.ScrHeight, Game1.ScrWidth);
                element.clickEvent += OnClick;
            }

            main.Find(x => x.AssetName == "play").MoveElement(0, -100); // " x =>" wyrażenie lambda
            main.Find(x => x.AssetName == "2").MoveElement(0, 300);
            foreach (GUIElement element in enterName)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            enterName.Find(x => x.AssetName == "done").MoveElement(0, 60);

            foreach(GUIElement element in options)
            {
                mor = content.Load<Song>("Mortal"); // tutaj mogą być problemy
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
            options.Find(x => x.AssetName == "Bot").MoveElement(0, 0);
        }

        public void Update()
        {
            switch (gamestate)
            {
                case GameState.MainMenu:
                    foreach (GUIElement element in main)
                    {
                        element.Update();
                    }
                    break;
                case GameState.enterName:
                    foreach (GUIElement element in enterName)
                    {
                        element.Update();
                    }
                    break;
                case GameState.inGame:
                    break;
                case GameState.Options:
                    foreach(GUIElement element in options)
                    {
                        element.Update();
                    }

                    break;
            }
          
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gamestate)
            {
                case GameState.MainMenu:
                    foreach (GUIElement element in main)
                    {
                        element.Draw(spriteBatch);

                    }
                    break;
                case GameState.enterName:
                    foreach (GUIElement element in enterName)
                    {
                        
                        element.Draw(spriteBatch);
                       
                    }
                    break;
                case GameState.inGame:
                    break;
                case GameState.Options:
                    foreach(GUIElement element in options)
                    {
                        element.Draw(spriteBatch);
                    }

                    break;

            }
           
          
        }

     
        public void OnClick(string element)
        {
            if (element=="play")
            {
                Game1.Running = true;
                // plays the game
                gamestate = GameState.inGame;
            }
            if(element=="nameBtn")
            {
               gamestate = GameState.enterName;
               

            }
            if (element == "done")//Done button
            {
                gamestate = GameState.MainMenu;
            }
            if (element=="2")
            {
                gamestate = GameState.Options;
            }
            if (element== "Bot")
            {
                MediaPlayer.Play(mor);
            }
        }
        //private void GetKeys()
        //{
        //    KeyboardState state = Keyboard.GetState();
        //   // TouchCollection state = TouchPanel.GetState();
        //    System.Text.StringBuilder sb = new StringBuilder();
        //    foreach (var key in state.GetPressedKeys())
        //        sb.Append(key);

        //    if (sb.Length > 0) System.Diagnostics.Debug.WriteLine(sb.ToString());
        //    else
        //        System.Diagnostics.Debug.WriteLine("NIc sie nie wcisnęło");

        //}
    }
}