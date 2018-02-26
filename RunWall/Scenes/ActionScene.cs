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
    public class ActionScene : GameScene
    {
        private SpriteFont font;
        private SpriteFont scoreFont;
        private SpriteBatch spriteBatch;
        private FireUp fireBlock;
        private Random r = new Random();
        public int delay = 100;
        private int[] blockLife = new int[6];
        public int bLifeDenominator = 25;
        private int ballDelay = 20;
        private int ballCounter = 0;
        private SoundEffect ballSound;
        private SoundEffect hitSound;
        CollisionManager cm;
        public List<Block> blockList;
        public List<Ball> ballList;
        int ballCount = 0;
        Explosion explosion;

        int count;

        Texture2D[] blockTexs = new Texture2D[7];
        Texture2D balltex;

        public int[] BlockLife { get => blockLife; set => blockLife = value; }

        public ActionScene(Game game) : base(game)
        {



            //Code to add the components 
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;

            //Adding the fire block
            Texture2D texFireBlock = g.Content.Load<Texture2D>("Images/killerBlock");
            fireBlock = new FireUp(game, spriteBatch, texFireBlock);
            this.components.Add(fireBlock);

            //Initializing the block font
            font = g.Content.Load<SpriteFont>("Fonts/blockFont");

            //Initizlizint the score font 
            scoreFont = g.Content.Load<SpriteFont>("Fonts/ScoreFont");

            //Adding the blocks textures 
            blockTexs[0] = g.Content.Load<Texture2D>("Images/blueBlock");
            blockTexs[1] = g.Content.Load<Texture2D>("Images/lightBlueBlock");
            blockTexs[2] = g.Content.Load<Texture2D>("Images/lightGreenBlock");
            blockTexs[3] = g.Content.Load<Texture2D>("Images/orangeBlock");
            blockTexs[4] = g.Content.Load<Texture2D>("Images/redBlock");
            blockTexs[5] = g.Content.Load<Texture2D>("Images/violetBlock");
            blockTexs[6] = g.Content.Load<Texture2D>("Images/yellowBlock");

            // Adding the ball texture
            balltex = g.Content.Load<Texture2D>("Images/ball");


            //Adding the sounds
            ballSound = g.Content.Load<SoundEffect>("Sounds/shotSound");
            hitSound = g.Content.Load<SoundEffect>("Sounds/hitSound");

            //Initializing the objects
            blockList = new List<Block>();
            ballList = new List<Ball>();


            //Explosion
            Texture2D explosionTex = g.Content.Load<Texture2D>("Images/explosions");
            explosion = new Explosion(game, spriteBatch, explosionTex, Vector2.Zero, 4);
            this.components.Add(explosion);


            //Adding the collision manager
            cm = new CollisionManager(game, blockList, ballList,
                fireBlock, hitSound, spriteBatch, scoreFont, explosion);
            this.components.Add(cm);



        }

        public void SpawnBall(Game1 game, int count)
        {
            ballList.Add(new Ball(game, spriteBatch, balltex, fireBlock));
            this.components.Add(ballList[count]);

        }


        public void SpawnBlock(Game1 game, int count)
        {
            for (int i = count; i < count + 6; i++)
            {
                if (count == 0)
                {
                    blockLife[i] = r.Next(25, 102) / bLifeDenominator;
                    blockList.Add(new Block(game, spriteBatch, blockTexs[r.Next(0, 6)],
                   new Vector2(i * 100, 5), new Vector2(0, 4), blockLife[i], font));
                }
                else
                {
                    blockLife[i % count] = r.Next(25, 102) / bLifeDenominator;
                    blockList.Add(new Block(game, spriteBatch, blockTexs[r.Next(0, 6)],
                   new Vector2(i % count * 100, 25), new Vector2(0, 4), blockLife[i % count], font));
                }
                this.components.Add(blockList[i]);
            }
        }


        public void Restart()
        {
            
            foreach (var blocks in blockList)
            {
                blocks.position = new Vector2(2000, 2000);
            }

            foreach (var balls in ballList)
            {
                balls.Position = new Vector2(1000, 1000);
            }

            blockList.Clear();
            ballList.Clear();
            count = 0;
            ballCount = 0;
            Shared.gameIsOver = false;

            
        }


        public override void Update(GameTime gameTime)
        {

           


            delay++;
            ballCounter++;

            if (delay > 120)
            {
                SpawnBlock(new Game1(), count);
                count = count + 6; 
                delay = 0;
            }

            if (ballCounter > ballDelay)
            {
                SpawnBall(new Game1(), ballCount);
                ballSound.Play();
                ballCounter = 0;
                ballCount++;

            }


            if (Shared.score == 50) 
            {
                bLifeDenominator = 18;
            }

            if (Shared.score == 100)
            {
                bLifeDenominator = 13;
                ballDelay = 17;
            }

            if (Shared.score == 150)
            {
                bLifeDenominator = 9;
                ballDelay = 15;
            }

            if (Shared.score == 200)
            {
                bLifeDenominator = 5;
                ballDelay = 10;
            }

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    
    }
}
