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
    public class BaseDocumentObject : BaseObject
    {
        protected bool dragging = false;

        //поля из бд
        [ReadOnly(true)]
        public int Id { get; set; }

        [ReadOnly(true)]
        [DisplayName("Название")]
        public string Name { get; set; }

        [ReadOnly(true)]
        [DisplayName("Назначение")]
        public string Function { get; set; }

        [ReadOnly(true)]
        [DisplayName("Периодичность")]
        public string Frequence { get; set; }

        [ReadOnly(true)]
        [DisplayName("Количество полей")]
        public int CountFilds { get; set; }

        [ReadOnly(true)]
        [DisplayName("Тип документа")]
        protected DocumentType DocType { get; set; }

        [ReadOnly(true)]
        [DisplayName("Тип документа")]
        public string DocTypeTitle { get; set; }

        [ReadOnly(true)]
        [DisplayName("Внутренний")]
        public bool IsInner { get; set; }

        [ReadOnly(true)]
        [DisplayName("Электронный")]
        public bool IsElectronic { get; set; }

        [ReadOnly(true)]
        [DisplayName("Заполняется программой")]
        public bool IsProgram { get; set; }

        [ReadOnly(true)]
        [DisplayName("Название программы")]
        public string ProgramName { get; set; }

        [Browsable(false)]
        public bool IsAlreadyDrawing { get; set; }

        [Browsable(false)]
        public WorkplaceLifeElement Workplace { get; set; }

        ////направление стрелочки
        //[Browsable(false)]
        //public bool IsWayTo { get; set; }   //true - стрелка входит

        public BaseDocumentObject(Document document)
        {
            Id = document.DocumentId;
            Name = document.Name;
            Function = document.DocFunction;
            Frequence = document.Frequence;

            if (document.Task != null)
                Workplace = new WorkplaceLifeElement(document.Post);

            if (document.Type != null) DocType = (DocumentType)document.Type;
            DocTypeTitle = Description.GetDescription(DocType);

            IsInner = document.IsExternal == 1;
            if (document.IsProgramme != null) IsProgram = (bool)document.IsProgramme;
            ProgramName = document.ProgrammeName;

            CountFilds = document.Field.Count;

            //IsWayTo = isWayTo;
            IsAlreadyDrawing = false;
            Size = 150;
        }

        //задаем значение координат
        [Browsable(false)]
        public int CoordX
        {
            get { return X; }
            set { X = value; }
        }

        [Browsable(false)]
        public int CoordY
        {
            get { return Y; }
            set { Y = value; }
        }


        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var pen = new Pen(Color.Black);

            var x1 = X;
            //if (IsWayTo)
            //    x1 = X - Size;
            //else
            //    x1 = X + Size;

            g.DrawLine(pen, x1, Y, x1 + Size, Y);
            g.FillPolygon(new SolidBrush(Color.Black), new Point[] { new Point(x1 + Size, Y), GetNewPoint(155, x1 + Size, Y), GetNewPoint(205, x1 + Size, Y) });
            //g.DrawLine(pen, new Point(x1 + Size, Y), GetNewPoint(150, x1 + Size, Y));
            //g.DrawLine(pen, new Point(x1 + Size, Y), GetNewPoint(150, x1 + Size, Y));
            DrawText(g, x1, Y, Name);
        }

        public override void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 10), new SolidBrush(Color.Gray), new RectangleF(x, y - 15, Size, 20));
        }

        protected Point GetNewPoint(int angle, int x, int y)
        {
            return new Point((int)Math.Round(x + 10 * Math.Cos(angle * 3.14 / 180), 0), (int)Math.Round(y + 10 * Math.Sin(angle * 3.14 / 180), 0));
        }

        public virtual bool IsCurrentObject(int x, int y)
        {
            var x1 = X;
            //if (IsWayTo)
            //    x1 = X - Size;
            //else
            //    x1 = X + Size;
            return x > x1 && x < x1 + Size && y > Y - 12 && y < Y + 28;
        }
        public override void Drag(Point pt, System.Windows.Forms.Form wnd)
        {
            wnd.Invalidate(false);

            X = pt.X - X;
            Y = pt.Y - Y;

            wnd.Invalidate(false);
        }

        public override void BeginDrag(Point pt)
        {
            X = pt.X - X;
            Y = pt.Y - Y;
            dragging = true;
        }

        public override void EndDrag()
        {
            dragging = false;
        }
        public override bool IsDragging()
        {
            return dragging;
        }

        public override bool QbeSelect(QbeQueryConteiner query)
        {
            //var isCorrectDocument = true;
            var isConteinsDocumentMetric = query.IsContainsDocumentMetric();
            var result = new List<bool>();
            if (isConteinsDocumentMetric)
            {
                foreach (var queryRow in query)
                {
                    result.Clear();
                    if (query.IsConteinsDocumentName() && queryRow.DocumentName != null)
                    {
                        result.Add(queryRow.DocumentName == Name);
                    }

                    if (query.IsConteinsDocumentFunction() && queryRow.DocumentFunction != null)
                    {
                        result.Add(queryRow.DocumentFunction == Function);
                    }

                    if (query.IsConteinsDocumentType() && queryRow.DocumentType != null)
                    {
                        result.Add(queryRow.DocumentType == DocTypeTitle);
                    }

                    if (query.IsConteinsFrequency() && queryRow.Frequency != null)
                    {
                        result.Add(queryRow.Frequency == Frequence);
                    }

                    //if (query.IsConteinsExternalDistination() && queryRow.ExternalDistination != null)
                    //{
                    //    result.Add(queryRow.ExternalDistination == );
                    //}

                    //if (query.IsConteinsExternalSource() && queryRow.ExternalSource != null)
                    //{
                    //    result.Add(queryRow.ExternalSource == ));
                    //}

                    if (query.IsConteinsIsElectronic())
                    {
                        result.Add(queryRow.IsElectronic == IsElectronic);
                    }

                    if (query.IsConteinsIsExternal())
                    {
                        result.Add(queryRow.IsExternal != IsInner);
                    }

                    if (query.IsConteinsIsProgram())
                    {
                        result.Add(queryRow.IsProgram == IsProgram);
                    }

                    if (query.IsConteinsProgramName() && queryRow.ProgramName != null)
                    {
                        result.Add(query.Where(x => x.ProgramName != null).Any(x => x.ProgramName == ProgramName));
                    }

                    if (result.Count == 0 || result.All(x => x))
                        break;
                }
            }
            return result.Count == 0 || result.All(x => x);
        }
    }

}
