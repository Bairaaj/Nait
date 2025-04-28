using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA16_AdrianBaira
{
    internal interface IAnimatable
    {
        void Animate(CDrawer canvas);
    }
    internal interface IMortal
    {
        bool Step();
    }

}
