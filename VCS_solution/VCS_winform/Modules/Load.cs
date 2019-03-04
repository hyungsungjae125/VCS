using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCS_winform.Modules
{
    class Load
    {
        private Form target;//MDI부분에서 타겟폼/현재 띄워주고 싶은 폼
        private Form parent;//MDI부분에서 부모폼
        public Load(Form target)
        {
            this.target = target;
        }

        
    }
}
