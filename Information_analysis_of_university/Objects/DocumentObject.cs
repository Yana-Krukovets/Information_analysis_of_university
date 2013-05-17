using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    

    public class DocumentObject : BaseDocumentObject
    {
        //направление стрелочки
        [Browsable(false)]
        public DocumentType IsWayTo { get; set; }   //true - стрелка входит

        public DocumentObject(Document document)
            : base(document)
        {
            if (document.Type != null) IsWayTo = (DocumentType)document.Type;
            
        }

        

        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var x1 = X;

            switch (IsWayTo)
            {
                case DocumentType.InputOutput:
                    x1 = X - Size;
                    DrawArrow(g, x1);
                    x1 = X + Size;
                    DrawArrow(g, x1);
                    break;
                case DocumentType.Input:
                    x1 = X - Size;
                    DrawArrow(g, x1);
                    break;
                case DocumentType.Output:
                    x1 = X + Size;
                    DrawArrow(g, x1);
                    break;
            }
        }

        //рисование стрелок
        private void DrawArrow(Graphics g, int x)
        {
            var pen = new Pen(Color.Black);
            g.DrawLine(pen, x, Y, x + Size, Y);
            g.FillPolygon(new SolidBrush(Color.Black), new Point[] { new Point(x + Size, Y), GetNewPoint(155, x + Size, Y), GetNewPoint(205, x + Size, Y) });
            DrawText(g, x, Y, Name);
        }

        public override bool IsCurrentObject(int x, int y)
        {
            var x1 = X;
            var result = false;
            switch (IsWayTo)
            {
                case DocumentType.InputOutput:
                    x1 = X - Size;
                    result = IsThisObject(x, y, x1);
                    if (!result)
                    {
                        x1 = X + Size;
                        result = IsThisObject(x, y, x1);
                    }
                    break;

                case DocumentType.Input:
                    x1 = X - Size;
                    result = IsThisObject(x, y, x1);
                    break;

                case DocumentType.Output:
                    x1 = X + Size;
                    result = IsThisObject(x, y, x1);
                    break;
            }
            return result;
        }

        private bool IsThisObject(int x, int y, int x1)
        {
            return x > x1 && x < x1 + Size && y > Y - 12 && y < Y + 12;
        }

    }

}
