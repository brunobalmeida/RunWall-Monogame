using System;
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
    public class HowToPlayScene : GameScene
    {

        SpriteBatch spriteBatch;
        Texture2D howToPlay;
        public HowToPlayScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            howToPlay = g.Content.Load<Texture2D>("Images/HowToPlayScene");
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(howToPlay, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
