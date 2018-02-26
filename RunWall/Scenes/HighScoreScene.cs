using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace RunWall
{
    public class HighScoreScene : GameScene
    {

        int[] highScores;
        SpriteBatch spriteBatch;
        SpriteFont font;
        string text;

        public HighScoreScene(Game game, SpriteFont font) : base(game)
        {
            Game1 g = (Game1)game;
            this.font = font;
            this.spriteBatch = g.spriteBatch;

            LoadHighScore();
        }

        public void SaveHighScore()
        {
            for (int i = 0; i < highScores.Length; i++)
            {
                if (Shared.score>highScores[i])
                {
                    highScores[i] = Shared.score;
                    break;
                }
            }

            Array.Sort(highScores);
            Array.Reverse(highScores);
            Shared.highScore = highScores[0];
            try
            {
                StreamWriter writer;
                writer = new StreamWriter("highScore.txt");
                for (int i = 0; i < highScores.Length; i++)
                {
                    writer.WriteLine(highScores[i]); 
                }
                writer.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
        }


        public void LoadHighScore()
        {
            try
            {
                StreamReader reader;
                reader = new StreamReader("highScore.txt");
                highScores = new int[5];
                int i = 0;
                while (reader.EndOfStream == false && i < 5)
                {
                    highScores[i] = Convert.ToInt32(reader.ReadLine());
                    i++;
                }
                reader.Close();

                Array.Sort(highScores);
                Array.Reverse(highScores);
            }
            catch (FileNotFoundException)
            {
                highScores = new int[5];
                StreamWriter writer;
                writer = new StreamWriter("highScore.txt");
                for (int i = 0; i < highScores.Length; i++)
                {
                    writer.WriteLine(highScores[i]); 
                }
                writer.Close();
            }

        }


        public override void Update(GameTime gameTime)
        {

            if (Shared.gameIsOver)
            {
                SaveHighScore();
            }

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            text = "High Scores: \n";

            for (int i = 0; i < highScores.Length; i++)
            {
                text += highScores[i].ToString() + "\n";
            }

            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, new Vector2(70,200), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }



    }
}
