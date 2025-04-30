using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Starstorm.Sprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;

namespace Starstorm.Sound{
    class Effects{
        private ContentManager Content;
        public static SoundEffect CorrectEffect;

        public Effects(ContentManager content)
        {
            Content = content;
            CorrectEffect = Content.Load<SoundEffect>("correct_sfx");
        }
    }
    class Songs{
        private ContentManager Content;
        public Song StartMenuBackgroundMusic;

        private IServiceProvider serviceProvider;

        public Songs(ContentManager content, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            ContentManager contentManager = new ContentManager(serviceProvider, "Content");
            Content = content;
            StartMenuBackgroundMusic = Content.Load<Song>("Start.BG.Song");
        }
    }
}