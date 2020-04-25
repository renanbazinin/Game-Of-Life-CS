using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Cell
    {
        private bool isAlive;
        private int rowNum;
        private int colNum;

        public Cell (bool isAlive, int rowNum, int colNum)
        {
            this.isAlive = isAlive;
            this.rowNum = rowNum;
            this.colNum = colNum;
        }

        public void ToggleStatus()
        {
            isAlive = (isAlive)?  false :  true;
        }

        public void SetNewStatus(bool alive)
        {
            isAlive = alive;
        }
        public void Resurrect()
        {
            isAlive = true;
        }


        public bool IsAlive()
        {
            return isAlive;
        }

        public int GetRow()
        {
            return rowNum;
        }

        public int GetCol()
        {
            return colNum;
        }
    }
}
