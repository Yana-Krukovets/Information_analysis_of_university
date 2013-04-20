using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using DatabaseLevel;
using System.ComponentModel;

namespace Information_analysis_of_university.Objects
{
    class LittleMan : BaseObject
    {
        private bool dragging = false;
        
        [ReadOnly(true)]
        public int Id { get; set; }

        [ReadOnly(true)]
        [DisplayName("Имя исполнителя")]
        public string Name { get; set; }

        [ReadOnly(true)]
        [DisplayName("Должность исполнителя")]
        public int PostId { get; set; }

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


        public LittleMan(Worker worker)
        {
            Id = worker.WorkerId;
            Name = worker.Name;
            PostId = worker.FK_PostId;

            Size = 50;
        }

        public override void DrawObject(Graphics g, int? x, int? y)
        {
            X = x ?? X;
            Y = y ?? Y;

            var pen = new Pen(Color.Black);
            Image newImage = Image.FromFile("D:\\Diplom\\Information_analysis_of_university\\Information_analysis_of_university\\LittleMan.jpg");
            // Create rectangle for displaying image.
            Rectangle rect = new Rectangle(X, Y, Size, Size);
            // Draw image to screen.
            g.DrawImage(newImage, rect);
            DrawText(g, X - Size, Y + Size + 20, Name);
        }

        public int GetIncreaseLength(int count)
        {
            return Size / (count + 1);
        }

        public bool IsCurrentObject(int x, int y)
        {
            return x > X && x < X + Size && y > Y && y < Y + Size;
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
