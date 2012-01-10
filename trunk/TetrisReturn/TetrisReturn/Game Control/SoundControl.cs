using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace TetrisReturn
{
    public class SoundControl : IDisposable
    {
        private SoundPlayer amazing;
        private SoundPlayer brilliant;
        private SoundPlayer clear;
        private SoundPlayer click;
        private SoundPlayer dis_appear;
        private SoundPlayer excellent;
        private SoundPlayer gameOver;
        private SoundPlayer gameWin;
        private SoundPlayer hover;
        private SoundPlayer levelUp;
        private SoundPlayer veryGood;
        private SoundPlayer wonderful;
        private SoundPlayer wow;
        private SoundPlayer leftRightFail;
        private SoundPlayer moveLeftRight;
        private SoundPlayer rotate;
        private SoundPlayer rotateFail;
        private SoundPlayer lockShape;
        private SoundPlayer fall;
        private bool play;

        public SoundControl()
        {
            amazing = new SoundPlayer(Properties.Resources.Amazing);
            brilliant = new SoundPlayer(Properties.Resources.Brilliant);
            clear = new SoundPlayer(Properties.Resources.Clear);
            click = new SoundPlayer(Properties.Resources.Click);
            dis_appear = new SoundPlayer(Properties.Resources.Dis_appear);
            excellent = new SoundPlayer(Properties.Resources.Excellent);
            gameOver = new SoundPlayer(Properties.Resources.GameOver);
            gameWin = new SoundPlayer(Properties.Resources.GameWin);
            hover = new SoundPlayer(Properties.Resources.Hover);
            levelUp = new SoundPlayer(Properties.Resources.LevelUp);
            veryGood = new SoundPlayer(Properties.Resources.VeryGood);
            wonderful = new SoundPlayer(Properties.Resources.Wonderful);
            wow = new SoundPlayer(Properties.Resources.Wow);
            leftRightFail = new SoundPlayer(Properties.Resources.LeftRightFail);
            moveLeftRight = new SoundPlayer(Properties.Resources.MoveLeftRight);
            rotate = new SoundPlayer(Properties.Resources.Rotate);
            rotateFail = new SoundPlayer(Properties.Resources.RotateFail);
            lockShape = new SoundPlayer(Properties.Resources.Lock);
            fall = new SoundPlayer(Properties.Resources.Fall);
            play = true;
        }

        public bool Play
        {
            get { return play; }
            set { play = value; }
        }

        public void Dispose()
        {
            amazing.Dispose();
            brilliant.Dispose();
            clear.Dispose();
            click.Dispose();
            dis_appear.Dispose();
            excellent.Dispose();
            gameOver.Dispose();
            gameWin.Dispose();
            hover.Dispose();
            levelUp.Dispose();
            veryGood.Dispose();
            wonderful.Dispose();
            wow.Dispose();
            leftRightFail.Dispose();
            moveLeftRight.Dispose();
            rotate.Dispose();
            rotateFail.Dispose();
            lockShape.Dispose();
            fall.Dispose();
            GC.SuppressFinalize(this);
        }

        public void playSoundMoveLeftRight()
        {
            if (play)
                moveLeftRight.Play();
        }

        public void playSoundFall()
        {
            if (play)
                fall.Play();
        }

        public void playSoundMoveLeftRightFail()
        {
            if (play)
                leftRightFail.Play();
        }

        public void playSoundRotate()
        {
            if (play)
                rotate.Play();
        }

        public void playSoundRotateFail()
        {
            if (play)
                rotateFail.Play();
        }

        public void playSoundLockShape()
        {
            if (play)
                lockShape.Play();
        }

        public void playSoundAmazing()
        {
            if (play)
                amazing.Play();
        }

        public void playSoundBrilliant()
        {
            if (play)
                brilliant.Play();
        }

        public void playSoundClear()
        {
            if (play)
                clear.Play();
        }

        public void playSoundClick()
        {
            if (play)
                click.Play();
        }

        public void playSoundDis_appear()
        {
            if (play)
                dis_appear.Play();
        }

        public void playSoundExcellent()
        {
            if (play)
                excellent.Play();
        }

        public void playSoundGameOver()
        {
            if (play)
                gameOver.Play();
        }

        public void playSoundGameWin()
        {
            if (play)
                gameWin.Play();
        }

        public void playSoundHover()
        {
            if (play)
                hover.Play();
        }

        public void playSoundLevelUp()
        {
            if (play)
                levelUp.Play();
        }

        public void playSoundVeryGood()
        {
            if (play)
                veryGood.Play();
        }

        public void playSoundWonderful()
        {
            if (play)
                wonderful.Play();
        }

        public void playSoundWow()
        {
            if (play)
                wow.Play();
        }
    }
}
