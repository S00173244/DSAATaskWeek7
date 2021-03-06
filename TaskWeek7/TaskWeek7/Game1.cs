﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using collectables;
using AudioPlayer;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System;
using Engine.Engines;

namespace TaskWeek7
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SoundEffectInstance player;
        Dictionary<string, Texture2D> allTextures;
        Dictionary<string, MenuOption> allMenuOptions = new Dictionary<string, MenuOption>();
        
        

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
            new InputEngine(this);
            IsMouseVisible = true;
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
            allTextures = Loader.ContentLoad<Texture2D>(this.Content, "Textures");
            AudioManager.SoundEffects = Loader.ContentLoad<SoundEffect>(this.Content, "Sounds");
            createMenuoptions();
            player = null;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            for (int i = 0; i < allMenuOptions.Count; i++)
            {
                allMenuOptions[i.ToString()].Update(gameTime);
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


            for (int i = 0; i < allMenuOptions.Count; i++)
            {
                allMenuOptions[i.ToString()].Draw(spriteBatch);
            }
            base.Draw(gameTime);
        }

        private void createMenuoptions()
        {
            int h = 0;
            int v = 1;
            for (int i = 0; i < 14; i++)
            {

                h++;
                if(GraphicsDevice.Viewport.Bounds.Contains((new Vector2(75 * h, 50 * v)))){
                    
                }
                else
                {

                    v++;
                }

                allMenuOptions.Add(i.ToString(), new MenuOption(i.ToString(), allTextures[i.ToString()], new Vector2(75 * h, 25 * v)));
            }
        }
    }
}
