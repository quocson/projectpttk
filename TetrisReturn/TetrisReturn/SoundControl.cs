using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace TetrisReturn
{
    public class SoundControl : IDisposable
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
            s = a.GetManifestResourceStream("TetrisReturn.Resources.Amazing.wav");
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

        public void playSoundBrilliant()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.Brilliant.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundClear()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.Clear.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundClick()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.Click.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundDis_appear()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.Dis-appear.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundExcellent()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.Excellent.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundGameOver()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.GameOver.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundGameWin()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.GameWin.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundHover()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.Hover.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundLevelUp()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.LevelUp.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundVeryGood()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.VeryGood.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundWonderful()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.Wonderful.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }

        public void playSoundWow()
        {
            player.Dispose();
            s = a.GetManifestResourceStream("TetrisReturn.Resources.Wow.wav");
            player = new SoundPlayer(s);
            try
            {
                player.LoadAsync();
            }
            catch (Exception)
            {

            }
            player.Play();
        }
    }
}
