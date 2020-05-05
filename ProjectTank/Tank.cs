using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTank
{
    public abstract class Tank
    {
        public int x, y;
        public int _x = -100;
        public int _y = -100;
        private bool shotOn = false;
        public bool dead = false;
        protected byte position = 1;
        public byte health = 1;
        private const int sizeTank = 35;
        private const int sizeBull = 8;
        private const int speed = 8;
        private const int sleep = 5;
        protected Bitmap picTank;
        private Bitmap picBullet = new Bitmap(Properties.Resources.Bull);
        private Bitmap[] picBoom = new Bitmap[]
        {
            Properties.Resources._1,
            Properties.Resources._2,
            Properties.Resources._3,
            Properties.Resources._4,
            Properties.Resources._5,
            Properties.Resources._6
        };

        protected async void Shot()
        {
            await Task.Run(() =>
            {
                if (!shotOn)
                {
                    shotOn = true;
                    _x = x;
                    _x += 13;
                    _y = y;
                    _y += 13;
                    if (position == 1)
                    {
                        int sum = 600 - (600 - _y);
                        for (int i = 0; i <= sum; i++)
                        {
                            _y--;
                            Thread.Sleep(sleep);
                        }
                    }
                    else if (position == 2)
                    {
                        int sum = 630 - _y;
                        for (int i = 0; i < sum; i++)
                        {
                            _y++;
                            Thread.Sleep(sleep);
                        }
                    }
                    else if (position == 3)
                    {
                        int sum = 600 - (600 - _x);
                        for (int i = 0; i < sum; i++)
                        {
                            _x--;
                            Thread.Sleep(sleep);
                        }
                    }
                    else if (position == 4)
                    {
                        int sum = 630 - _x;
                        for (int i = 0; i < sum; i++)
                        {
                            _x++;
                            Thread.Sleep(sleep);
                        }
                    }
                    _x = -100;
                    _y = -100;
                    shotOn = false;
                }
            });
        }

        protected void MovingUp()
        {
            position = 1;
            if (!(y == 0 && x <= 600))
                y -= speed;
        }
        protected void MovingDown()
        {
            position = 2;
            if (!(y == 600 && x <= 600))
                y += speed;
        }
        protected void MovigLeft()
        {
            position = 3;
            if (!(x == 0 && y <= 600))
                x -= speed;
        }
        protected void MovingRight()
        {
            position = 4;
            if (!(x == 600 && y <= 600))
                x += speed;
        }

        public void Draw(Graphics g)
        {
            if (health == 1 || health == 2 || health == 3)
            {
                g.DrawImage(picTank, x, y, sizeTank, sizeTank);
                g.DrawImage(picBullet, _x, _y, sizeBull, sizeBull);
            }
        }

        public void DrawBoom(Graphics g)
        {
            if (!dead && health == 0)
            {
                for (int i = 0; i < picBoom.Length; i++)
                {
                    g.DrawImage(picBoom[i], x, y, sizeTank, sizeTank);
                    Thread.Sleep(10);
                }
                dead = true;
            }    
        }
    }
}
