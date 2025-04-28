using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15_AdrianBaira
{
    internal class AndGate : NandGate
    {
        public override string _name => "AndGate";
        public override void Latch()
        {
            if (!(_inputOne && _inputTwo))
                _Output = false;
            else
                _Output = true;
        }
    }
}
