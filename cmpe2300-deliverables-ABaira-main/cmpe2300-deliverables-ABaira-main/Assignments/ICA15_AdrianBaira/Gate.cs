using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15_AdrianBaira
{
    internal abstract class Gate
    {
        protected bool _inputOne;
        bool inputOne
        {
            get
            {
                return _inputOne;
            }
        }

        protected bool _inputTwo;
        bool inputTwo
        {
            get
            {
                return _inputTwo;
            }
        }
      

        protected bool _Output;
        public bool Output
        {
            get
            {
                return _Output;
            }
        }

        public abstract string _name
        {
            get;
        }


        public void Set(int left, int right)
        {
            if (left != 0)
                _inputOne = true;
            else
                _inputOne = false;
            if (right != 0)
                _inputTwo = true;
            else
                _inputTwo = false;
        }
        public void Set(bool left, bool right)
        {
            _inputOne = left;
            _inputTwo = right;
        }
        public abstract void Latch();
        

    }
}
