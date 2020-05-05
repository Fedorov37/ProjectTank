using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ProjectTank
{
    class PlayerTank : Tank
    {
        public int kills;
        private int heartX = 660;
        private int heartY = 550;
        private Bitmap picHeart = new Bitmap(Properties.Resources.heart);

        public PlayerTank(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.health = 3;
            picTank = new Bitmap(Properties.Resources.MyTank);
        }

        public void ControlPlayer(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                case 'ц':
                    picTank = new Bitmap(Properties.Resources.MyTank);
                    MovingUp();
                    break;
                case 'a':
                case 'ф':
                    picTank = new Bitmap(Properties.Resources.MyTankLeft);
                    MovigLeft();
                    break;
                case 's':
                case 'ы':
                    picTank = new Bitmap(Properties.Resources.MyTankDown);
                    MovingDown();
                    break;
                case 'd':
                case 'в':
                    picTank = new Bitmap(Properties.Resources.MyTankRight);
                    MovingRight();
                    break;
                default:
                    Shot();
                    break;
            }
        }

        public void DrawLife(Graphics g)
        {
            const int interval = 35;
            const int size = 35;
            if (health >= 1)
            {
                g.DrawImage(picHeart, heartX, heartY, size, size);
            }
            if (health >= 2)
            {
                g.DrawImage(picHeart, heartX + interval, heartY, size, size);
            }
            if (health == 3)
            {
                g.DrawImage(picHeart, heartX + interval * 2, heartY, size, size);
            }
        }
    }
}
