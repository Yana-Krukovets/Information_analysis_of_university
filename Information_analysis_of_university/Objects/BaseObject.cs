using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Information_analysis_of_university.Objects
{
    public abstract class BaseObject
    {
        protected int X;
        protected int Y;
        protected int Size;

        public virtual void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 11, FontStyle.Bold), new HatchBrush(HatchStyle.Vertical, Color.Brown), x, y - 20);
        }

        public abstract void DrawObject(Graphics g, int? x, int? y);
    }

}
