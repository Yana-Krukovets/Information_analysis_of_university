using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;

namespace DatabaseLevel
{
    public class BaseDatabaseRepository<T> : BaseRepository<DBEntities, T> where T : EntityObject  
    {


    }
}
