using System.ComponentModel;
using System.Drawing;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    //класс документа (отображение в виде стрелочки)
    public class DocumentObject : BaseDocumentObject
    {
        //направление стрелочки
        [Browsable(false)]
        public DocumentType IsWayTo { get; set; }   //true - стрелка входит

        [Browsable(false)]
        public bool IsError { get; set; }

        [ReadOnly(true)]
        [DisplayName("Текст ошибки")]
        public string ErrorText { get; set; }

        public DocumentObject(Document document)
            : base(document)
        {
            if (document.Type != null) IsWayTo = (DocumentType)document.Type;
            IsError = false;
            ErrorText = "";
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
            var color = Color.Black;
            if(IsError)
                color = Color.Red;
            var pen = new Pen(color);
            g.DrawLine(pen, x, Y, x + Size, Y);
            g.FillPolygon(new SolidBrush(color), new Point[] { new Point(x + Size, Y), GetNewPoint(155, x + Size, Y), GetNewPoint(205, x + Size, Y) });
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
