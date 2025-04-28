using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
namespace ICA_09AdrianBaira
{
    internal class Cart
    {
        private static Random _rng = new Random();
     
        public readonly int _maxproducts;

        public Stack<char> _products { get; private set; }
        public Color _color { get; private set; }

        private bool _done;
        public bool done 
        {
            get
            {
                return _products == null || _products.Count == 0;
            }
        }

        public static int Next(int min, int max)
        {
            lock (_rng)
            {
                return _rng.Next(min, max);
            }
        }
        public char Process()
        {
            if (_products != null && _products.Count > 0)
                return _products.Pop();
            
            else
                return '0';
        }
        public Cart(string items)
        {
            _products = new Stack<char>(items);
            _color = RandColor.GetColor();
            _maxproducts = _products.Count;
        }
        public override string ToString()
        {
            string product = "";
            foreach(char i in _products)
            {
                product += i;
            }
            return $"{product}";
        }
        public void ShowCart(CDrawer canvas, Point position)
        {
            canvas?.AddRectangle(position.X, position.Y, _maxproducts, 1, _color);
            if(position.X == 0)
            {
                canvas?.AddText(this.ToString(), 10, position.X, position.Y, _maxproducts, 1, Color.White);
            }
           
            
            
        }
    }
}
