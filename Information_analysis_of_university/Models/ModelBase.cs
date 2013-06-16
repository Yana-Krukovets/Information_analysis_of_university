using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Information_analysis_of_university.Objects;

namespace Information_analysis_of_university.Models
{
    //базовый класс для моделей
    public abstract class ModelBase
    {
        //отрисовка модели
        public abstract void Draw(Graphics g);

        //отрисовка результата SQL-запроса
        public abstract void DrawSQL(Graphics g, List<string> mas);

        //отрисовка текстов
        public virtual void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 11, FontStyle.Bold), new HatchBrush(HatchStyle.Vertical, Color.Brown), x, y - 20);
        }

        //получение объекта в область которого попадает точка (х, у)
        public abstract BaseObject GetObject(int x, int y);

        //отображение ркзультатов QBE-запроса
        public abstract void DrawQbe(Graphics graphics, QbeQueryConteiner query);

        //отображение недостатков
        public abstract void ViewErrors(Graphics g, AnalisResultConteiner documents);

    }
}
