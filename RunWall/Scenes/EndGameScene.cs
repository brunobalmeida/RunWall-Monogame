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
    public class EndGameScene : GameScene
    {
        SpriteBatch spriteBatch;
        SpriteFont font;
        public EndGameScene(Game game,
            SpriteFont font) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            this.font = font;
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            string text = "  Game Over\nYour Score is:\n"+"        " + Shared.score + 
                "\n The higher \nscore is:\n" + Shared.highScore;

            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, new Vector2(70, 200), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
