using System;
using System.Drawing;
using System.Reflection;

namespace Information_analysis_of_university.Objects
{
    //абстрактный базовый класс объекта модели
    public abstract class BaseObject
    {
        //значение координаты Х
        protected int X;
        //значение координаты Y
        protected int Y;
        //размер объекта
        protected int Size;

        protected BaseObject()
        {
            Size = 100;
        }

        //отрисовка текста
        public virtual void DrawText(Graphics g, int x, int y, string text)
        {
            g.DrawString(text, new Font("Calibri", 13, FontStyle.Bold), new SolidBrush(Color.Brown), x, y - 20);
        }

        //функция отрисовки объекта
        public abstract void DrawObject(Graphics g, int? x, int? y);
        public abstract void Drag(Point pt, System.Windows.Forms.Form wnd);
        public abstract void BeginDrag(Point pt);
        public abstract void EndDrag();
        public abstract bool IsDragging();
        //функция выполнения QBE-запроса
        public abstract bool QbeSelect(QbeQueryConteiner query);
    }

    //тип документа
    public enum DocumentType
    {
        [Description("Входящий-исходящий")]
        InputOutput = 1,
        [Description("Входящий")]
        Input = 2,
        [Description("Исходящий")]
        Output = 3

    }

    //атрибут Описания
    class Description : Attribute
    {

        public string Text;

        public Description(string text)
        {
            Text = text;
        }

        //получение значения описания
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(Description),
                                                                false);

                if (attrs != null && attrs.Length > 0)
                    return ((Description)attrs[0]).Text;

            }

            return en.ToString();
        }
    }
}
