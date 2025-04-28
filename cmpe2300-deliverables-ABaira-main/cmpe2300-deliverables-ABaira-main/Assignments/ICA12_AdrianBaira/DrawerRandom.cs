using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace ICA12_AdrianBaira
{
    internal class DrawerRandom : Random
    {
        private int _maxSize { get; set; }

        public DrawerRandom(int maxSize)
        {
            _maxSize = maxSize;
        }
        public Rectangle NextDrawerRect(CDrawer canvas)
        {
            Random rng = new Random();
            int width = rng.Next(10, _maxSize + 1);
            int height = rng.Next(10, _maxSize + 1);
            int x = rng.Next(width, canvas.m_ciWidth - width + 1);
            int y = rng.Next(height, canvas.m_ciWidth - height + 1);
         
            return new Rectangle(x, y, width, height);

        }


    }
    internal class RectDrawer: CDrawer
    {
        public RectDrawer() : base(400, 800)
        {
            DrawerRandom random = new Random();
            
        }
        
    }
}
