using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Part_3__Animation
{
    
        public class Game1 : Game
    {
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        enum Screen
        {
            Intro,
            TribbleYard,
        }
        Screen screen;
        tribble tribble1;
        tribble tribble2;
        tribble tribble3;
        tribble tribble4;
        Texture2D tribblegreyTexture;
        Texture2D tribblebrownTexture;
        Texture2D tribblecreamTexture;
        Texture2D tribbleorangeTexture;
        Texture2D backgroundTexture;
        MouseState mouseState;
        SoundEffect cooSound;
        Texture2D tribbleIntroTexture;
       
        Random generator = new Random();

   

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {

            
            
            base.Initialize();
            screen = Screen.Intro;
            tribble1 = new tribble(tribblegreyTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(2, 0));
            tribble2 = new tribble(tribblebrownTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(2, 1));
            tribble3 = new tribble(tribblecreamTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(1, 3));
            tribble4 = new tribble(tribbleorangeTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(0, 2));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribblegreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribblebrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribblecreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleorangeTexture = Content.Load<Texture2D>("tribbleOrange");
            backgroundTexture = Content.Load<Texture2D>("space");
            cooSound = Content.Load<SoundEffect>("tribble_coo");
            tribbleIntroTexture = Content.Load<Texture2D>("tribble_intro");







            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;

            }

            else if (screen == Screen.TribbleYard)
            {
                tribble1.Move();
                if (tribble1.Bounds.Right > 800 || tribble1.Bounds.Left < 0)
                {
                    tribble1.BounceLeftRight();
                    tribble1 = new tribble(tribblegreyTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(2, 0));
                    cooSound.Play();
                }


                if (tribble1.Bounds.Bottom > 500 || tribble1.Bounds.Top < 0)
                {
                    tribble1.BounceTopBottom();
                    tribble1 = new tribble(tribblegreyTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(2, 0));
                    cooSound.Play();
                }





                tribble2.Move();
                if (tribble2.Bounds.Right > 800 || tribble2.Bounds.Left < 0)
                {
                    tribble2.BounceLeftRight();
                    tribble2 = new tribble(tribblebrownTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(2, 1));
                    cooSound.Play();
                }


                if (tribble2.Bounds.Bottom > 500 || tribble2.Bounds.Top < 0)
                {
                    tribble2.BounceTopBottom();
                    tribble2 = new tribble(tribblebrownTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(2, 1));
                    cooSound.Play();
                }




                tribble3.Move();
                if (tribble3.Bounds.Right > 800 || tribble3.Bounds.Left < 0)
                {
                    tribble3.BounceLeftRight();
                    tribble3 = new tribble(tribblecreamTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(1, 3));
                    cooSound.Play();
                }


                if (tribble3.Bounds.Bottom > 500 || tribble3.Bounds.Top < 0)
                {
                    tribble3.BounceTopBottom();
                    tribble3 = new tribble(tribblecreamTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(1, 3));
                    cooSound.Play();
                }




                tribble4.Move();
                if (tribble4.Bounds.Right > 800 || tribble4.Bounds.Left < 0)
                {
                    tribble4.BounceLeftRight();
                    tribble4 = new tribble(tribbleorangeTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(0, 2));
                    cooSound.Play();
                }


                if (tribble4.Bounds.Bottom > 500 || tribble4.Bounds.Top < 0)
                {
                    tribble4.BounceTopBottom();
                    tribble4 = new tribble(tribbleorangeTexture, new Rectangle(generator.Next(10, 700), generator.Next(10, 400), generator.Next(10, 100), generator.Next(10, 100)), new Vector2(0, 2));
                    cooSound.Play();
                }
            }
           
                



            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntroTexture, new Rectangle(0, 0, 800, 500), Color.White);
            }

            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
                _spriteBatch.Draw(tribble1.Texture, tribble1.Bounds, Color.White);
                _spriteBatch.Draw(tribble2.Texture, tribble2.Bounds, Color.White);
                _spriteBatch.Draw(tribble3.Texture, tribble3.Bounds, Color.White);
                _spriteBatch.Draw(tribble4.Texture, tribble4.Bounds, Color.White);
            }
            
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}