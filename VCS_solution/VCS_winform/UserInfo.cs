using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCS_winform
{
    public class UserInfo
    {
        int mNo;//로그인 회원번호를 알기 위해
        int dNo;//회원 권한 구분을 위해서

        public UserInfo(int mNo,int dNo)
        {
            this.mNo = mNo;
            this.dNo = dNo;
        }

        public int MNo { get => mNo; }
        public int DNo { get => dNo; }
    }
}
