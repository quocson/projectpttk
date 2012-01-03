using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisReturn
{
    public class SaveDTO
    {
        private string sTheme = "Transformer";
        public string STheme
        {
            get { return sTheme; }
            set { sTheme = value; }
        }
        private string sMap = "Classic";
        public string SMap
        {
            get { return sMap; }
            set { sMap = value; }
        }
        private int iShapeMode  = 1;
        public int IShapeMode
        {
            get { return iShapeMode; }
            set { iShapeMode = value; }
        }
        private int iLevel = 1;
        public int ILevel
        {
            get { return iLevel; }
            set { iLevel = value; }
        }
        private int iLine = 0;
        public int ILine
        {
            get { return iLine; }
            set { iLine = value; }
        }
        private int iScore = 0;
        public int IScore
        {
            get { return iScore; }
            set { iScore = value; }
        }
        private int iPiece = 0;
        public int IPiece
        {
            get { return iPiece; }
            set { iPiece = value; }
        }
        private int[,] arrMap = null;
        public int[,] ArrMap
        {
            get { return arrMap; }
            set { arrMap = value; }
        }
        public SaveDTO()
        {
            arrMap = new int[Constants.map.Row, Constants.map.Column];
            for (int i = 0; i < Constants.map.Row; i++)
                for (int j = 0; j < Constants.map.Column; j++)
                    arrMap[i, j] = -1;
        }
        
    }
}
