using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15_AdrianBaira
{
    internal class NandGate : Gate
    {
        public override string _name => "NandGate";
        public override void Latch()
        {
            if (!(_inputOne && _inputTwo))
                _Output = true;
            else
                _Output = false;
        }
    }
}
