using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    class LittleMan : BaseObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }

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


    }
}
