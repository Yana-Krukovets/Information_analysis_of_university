using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Information_analysis_of_university
{
    public class QbeQueryConteiner : BindingList<QbeQueryItem>
    {
        public QbeQueryConteiner()
        {
            AllowNew = true;
            AllowEdit = true;
            RaiseListChangedEvents = true;
        }
    }
}
