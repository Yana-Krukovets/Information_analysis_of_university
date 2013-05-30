using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseLevel;

namespace Information_analysis_of_university
{
    public class Analisator
    {
        private string error;

        public Analisator()
        {
        }

        public void Analis()
        {
            IsCloneInformation();
        }

        //дублирование
        public List<List<FildsDocumentSource>> IsCloneInformation()
        {
            var repository = new BaseDocumentRepository<FildsDocumentSource>();

            //находим те строки, которые заполняются вручную
            var handFillField = repository.Query(x => x.DocumentDataSource == null && x.DatabaseSource == null).ToList();
            //if(handFillField.Count() != 0)
            //{
            var cloneDocumentList = new List<List<FildsDocumentSource>>();
            var alreadyFixFields = new List<int>();
            for (int i = 0; i < handFillField.Count; i++)
            {
                var lastList = handFillField.Where(x => handFillField.IndexOf(x) > i);
                var item = lastList.Where(x => x.FildId == handFillField[i].FildId && alreadyFixFields.All(y => y != x.FildId)).ToList();
                if (item.Count != 0)
                {
                    var newItemList = new List<FildsDocumentSource> { handFillField[i] };
                    newItemList.AddRange(item);
                    cloneDocumentList.Add(newItemList);

                    alreadyFixFields.Add(handFillField[i].FildId);
                }

            }
            return cloneDocumentList;
            // }
        }

        //одинаковые названия полей, но разные типы
        public List<List<FildsDocumentSource>> IsDifferentTypes()
        {
            var fieldSourceRepository = new BaseDocumentRepository<FildsDocumentSource>();
            var fieldRepository = new BaseDocumentRepository<Field>();

            var fields = fieldRepository.ToList();

            var cloneDocumentList = new List<List<FildsDocumentSource>>();
            var alreadyFixFields = new List<int>();
            for (int i = 0; i < fields.Count; i++)
            {
                var lastList = fields.Where(x => fields.IndexOf(x) > i);
                var item = lastList.Where(x => x.Name == fields[i].Name /*&& x.Name == fields[i].Name*/ && alreadyFixFields.All(y => y != x.FieldId)).ToList();
                if (item.Count != 0)
                {
                    var newItemList = fieldSourceRepository.Query(x => x.FildId == fields[i].FieldId).ToList();
                    //???
                    //newItemList.AddRange(fieldSourceRepository.Query(x => x.FildId == item.Fi));
                    cloneDocumentList.Add(newItemList);

                    alreadyFixFields.Add(fields[i].FieldId);
                }

            }
            return cloneDocumentList;
            // }
        }
    }
}
