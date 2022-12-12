using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Part_3__Animation
{
    public class tribble
    {
        private Texture2D _texture;
        private Rectangle _rect;
        private Vector2 _speed;


        public tribble(Texture2D texture, Rectangle rectangle, Vector2 speed)
        {
            _texture = texture;
            _rect = rectangle;
            _speed = speed;
        }

        public void Move()
        {
            _rect.Offset(_speed);
        }

        public void BounceLeftRight()
        {
            _speed.X *= -1;
        }

        public void BounceTopBottom()
        {
            _speed.Y *= -1;
        }

        public Rectangle Bounds
        {
            get { return _rect; }
            set { _rect = value; }
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }
    }
        public class Game1 : Game
    {
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        tribble tribble1;
        Texture2D tribblegreyTexture;
        Texture2D tribblebrownTexture;
        Texture2D tribblecreamTexture;
        Texture2D tribbleorangeTexture;
        Texture2D backgroundTexture;
        Rectangle tribblebrownRect;
        Vector2 tribblebrownSpeed;
        Rectangle tribblecreamRect;
        Vector2 tribblecreamSpeed;
        Rectangle tribbleorangeRect;
        Vector2 tribbleorangeSpeed;
        SoundEffect cooSound;
        List<Texture2D> tribbleTextures; 

        List<tribble> tribbles;
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

            
            tribblebrownSpeed = new Vector2(1, 2);
            tribblebrownRect = new Rectangle(300, 10, generator.Next(10, 100), generator.Next(10, 100));
            tribblecreamSpeed = new Vector2(2, 0);
            tribblecreamRect = new Rectangle(300, 10, generator.Next(10, 100), generator.Next(10, 100));
            tribbleorangeSpeed = new Vector2(0, 2);
            tribbleorangeRect = new Rectangle(400, 30, generator.Next(10, 100), generator.Next(10, 100));
            
            base.Initialize();
            tribbles = new List<tribble>();
            tribbleTextures = new List<Texture2D>()
            {
                tribblebrownTexture,
                tribblecreamTexture,
                tribblegreyTexture,
                tribbleorangeTexture
            };
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribblebrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribblecreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleorangeTexture = Content.Load<Texture2D>("tribbleOrange");
            backgroundTexture = Content.Load<Texture2D>("space");
            cooSound = Content.Load<SoundEffect>("tribble_coo");







            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            tribble1.Move();
            if (tribble1.Bounds.Right > 800 || tribble1.Bounds.Left < 0)
                tribble1.BounceLeftRight();
            if (tribble1.Bounds.Bottom > 500 || tribble1.Bounds.Top < 0)
                tribble1.BounceTopBottom();




            tribblebrownRect.X += (int)tribblebrownSpeed.X;
            tribblebrownRect.Y += (int)tribblebrownSpeed.Y;
            if (tribblebrownRect.Right > 800 || tribblebrownRect.Left < 0)
            {
                tribblebrownSpeed.X *= -1;
                tribblebrownRect = new Rectangle(generator.Next(50, 400), (generator.Next(50, 400)), generator.Next(10, 100), generator.Next(10, 100));
                cooSound.Play();
            }
                

            if (tribblebrownRect.Bottom > _graphics.PreferredBackBufferHeight || tribblebrownRect.Top < 0)
            {
                tribblebrownSpeed.Y *= -1;
                tribblebrownRect = new Rectangle(generator.Next(50, 400), (generator.Next(50, 400)), generator.Next(10, 100), generator.Next(10, 100));
                cooSound.Play();
            }
                


            tribblecreamRect.X += (int)tribblecreamSpeed.X;
            tribblecreamRect.Y += (int)tribblecreamSpeed.Y;
            if (tribblecreamRect.Right > 800 || tribblecreamRect.Left < 0)
            {
                tribblecreamSpeed.X *= -1;
                tribblecreamRect = new Rectangle(generator.Next(50, 400), (generator.Next(50, 400)),generator.Next(10, 100), generator.Next(10, 100));
                cooSound.Play();
            }
                


            if (tribblecreamRect.Bottom > _graphics.PreferredBackBufferHeight || tribblecreamRect.Top < 0)
            {
                tribblecreamSpeed.Y *= -1;
                tribblecreamRect = new Rectangle(generator.Next(50, 400), (generator.Next(50, 400)), generator.Next(10, 100), generator.Next(10, 100));
                cooSound.Play();
            }
                


            tribbleorangeRect.X += (int)tribbleorangeSpeed.X;
            tribbleorangeRect.Y += (int)tribbleorangeSpeed.Y;
            if (tribbleorangeRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleorangeRect.Top < 0)
            {
                tribbleorangeSpeed.Y *= -1;
                tribbleorangeRect = new Rectangle (generator.Next(50, 400), (generator.Next(50, 400)), generator.Next(10, 100), generator.Next(10, 100));
                cooSound.Play();
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

            _spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(tribble1.Texture, tribble1.Bounds, Color.White);
            _spriteBatch.Draw(tribblecreamTexture, tribblecreamRect, Color.White);
            _spriteBatch.Draw(tribbleorangeTexture, tribbleorangeRect, Color.White);
            _spriteBatch.Draw(tribblebrownTexture, tribblebrownRect, Color.White);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}