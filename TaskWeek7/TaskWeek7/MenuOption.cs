using AudioPlayer;
using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWeek7
{
    public class MenuOption
    {
        public string soundKey;
        public Texture2D texture;
        public Vector2 pos;
        public Rectangle bounds;
        SoundEffectInstance player = null;
        public MenuOption(string SoundKey, Texture2D Texture, Vector2 Position)
        {
            soundKey = SoundKey;
            texture = Texture;
            pos = Position;
            bounds = new Rectangle(pos.ToPoint().X,pos.ToPoint().Y,texture.Width,texture.Height);
        }

        public void Update()
        {

            PlaySound();
        }


        public void PlaySound()
        {
            if (InputEngine.IsMouseLeftClick() && bounds.Contains(InputEngine.CurrentMouseState.Position))
            {
                //Console.WriteLine("Doing this");

                AudioManager.Play(ref player, soundKey);
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();
            spritebatch.Draw(texture, pos, Color.White);
            spritebatch.End();
        }
    
    }
}
