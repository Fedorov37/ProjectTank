using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTank
{
    public class Field
    {
        public int x, y;
        private const int size = 35;
        public Bitmap field = new Bitmap(Properties.Resources.clip1);
        Bitmap[] picBlock;

        public void Draw(Graphics g)
        {
            g.DrawImage(field,0 ,0);
        }

        public void Block(int count)
        {
            picBlock = new Bitmap[count];

            for (int i = 0; i < picBlock.Length; i++)
                picBlock[i] = Properties.Resources.blok1;
        }

        public void DrawBlock(Graphics g, int x, int y)
        {

            for (int i = 0; i < picBlock.Length; i++)
            {
                g.DrawImage(picBlock[i], x, y, size, size);
                x += size;
            }
        }
    }
}
