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
    class CertificationDetailView
    {
        private Common common;
        private Form parentForm, targetForm;
        private int oNo = 0;
        private Button ok_btn, cancel_btn;
        private TextBox name_tb, number_tb, addr_tb;
        private Label name_lb, number_lb, addr_lb;
        private PictureBox image_pb;
        private Hashtable ht;

        public CertificationDetailView(Form parentForm)
        {
            this.parentForm = parentForm;
            common = new Common();
            getView();
        }

        public CertificationDetailView(Form parentForm,int oNo)
        {
            this.parentForm = parentForm;
            this.oNo = oNo;
            common = new Common();
            getView();
        }

        private void getView()
        {
            //---------------- 라벨 추가 -----------------------------
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(580, 30));
            ht.Add("color", Color.Black);
            ht.Add("name", "name_lb");
            ht.Add("text", "이름");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            name_lb = common.GetLabel(ht, parentForm);
            name_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(580, 130));
            ht.Add("color", Color.Black);
            ht.Add("name", "number_lb");
            ht.Add("text", "전화번호");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            number_lb = common.GetLabel(ht, parentForm);
            number_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(580, 230));
            ht.Add("color", Color.Black);
            ht.Add("name", "addr_lb");
            ht.Add("text", "주소");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            addr_lb = common.GetLabel(ht, parentForm);
            addr_lb.TextAlign = ContentAlignment.MiddleRight;
            //--------------- 텍스트 박스 추가 ------------------------------
            ht = new Hashtable();
            ht.Add("width", 200);
            ht.Add("point", new Point(570, 60));
            ht.Add("name", "name_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            name_tb = common.GetTextBoxf(ht, parentForm);
            name_tb.Enabled = false;

            ht = new Hashtable();
            ht.Add("width", 200);
            ht.Add("point", new Point(570, 160));
            ht.Add("name", "number_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            number_tb = common.GetTextBoxf(ht, parentForm);
            number_tb.Enabled = false;

            ht = new Hashtable();
            ht.Add("width", 200);
            ht.Add("point", new Point(570, 260));
            ht.Add("name", "addr_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            addr_tb = common.GetTextBoxf(ht, parentForm);
            addr_tb.Enabled = false;

            //------------------ 이미지 픽쳐박스 추가 ----------------------------
            ht = new Hashtable();
            ht.Add("size", new Size(550,630));
            ht.Add("point", new Point(10, 10));
            ht.Add("name", "image_pb");
            ht.Add("image", null);
            ht.Add("color", Color.AliceBlue);
            image_pb = common.GetPictureBox(ht, parentForm);

            //-------------------------- 버튼 추가 -------------------------------
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(180, 60));
            ht.Add("point", new Point(580, 500));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "ok_btn");
            ht.Add("text", "확인 후 인증");
            ht.Add("click", (EventHandler)ok_btn_click);
            ok_btn = common.GetButton(ht, parentForm);

            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(180, 60));
            ht.Add("point", new Point(580, 580));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "cancel_btn");
            ht.Add("text", "취소");
            ht.Add("click", (EventHandler)cancel_btn_click);
            cancel_btn = common.GetButton(ht, parentForm);
        }

        private void cancel_btn_click(object sender, EventArgs e)
        {
            parentForm.Close();
        }

        private void ok_btn_click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
