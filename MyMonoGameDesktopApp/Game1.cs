using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyMonoGameDesktopApp
{
    internal class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spritebatch;

        private Texture2D skeppTexture;
        private Texture2D debrisTexture;
        private Rectangle rect1;
        private Rectangle rect2;
        private Rectangle debris1;


        private List<Rectangle> debris;

        private int debrisTimer = 60;
        private int debrisWidth = 15;
        private int debrisHeight = 8;

        private int rect1startX = 250;
        private int rect2startX = 500;
        private int rectStart = 445;

        Random random = new Random();


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsFixedTimeStep = true;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            

            rect1 = new Rectangle(rect1startX, rectStart, 20, 30);
            rect2 = new Rectangle(rect2startX, rectStart, 20, 30);

            debris1 = new Rectangle(-15, 470, debrisWidth, debrisHeight);

            debris = new List<Rectangle>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            spritebatch = new SpriteBatch(GraphicsDevice);
            
            skeppTexture = Content.Load<Texture2D>("skepp");
            debrisTexture = Content.Load<Texture2D>("debris");

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            
            var state = Keyboard.GetState();

            

            //

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

           

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.S))
            {
                rect1.Y++;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Up))
            {
                rect2.Y--;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Down))
            {
                rect2.Y++;
            }

            //

            if (rect1.Y < 0)
            {
                rect1.Y = rectStart;
            }
            else if (rect1.Y > rectStart)
            {
                rect1.Y = rectStart;
            }

            if (rect2.Y < 0)
            {
                rect2.Y = rectStart;
            }
            else if (rect2.Y > rectStart)
            {
                rect2.Y = rectStart;
            }

            //

            debrisTimer--;
            if (debris.Count <= 20 && debrisTimer <= 0)
            {
                debrisTimer = 60;
                debris.Add(new Rectangle(0, 100, debrisWidth, debrisHeight));
            }
                
            for( int i = 0; i < debris.Count; i++)
            {
                debris[i] = debris[i];
                debris[i].X++;
                
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            

            spritebatch.Begin();
            spritebatch.Draw(skeppTexture, rect1, Color.Cyan);
            spritebatch.Draw(skeppTexture, rect2, Color.Red);
            spritebatch.Draw(debrisTexture, debris1, Color.White);

            foreach (var debris in debris)
            {
                spritebatch.Draw(debrisTexture, debris, Color.White);
            }


            spritebatch.End();

            base.Draw(gameTime);
        }
    }
}
