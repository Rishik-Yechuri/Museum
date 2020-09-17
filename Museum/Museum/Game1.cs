using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Museum
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle rectangle;
        Texture2D texture;

        Rectangle personTangle;
        Texture2D personTure;
        Texture2D personTureDown;


        Rectangle painting;
        Texture2D paintingTexture;
        int personX;
        int personY;
        bool holdUp;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            holdUp = true;
            personX = 30;
            personY = 250;
            rectangle = new Rectangle(0,0,939,375);
            personTangle = new Rectangle(personX,personY,86,100);
            painting = new Rectangle(personX + 50,personY - 50,115,64);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = this.Content.Load<Texture2D>("museum");
            personTure = this.Content.Load<Texture2D>("handsup");
            personTureDown = this.Content.Load<Texture2D>("handsdown");
            paintingTexture = this.Content.Load<Texture2D>("painting");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (!holdUp) {
                personX -= 1;
                personTangle.X = personX;
            }
            if (personX < 645 && holdUp)
            {
                personX += 1;
                personTangle.X = personX;
                painting.X = personX + 50;
            }
            else {
                holdUp = false;
                personTangle = new Rectangle(personX, personY, 89, 100);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(texture, rectangle, Color.White);
            if (holdUp)
            {
                spriteBatch.Draw(personTure, personTangle, Color.White);
            }
            else {
                spriteBatch.Draw(personTureDown,personTangle,Color.White);
            }
            spriteBatch.Draw(paintingTexture,painting,Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
