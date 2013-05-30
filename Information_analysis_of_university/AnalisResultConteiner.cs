using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Information_analysis_of_university
{
    public class AnalisResultConteiner : BindingList<AnalisResultItem>
    {
        public AnalisResultConteiner()
        {
            AllowNew = true;
            AllowEdit = true;
            RaiseListChangedEvents = true;
        }
    }
}
