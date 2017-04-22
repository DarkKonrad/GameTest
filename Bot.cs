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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Przyciskitest {
    class Bot {

        private Vector2 position;
        public Vector2 Position { get { return position; } set { position = value; } }

        private Texture2D texture;
        public Texture2D Texture { get { return texture; } set { texture = value; } }

        public Bot(Vector2 NewPosition, String TexturePath, GraphicsDevice GD) {
            Position = NewPosition;
            using (var stream = TitleContainer.OpenStream(TexturePath)) {
                Texture = Texture2D.FromStream(GD, stream);

            }
        }


    }
}