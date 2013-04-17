using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseLevel;

namespace Information_analysis_of_university.Objects
{
    public class DocumentObject : BaseObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Function { get; set; }
        public string Frequence { get; set; }
        public int CountFilds { get; set; }

        public DocumentObject(Document document)
        {
            Id = document.DocumentId;
            Name = document.Name;
            Function = document.DocFunction;
            Frequence = document.Frequence;

            //CountFilds = 
        }

        public override void DrawObject(System.Drawing.Graphics g, int? x, int? y)
        {
            throw new NotImplementedException();
        }
    }

}
