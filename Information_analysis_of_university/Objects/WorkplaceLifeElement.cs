using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    public class WorkplaceLifeElement : BaseWorkplaceObject
    {
        public WorkplaceLifeElement(Post post) : base(post)
        {

        }

        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var pen = new Pen(Color.Black);

            g.DrawRectangle(pen, new Rectangle(X, Y, Size, Size));
            DrawText(g, X, Y, Name);
        }
    }
}
