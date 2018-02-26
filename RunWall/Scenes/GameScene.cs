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
    public class GameScene : DrawableGameComponent
    {

        public List<GameComponent> components;

        public virtual void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public virtual void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        public GameScene(Game game) : base(game)
        {
            Game1 g = (Game1)game; 
            components = new List<GameComponent>();
            Hide();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent comp = null;

            foreach (GameComponent item in components)
            {
                if (item is DrawableGameComponent)
                {
                    comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }

    }
}
