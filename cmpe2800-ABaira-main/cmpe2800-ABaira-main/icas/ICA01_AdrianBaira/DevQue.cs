using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA01_AdrianBaira
{
    internal class DevQue<T> : Queue<T>
    {
        
        public int this[string element]
        {
            get
            {
                if(this.Peek().ToString() == element)
                    return Math.Abs(element.Length - Count);

                return -1;
            }

        }
    }
}
