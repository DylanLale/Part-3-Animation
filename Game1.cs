using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Part_3__Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribblebrownTexture;
        Texture2D tribblecreamTexture;
        Texture2D tribbleorangeTexture;
        Texture2D tribblegreyTexture;
        Rectangle tribblegreyRect;
        Vector2 tribblegreySpeed;
        Rectangle tribblebrownRect;
        Vector2 tribblebrownSpeed;
        Rectangle tribblecreamRect;
        Vector2 tribblecreamSpeed;
        Rectangle tribbleorangeRect;
        Vector2 tribbleorangeSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            tribblegreySpeed = new Vector2(2, 0);
            tribblegreyRect = new Rectangle(300, 10, 100, 100);
            tribblebrownSpeed = new Vector2(1, 2);
            tribblebrownRect = new Rectangle(300, 10, 100, 100);
            tribblecreamSpeed = new Vector2(3, 4);
            tribblecreamRect = new Rectangle(200, 10, 100, 100);
            tribbleorangeSpeed = new Vector2(0, 2);
            tribbleorangeRect = new Rectangle(400, 30, 100, 100);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribblebrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribblecreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleorangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribblegreyTexture = Content.Load<Texture2D>("tribbleGrey");






            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            tribblegreyRect.X += (int)tribblegreySpeed.X;
            tribblegreyRect.Y += (int)tribblegreySpeed.Y;
            if (tribblegreyRect.Right > 800 || tribblegreyRect.Left < 0)
                tribblegreySpeed.X *= -1;

            tribblebrownRect.X += (int)tribblebrownSpeed.X;
            tribblebrownRect.Y += (int)tribblebrownSpeed.Y;
            if (tribblebrownRect.Right > 800 || tribblebrownRect.Left < 0)
                tribblebrownSpeed.X *= -1;
            if (tribblebrownRect.Bottom > _graphics.PreferredBackBufferHeight || tribblebrownRect.Top < 0)
                tribblebrownSpeed.Y *= -1;

            tribblecreamRect.X += (int)tribblecreamSpeed.X;
            tribblecreamRect.Y += (int)tribblecreamSpeed.Y;
            if (tribblecreamRect.Right > 800 || tribblecreamRect.Left > 0)
                tribblecreamSpeed.X *= -1;
            if (tribblecreamRect.Bottom > _graphics.PreferredBackBufferHeight || tribblecreamRect.Top < 0)
                tribblecreamSpeed.Y *= -1;

            tribbleorangeRect.X += (int)tribbleorangeSpeed.X;
            tribbleorangeRect.Y += (int)tribbleorangeSpeed.Y;
            if (tribbleorangeRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleorangeRect.Top < 0)
                tribbleorangeSpeed.Y *= -1;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();

            _spriteBatch.Draw(tribblegreyTexture, tribblegreyRect, Color.White);
            _spriteBatch.Draw(tribblecreamTexture, tribblecreamRect, Color.White);
            _spriteBatch.Draw(tribbleorangeTexture, tribbleorangeRect, Color.White);
            _spriteBatch.Draw(tribblebrownTexture, tribblebrownRect, Color.White);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}