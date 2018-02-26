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
    public class Ball : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D tex;
        Vector2 position;
        Vector2 speed;
        FireUp fireBlock;

        public Vector2 Position { get => position; set => position = value; }

        public Ball (Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            FireUp fireBlock) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.fireBlock = fireBlock;
            position = new Vector2(fireBlock.GetBound().X + fireBlock.GetBound().Width/2 -5,
                fireBlock.GetBound().Y);
            speed = new Vector2(0, -5);
        }

        public override void Update(GameTime gameTime)
        {
            position += speed;


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
