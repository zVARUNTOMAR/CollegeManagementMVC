using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalVar
{
    public class GlobalVarClass
    {
        public int rowId { get; set; }

        public GlobalVarClass(int rowId) {
            this.rowId = rowId;
        }
    }
}
