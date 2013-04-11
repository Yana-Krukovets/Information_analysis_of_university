using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;

namespace DatabaseLevel
{
    public class BaseDocumentRepository<T> : BaseRepository<UniversitySystemEntities, T> where T : EntityObject  
    {

    }
}
