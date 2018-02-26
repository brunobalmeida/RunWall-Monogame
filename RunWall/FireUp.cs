using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RunWall
{
    public class FireUp : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D tex;
        Vector2 position;
        Vector2 speed;

        public FireUp(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            position = new Vector2((Shared.stage.X - tex.Width) / 2, Shared.stage.Y - tex.Height -10);
            speed = new Vector2(6, 0);
        }


        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                position += speed;
                if (position.X > Shared.stage.X - tex.Width)
                {
                    position.X = Shared.stage.X - tex.Width;
                }
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                position -= speed;
                if (position.X < 0)
                {
                    position.X = 0;
                }
            }
                base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }


        public Rectangle GetBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }


    }
}
