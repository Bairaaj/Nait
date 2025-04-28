using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDraw_Client
{
    internal class LineSegment
    {
        // start position
        public Int16 SX { get; set; }
        public Int16 SY { get; set; }
        // end position
        public Int16 EX { get; set; }
        public Int16 EY { get; set; }
        // colour (can be composed of alpha and color)
        public Color C { get; set; }
        // line thickness
        public byte T { get; set; }
        // render me to a suitable Graphics
        public void Render(Graphics gr)
        {
            using (Pen p = new Pen(C, T))
            {
                p.SetLineCap(
                System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.DashCap.Round);
                gr.DrawLine(p, new PointF(SX, SY), new PointF(EX, EY));
            }
        }

        // turn me (this) into a JSON string
        public string LineSegmentToJSON()
        {
            try
            {
                string s = JsonConvert.SerializeObject(this);
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return string.Empty;
        }
        // turn a JSON string into a LineSegment, with sanity test
        public static LineSegment JSONToLineSegment(string json)
        {
            try
            {
                LineSegment seg = JsonConvert.DeserializeObject<LineSegment>(json);
                if (seg != null)
                    if (IsSane(seg))
                        return seg;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            return null;
        }
        // approximate sanity checking to ensure that what was
        // JSON decoded has valid(ish) data
        public static bool IsSane(LineSegment ls)
        {
            if (ls == null)
                return false;
            if (ls.SX > 10000)
                return false;
            if (ls.SY > 10000)
                return false;
            if (ls.EX > 10000)
                return false;
            if (ls.EY > 10000)
                return false;
            if (ls.SX < -10000)
                return false;
            if (ls.SY < -10000)
                return false;
            if (ls.EX < -10000)
                return false;
            if (ls.EY < -10000)
                return false;
            if (ls.T == 0)
                return false;
            return true;
        }
      
    }
}
