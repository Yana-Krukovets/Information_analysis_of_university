using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using DatabaseLevel;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university.Models
{
    //базовый класс для моделей
    public abstract class ModelBase
    {
        public abstract void Draw(Graphics g);

        public abstract void DrawSQL(Graphics g, List<string> mas);

        public virtual void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 11, FontStyle.Bold), new HatchBrush(HatchStyle.Vertical, Color.Brown), x, y - 20);
        }

        public abstract BaseObject GetObject(int x, int y);

        public abstract void DrawQbe(Graphics graphics, QbeQueryConteiner query);

        public abstract void ViewErrors(Graphics g, AnalisResultConteiner documents);

    }
}
