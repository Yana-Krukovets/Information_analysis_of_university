﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using DatabaseLevel;
using System.ComponentModel;

namespace Information_analysis_of_university.Objects
{
    class DocumentForStreams : BaseObject
    {
         private bool dragging = false;
        
        //поля из бд
        [ReadOnly(true)]
        public int Id { get; set; }

        [ReadOnly(true)]
        [DisplayName("Название")]
        public string Name { get; set; }

        [ReadOnly(true)]
        public int TaskId { get; set; }

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
        public byte? IsExternal { get; set; }

        public DocumentForStreams(Document document)
        {
            Id = document.DocumentId;
            Name = document.Name;
            Function = document.DocFunction;
            Frequence = document.Frequence;
            TaskId = document.FK_TaskId;
            Size = 150;
            IsExternal = document.IsExternal;
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
            DrawText(g, x1, Y, Name);
        }

        public override void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 11), new SolidBrush(Color.Black), new RectangleF(x, y, Size, y));
        }

        private Point GetNewPoint(int angle, int x, int y)
        {
            return new Point((int)Math.Round(x+ 10*Math.Cos(angle * 3.14 / 180), 0), (int)Math.Round(y + 10* Math.Sin(angle * 3.14 / 180), 0));
        }

        public bool IsCurrentObject(int x, int y)
        {
            var x1 = X;
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
    }
}
