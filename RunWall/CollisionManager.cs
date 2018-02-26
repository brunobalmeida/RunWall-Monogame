using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace RunWall
{
    public class CollisionManager : DrawableGameComponent
    {

        List<Block> blockList;
        List<Ball> ballList;
        FireUp fireBlock;
        SoundEffect hitSound;
        Game1 g = new Game1();
        SpriteBatch spriteBatch;
        SpriteFont font;
        Vector2 fontPosition;
        Explosion explosion;
        
        public CollisionManager (Game Game,
            List<Block> blockList,
            List<Ball> ballList,
            FireUp fireBlock,
            SoundEffect hitSound,
            SpriteBatch spriteBatch,
            SpriteFont font,
            Explosion explosion) : base(Game)
        {
            this.blockList = blockList;
            this.ballList = ballList;
            this.fireBlock = fireBlock;
            this.hitSound = hitSound;
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.explosion = explosion;
            fontPosition.X = 200;
            fontPosition.Y = 10;
        }


        public override void Update(GameTime gameTime)
        {

            foreach (Block block in blockList)
            {
                if (fireBlock.GetBound().Intersects(block.GetBound()))
                {
                    block.position = new Vector2(2000, 2000);
                    Shared.gameIsOver = true;
                }

                foreach (Ball ball in ballList)
                {
                    if (ball.GetBound().Intersects(block.GetBound()))
                    {
                        block.blockLife--;
                        ball.Position = new Vector2(1000, 1000);
                        ball.Enabled = false;
                        Shared.score++;
                        hitSound.Play();
                        
                        if (block.blockLife == 0)
                        {
                            explosion.Position = new Vector2(block.GetBound().X ,
                                block.GetBound().Y + block.GetBound().Height / 2);
                            explosion.StartAnimation();
                            block.position = new Vector2(2000, 2000);
                        }

                    }
                }


            }

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Score: " + Shared.score.ToString(), fontPosition, Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }



    }
}
