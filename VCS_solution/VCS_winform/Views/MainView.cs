using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCS_winform.Forms;
using VCS_winform.Modules;

namespace VCS_winform.Views
{
    class MainView
    {
        private Common common;
        private Form parentForm, targetForm;
        private Button apply_btn,certi_btn,notice_btn,answer_btn;
        private Panel contents;
        private Hashtable ht;
        private int selectmenu = 1;

        public MainView(Form parentForm)
        {
            this.parentForm = parentForm;
            common = new Common();
            getView();
        }

        private void getView()
        {
            //apply모집 버튼 추가
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(200, 100));
            ht.Add("point", new Point(16, 10));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "apply_btn");
            ht.Add("text", "봉사 모집");
            ht.Add("click", (EventHandler)menu_btn_click);
            apply_btn = common.GetButton(ht, parentForm);
            //certification 버튼 추가
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(200, 100));
            ht.Add("point", new Point(232, 10));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "certi_btn");
            ht.Add("text", "외부봉사인증");
            ht.Add("click", (EventHandler)menu_btn_click);
            certi_btn = common.GetButton(ht, parentForm);
            //notice 버튼 추가
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(200, 100));
            ht.Add("point", new Point(448, 10));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "notice_btn");
            ht.Add("text", "공지");
            ht.Add("click", (EventHandler)menu_btn_click);
            notice_btn = common.GetButton(ht, parentForm);
            //answer 버튼 추가
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(200, 100));
            ht.Add("point", new Point(664, 10));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "answer_btn");
            ht.Add("text", "답변하기");
            ht.Add("click", (EventHandler)menu_btn_click);
            answer_btn = common.GetButton(ht, parentForm);

            //자식 Panel 추가 size point color name
            ht = new Hashtable();
            ht.Add("point", new Point(0,110));
            ht.Add("size", new Size(900,490));
            ht.Add("color", Color.AliceBlue);
            ht.Add("name", "contents");
            contents = common.GetPanel(ht, parentForm);
            MdiPrint();
        }

        private void menu_btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "apply_btn":
                    selectmenu = 1;
                    
                    break;
                case "certi_btn":
                    selectmenu = 2;
                    
                    break;
                case "notice_btn":
                    selectmenu = 3;
                    
                    break;
                case "answer_btn":
                    selectmenu = 4;
                     
                    break;
                default:
                    break;
            }
            MdiPrint();
        }

        private void MdiPrint()
        {
            switch (selectmenu)
            {
                case 1:
                    apply_btn.BackColor = Color.Ivory;
                    certi_btn.BackColor = Color.LightGray;
                    notice_btn.BackColor = Color.LightGray;
                    answer_btn.BackColor = Color.LightGray;

                    // form 초기화
                    if (targetForm != null) targetForm.Dispose();
                    // form 호출
                    targetForm = common.GetMdiForm(parentForm, new ApplyForm(), contents);
                    targetForm.Show();
                    break;
                case 2:
                    apply_btn.BackColor = Color.LightGray;
                    certi_btn.BackColor = Color.Ivory;
                    notice_btn.BackColor = Color.LightGray;
                    answer_btn.BackColor = Color.LightGray;

                    // form 초기화
                    if (targetForm != null) targetForm.Dispose();
                    // form 호출
                    targetForm = common.GetMdiForm(parentForm, new CertificationForm(), contents);
                    targetForm.Show();
                    break;
                case 3:
                    apply_btn.BackColor = Color.LightGray;
                    certi_btn.BackColor = Color.LightGray;
                    notice_btn.BackColor = Color.Ivory;
                    answer_btn.BackColor = Color.LightGray;

                    // form 초기화
                    if (targetForm != null) targetForm.Dispose();
                    // form 호출
                    targetForm = common.GetMdiForm(parentForm, new NoticeForm(), contents);
                    targetForm.Show();
                    break;
                case 4:
                    apply_btn.BackColor = Color.LightGray;
                    certi_btn.BackColor = Color.LightGray;
                    notice_btn.BackColor = Color.LightGray;
                    answer_btn.BackColor = Color.Ivory;

                    // form 초기화
                    if (targetForm != null) targetForm.Dispose();
                    // form 호출
                    targetForm = common.GetMdiForm(parentForm, new QuestionForm(), contents);
                    targetForm.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
