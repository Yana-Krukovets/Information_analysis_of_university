using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    public class DocumentObject : BaseDocumentObject
    {
        //направление стрелочки
        [Browsable(false)]
        public bool IsWayTo { get; set; }   //true - стрелка входит

        public DocumentObject(Document document, bool isWayTo) : base(document)
        {
            IsWayTo = isWayTo;
        }

        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var pen = new Pen(Color.Black);

            var x1 = X;
            if (IsWayTo)
                x1 = X - Size;
            else
                x1 = X + Size;

            g.DrawLine(pen, x1, Y, x1 + Size, Y);
            g.FillPolygon(new SolidBrush(Color.Black), new Point[] { new Point(x1 + Size, Y), GetNewPoint(155, x1 + Size, Y), GetNewPoint(205, x1 + Size, Y) });
            DrawText(g, x1, Y, Name);
        }

        public override bool IsCurrentObject(int x, int y)
        {
            var x1 = X;
            if (IsWayTo)
                x1 = X - Size;
            else
                x1 = X + Size;
            return x > x1 && x < x1 + Size && y > Y - 12 && y < Y + 28;
        }
       
    }

}
