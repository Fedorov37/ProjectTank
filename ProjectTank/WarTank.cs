using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTank
{
    class WarTank : Tank
    {
        public WarTank(int x, int y)
        {
            this.x = x;
            this.y = y;
            picTank = new Bitmap(Properties.Resources.WarTank);
        }

        public void ControlWar()
        {
            Random rand = new Random();
            int g = rand.Next(0, 45);
            if (g == 10)
            {
                MovingUp();
                picTank = new Bitmap(Properties.Resources.WarTank);
            }
            if (g == 15)
            {
                for (int i = 0; i < 2; i++)
                    MovingUp();
                picTank = new Bitmap(Properties.Resources.WarTank);
            }
            if (g == 20)
            {
                MovingDown();
                picTank = new Bitmap(Properties.Resources.WarTankDown);
            }
            if (g == 25)
            {
                for (int i = 0; i < 2; i++)
                    MovingDown();
                picTank = new Bitmap(Properties.Resources.WarTankDown);
            }
            if  (g == 30)
            {
                MovigLeft();
                picTank = new Bitmap(Properties.Resources.WarTankLeft);
            }
            if (g == 35)
            {                
                Shot();
            }
            if (g == 40)
            {
                MovingRight();
                picTank = new Bitmap(Properties.Resources.WarTankRight);
            }
            Thread.Sleep(100);
        }
    }
}
