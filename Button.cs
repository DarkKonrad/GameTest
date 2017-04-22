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

namespace Przyciskitest {
    class Button {

        private Texture2D texture;
        public Texture2D Texture { get { return texture; } set { texture = value; } }

        private Rectangle cords;
        public Rectangle Cords { get { return cords; } set { cords = value; } }

        private bool paint;
        public bool Paint { get { return paint; } set { paint = value; } }

        private Vector2 dir;
        public Vector2 Dir { get { return dir; } set { dir = value; } }

        public Button(string P ,Rectangle R ,GraphicsDevice GD ,Vector2 D) {
            using (var stream = TitleContainer.OpenStream(P)) {
                Texture = Texture2D.FromStream(GD, stream);
            }
            Cords = R;
            paint = true;
            Dir = D;
        }
    }
}