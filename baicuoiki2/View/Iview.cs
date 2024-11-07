using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baicuoiki2.View
{
    internal interface Iview
    {
        void GetDataFromText();
        void SetDataToText(object item);
        void ClearFields();
    }
}
