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
    public class Explosion : DrawableGameComponent
    {

        SpriteBatch spriteBatch;
        Texture2D tex;
        public Vector2 Position { get; set; }
        Vector2 dimension;
        List<Rectangle> frames;
        int frameIndex = -1;
        int delay;
        int delayCounter;



        public Explosion(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            int delay) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.Position = position;
            this.delay = delay;

            dimension = new Vector2(200, 180);


            StopAnimation();
            CreateFrames();


        }


        public void StartAnimation()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public void StopAnimation()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        private void CreateFrames()
        {
            frames = new List<Rectangle>();

            Random q = new Random();
            int y = q.Next(0,3) * (int)dimension.Y;

            for (int i = 0; i < 4; i++)
            {
                int x = i * (int)dimension.X;
                Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                this.frames.Add(r);
            }
        }



        public override void Update(GameTime gameTime)
        {

            delayCounter++;

            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > 3)
                {
                    frameIndex = -1;
                    StopAnimation();
                }
                delayCounter = 0;
            }



            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (frameIndex > 0)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(tex, Position, frames[frameIndex], Color.White);

                spriteBatch.End();
            }

            base.Draw(gameTime);
        }


    }
}
