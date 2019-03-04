using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCS_winform.Modules;

namespace VCS_winform.Views
{
    class LoginView
    {
        private Common common;
        private Form parentForm, targetForm;
        private Button login_btn;
        private TextBox id_tb,pw_tb;
        private Label head_lb,question_lb,id_lb,pw_lb;
        private Hashtable ht;

        public LoginView(Form parentForm)
        {
            this.parentForm = parentForm;
            common = new Common();
            getView();
        }

        //화면에 띄워줄 컨트롤들을 추가해준다.
        private void getView()
        {
            // 상단 머리말 라벨 추가
            ht = new Hashtable();
            ht.Add("width",400);
            ht.Add("point", new Point(250, 50));
            ht.Add("color", Color.Black);
            ht.Add("name", "head_lb");
            ht.Add("text", "봉사인증프로그램 - 관리자용");
            ht.Add("font", new Font("맑은 고딕", 20, FontStyle.Bold));
            head_lb = common.GetLabel(ht, parentForm);
            head_lb.TextAlign = ContentAlignment.MiddleCenter;

            // 하단 문의사항 라벨 추가
            ht = new Hashtable();
            ht.Add("width", 400);
            ht.Add("point", new Point(275, 475));
            ht.Add("color", Color.Black);
            ht.Add("name", "question_lb");
            ht.Add("text", "회원문의 : 010 - 4192 - 9741\n이메일 : tldwo125@naver.com");
            ht.Add("font", new Font("맑은 고딕", 15, FontStyle.Regular));
            question_lb = common.GetLabel(ht, parentForm);
            question_lb.TextAlign = ContentAlignment.MiddleCenter;
            //id라벨
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(120, 210));
            ht.Add("color", Color.Black);
            ht.Add("name", "id_lb");
            ht.Add("text", "ID :");
            ht.Add("font", new Font("맑은 고딕", 18, FontStyle.Bold));
            id_lb = common.GetLabel(ht, parentForm);
            
            //pw라벨
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(105, 290));
            ht.Add("color", Color.Black);
            ht.Add("name", "pw_lb");
            ht.Add("text", "PW :");
            ht.Add("font", new Font("맑은 고딕", 18, FontStyle.Bold));
            pw_lb = common.GetLabel(ht, parentForm);
   
            //id 텍스트 박스 추가
            ht = new Hashtable();
            ht.Add("width", 400);
            ht.Add("point", new Point(175, 210));
            ht.Add("name", "textBox");
            ht.Add("font", new Font("맑은 고딕", 18, FontStyle.Regular));
            id_tb = common.GetTextBoxf(ht, parentForm);

            //pw 텍스트 박스 추가
            ht = new Hashtable();
            ht.Add("width", 400);
            ht.Add("point", new Point(175, 290));
            ht.Add("name", "textBox");
            ht.Add("font", new Font("맑은 고딕", 18, FontStyle.Regular));
            pw_tb = common.GetTextBoxf(ht, parentForm);
            pw_tb.PasswordChar = '●';
            //login 버튼 추가
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(150, 140));
            ht.Add("point", new Point(600, 200));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "login_btn");
            ht.Add("text", "로그인");
            ht.Add("click", (EventHandler)login_btn_click);
            login_btn = common.GetButton(ht, parentForm);

        }
        //로그인 버튼 클릭 이벤트
        private void login_btn_click(object sender, EventArgs e)
        {
            
        }
    }
}
