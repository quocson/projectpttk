using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace TetrisReturn
{
    class SoundControl : IDisposable
    {
        private SoundPlayer player;
        private SoundPlayer theme;
        private System.Reflection.Assembly a;
        private System.IO.Stream s;

        public SoundControl()
        {
            player = new SoundPlayer();
            a = System.Reflection.Assembly.GetExecutingAssembly();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.Theme.wav");
            theme = new SoundPlayer(s);
        }

        public void playSoundTheme()
        {
            try
            {
                theme.LoadAsync();
                theme.PlayLooping();
            }
            catch (Exception )
            {
                
            }
        }

        public void Dispose()
        {
            player.Dispose();
            theme.Dispose();
            GC.SuppressFinalize(this);
        }

        public void stopSoundTheme()
        {
            theme.Stop();
        }

        public void stopSoundPlayer()
        {
            player.Stop();
        }

        public void playSoundAmazing()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.amazing.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception )
            {
                
            }
            player.Play();
        }
    }
}
