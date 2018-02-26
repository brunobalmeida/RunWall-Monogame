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
    public class Block : DrawableGameComponent
    {
        SpriteFont font; 
        SpriteBatch spriteBatch;
        Texture2D tex;
        public Vector2 position;
        public Vector2 speed;
        Random r = new Random();
        public int blockLife;
        Vector2 fontPosition;

        public Block(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed, 
            int blockLife,
            SpriteFont font) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.blockLife = blockLife;
            this.font = font;
            fontPosition.X = position.X + 42;
            fontPosition.Y = position.Y + 30;
            
        }

        public override void Update(GameTime gameTime)
        {
            position += speed;
            fontPosition += speed;

            if (position.Y > Shared.stage.Y )
            {
                this.Enabled = false;
                this.Visible = false;
            }

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.DrawString(font, blockLife.ToString(),
                fontPosition, Color.White) ;

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public Rectangle GetBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }


    }
}
