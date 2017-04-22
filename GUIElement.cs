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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Input;
namespace Przyciskitest
{
  public  class GUIElement
    {
        private Texture2D GUITexture;
        private Rectangle GUIRect;
        private string assetName;

        public string AssetName { get => assetName; set => assetName = value; }

        public delegate void ElementClicked(string element);
        public event ElementClicked clickEvent;

        public GUIElement(string assetName)
        {
            this.assetName = assetName;
        }

        public void LoadContent(ContentManager content)
        {
            GUITexture = content.Load<Texture2D>(assetName); // GUITEXTURE instancja Texture2D
            GUIRect = new Rectangle(0, 0, GUITexture.Width, GUITexture.Height);

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(GUITexture, GUIRect, Color.White);
        }
        public void Update()
        {
            TouchCollection touchcollection =  TouchPanel.GetState();
            // TouchLocation tl = new TouchLocation();
            
            foreach (TouchLocation tl in touchcollection) // włazi w Kwadrat
            if (GUIRect.Contains(tl.Position))
            {
                    clickEvent(assetName);
            }
           // if (GUIRect.Contains(new Point()))
        }

        public void CenterElement(int height,int width)
        {
           GUIRect = new Rectangle((width / 2) - (this.GUITexture.Width / 2), (height / 2) - (this.GUITexture.Height / 2), this.GUITexture.Width, this.GUITexture.Height);
           // GUIRect = new Rectangle((width /2), (height / 2), this.GUITexture.Width, this.GUITexture.Height);
        }

        public void MoveElement(int x,int y)
        {
            GUIRect = new Rectangle(GUIRect.X += x, GUIRect.Y += y, GUIRect.Width, GUIRect.Height);
        }
    }


}