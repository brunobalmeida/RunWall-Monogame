using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace RunWall
{
    public class StartScene : GameScene
    {
        public MenuComponent Menu { get; set; }
        private SpriteBatch spriteBatch;
        string[] menuItems = { "Start Game", "How to Play", "High Score", "Help", "Credit", "Quit"};
        Texture2D tex;


        public StartScene(Game game,
            Texture2D tex) : base(game)
        {
            Game1 gm = (Game1)game;
            this.spriteBatch = gm.spriteBatch;
            this.tex = tex;
            SpriteFont regularFont = gm.Content.Load<SpriteFont>("Fonts/regularFont");
            SpriteFont highlightFont = gm.Content.Load<SpriteFont>("Fonts/highlightFont");
            Menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems);
            this.components.Add(Menu);
        }
         
        public override void Update(GameTime gameTime)
        {

            if (this.Enabled==false)
            {
                MediaPlayer.Stop();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
