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
    class ApplyAddView
    {
        private Common common;
        private Form parentForm, targetForm;
        private Label name_lb, contents_lb, field_lb, place_lb, collectnum_lb, time_lb, week_lb, object_lb;
        private TextBox name_tb, contents_tb, place_tb, collectnum_tb, time_tb;
        private CheckBox mon_cb, thu_cb, wed_cb, thur_cb, fri_cb, sat_cb, sun_cb;
        private ComboBox city_combo, gu_combo, field_combo, object_combo;
        private DateTimePicker startcol_dt, endcol_dt, startvol_dt, endvol_dt;
        private Button ok_btn, cancel_btn;
        private string week = "";
        private int weekcount = 0;
        private Hashtable ht;

        public ApplyAddView(Form parentForm)
        {
            this.parentForm = parentForm;
            common = new Common();
            getView();
        }

        private void getView()
        {
            //~~~~~~~~~~~~~~~~라벨들 추가~~~~~~~~~~~~~~~~
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 30));
            ht.Add("color", Color.Black);
            ht.Add("name", "name_lb");
            ht.Add("text", "봉사활동명");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            name_lb = common.GetLabel(ht, parentForm);
            name_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 600);
            ht.Add("point", new Point(110, 25));
            ht.Add("name", "name_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            name_tb = common.GetTextBoxf(ht, parentForm);
            //==============================================================
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 70));
            ht.Add("color", Color.Black);
            ht.Add("name", "place_lb");
            ht.Add("text", "  봉사장소");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            place_lb = common.GetLabel(ht, parentForm);
            place_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 180);
            ht.Add("point", new Point(110, 65));
            ht.Add("name", "city_combo");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            city_combo = common.GetComboBox(ht, parentForm);
            city_combo.Items.Add("서울 특별시");
            city_combo.SelectedIndex = 0;
            
            ht = new Hashtable();
            ht.Add("width", 180);
            ht.Add("point", new Point(310, 65));
            ht.Add("name", "gu_combo");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            gu_combo = common.GetComboBox(ht, parentForm);
            gu_combo.Items.AddRange(new string[] {"종로구","중구", "용산구", "성동구", "광진구", "동대문구", "중랑구", "성북구", "강북구", "도봉구", "노원구", "은평구", "서대문구"
                                                 ,"마포구","양천구","강서구","구로구","금천구","영등포구","동작구","관악구","서초구","강남구","송파구","강동구"});
            gu_combo.SelectedIndex = 0;

            ht = new Hashtable();
            ht.Add("width", 200);
            ht.Add("point", new Point(510, 65));
            ht.Add("name", "place_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            place_tb = common.GetTextBoxf(ht, parentForm);
            //==============================================================
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 110));
            ht.Add("color", Color.Black);
            ht.Add("name", "field_lb");
            ht.Add("text", "  봉사분야");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            field_lb = common.GetLabel(ht, parentForm);
            field_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 180);
            ht.Add("point", new Point(110, 105));
            ht.Add("name", "field_combo");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            field_combo = common.GetComboBox(ht, parentForm);
            field_combo.Items.AddRange(new string[] { "주거환경","보건의료", "농어촌", "문화체육", "환경보호", "행정지원" });
            field_combo.SelectedIndex = 0;
            //==============================================================
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 150));
            ht.Add("color", Color.Black);
            ht.Add("name", "name_lb");
            ht.Add("text", "  모집기간");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            name_lb = common.GetLabel(ht, parentForm);
            name_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("size", new Size(180, 40));
            ht.Add("point", new Point(110, 150));
            ht.Add("name", "startcol_dt");
            startcol_dt = common.GetDateTimePicker(ht, parentForm);
            startcol_dt.Value = DateTime.Today;
            startcol_dt.Format = DateTimePickerFormat.Custom;
            startcol_dt.CustomFormat = "yyyy-MM-dd";

            ht = new Hashtable();
            ht.Add("size", new Size(180, 40));
            ht.Add("point", new Point(320, 150));
            ht.Add("name", "endcol_dt");
            endcol_dt = common.GetDateTimePicker(ht, parentForm);
            endcol_dt.Value = DateTime.Today;
            endcol_dt.Format = DateTimePickerFormat.Custom;
            endcol_dt.CustomFormat = "yyyy-MM-dd";

            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(295, 150));
            ht.Add("color", Color.Black);
            ht.Add("name", "~");
            ht.Add("text", "~");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            common.GetLabel(ht, parentForm);
            
            //==============================================================
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 190));
            ht.Add("color", Color.Black);
            ht.Add("name", "name_lb");
            ht.Add("text", "  실시기간");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            name_lb = common.GetLabel(ht, parentForm);
            name_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("size", new Size(180, 40));
            ht.Add("point", new Point(110, 190));
            ht.Add("name", "startvol_dt");
            startvol_dt = common.GetDateTimePicker(ht, parentForm);
            startvol_dt.Value = DateTime.Today;
            startvol_dt.Format = DateTimePickerFormat.Custom;
            startvol_dt.CustomFormat = "yyyy-MM-dd";

            ht = new Hashtable();
            ht.Add("size", new Size(180, 40));
            ht.Add("point", new Point(320, 190));
            ht.Add("name", "endvol_dt");
            endvol_dt = common.GetDateTimePicker(ht, parentForm);
            endvol_dt.Value = DateTime.Today;
            endvol_dt.Format = DateTimePickerFormat.Custom;
            endvol_dt.CustomFormat = "yyyy-MM-dd";

            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(295, 190));
            ht.Add("color", Color.Black);
            ht.Add("name", "~");
            ht.Add("text", "~");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            common.GetLabel(ht, parentForm);
            //==============================================================
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 230));
            ht.Add("color", Color.Black);
            ht.Add("name", "collectnum_lb");
            ht.Add("text", "  모집인원");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            collectnum_lb = common.GetLabel(ht, parentForm);
            collectnum_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 180);
            ht.Add("point", new Point(110, 225));
            ht.Add("name", "collectnum_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            collectnum_tb = common.GetTextBoxf(ht, parentForm);
            //==============================================================
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 270));
            ht.Add("color", Color.Black);
            ht.Add("name", "time_lb");
            ht.Add("text", "  봉사시간");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            time_lb = common.GetLabel(ht, parentForm);
            time_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 180);
            ht.Add("point", new Point(110, 265));
            ht.Add("name", "time_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            time_tb = common.GetTextBoxf(ht, parentForm);
            //==============================================================
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 310));
            ht.Add("color", Color.Black);
            ht.Add("name", "object_lb");
            ht.Add("text", "  봉사대상");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            object_lb = common.GetLabel(ht, parentForm);
            object_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 180);
            ht.Add("point", new Point(110, 305));
            ht.Add("name", "object_combo");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            object_combo = common.GetComboBox(ht, parentForm);
            object_combo.Items.AddRange(new string[] {"아동/청소년","장애인", "노인", "환경", "다문화가정"});
            object_combo.SelectedIndex = 0;
            //==============================================================
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(310, 230));
            ht.Add("color", Color.Black);
            ht.Add("name", "week_lb");
            ht.Add("text", "봉사요일");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            week_lb = common.GetLabel(ht, parentForm);
            week_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("point", new Point(420, 227));
            ht.Add("text", "월");
            ht.Add("name", "mon_cb");
            mon_cb = common.GetCheckBox(ht, parentForm);

            ht = new Hashtable();
            ht.Add("point", new Point(470, 227));
            ht.Add("text", "화");
            ht.Add("name", "thu_cb");
            thu_cb = common.GetCheckBox(ht, parentForm);

            ht = new Hashtable();
            ht.Add("point", new Point(520, 227));
            ht.Add("text", "수");
            ht.Add("name", "wed_cb");
            wed_cb = common.GetCheckBox(ht, parentForm);

            ht = new Hashtable();
            ht.Add("point", new Point(570, 227));
            ht.Add("text", "목");
            ht.Add("name", "thur_cb");
            thur_cb = common.GetCheckBox(ht, parentForm);

            ht = new Hashtable();
            ht.Add("point", new Point(420, 267));
            ht.Add("text", "금");
            ht.Add("name", "fri_cb");
            fri_cb = common.GetCheckBox(ht, parentForm);

            ht = new Hashtable();
            ht.Add("point", new Point(470, 267));
            ht.Add("text", "토");
            ht.Add("name", "sat_cb");
            sat_cb = common.GetCheckBox(ht, parentForm);

            ht = new Hashtable();
            ht.Add("point", new Point(520, 267));
            ht.Add("text", "일");
            ht.Add("name", "sun_cb");
            sun_cb = common.GetCheckBox(ht, parentForm);

            //==============================================================
            ht = new Hashtable();
            ht.Add("width", 50);
            ht.Add("point", new Point(10, 350));
            ht.Add("color", Color.Black);
            ht.Add("name", "contents_lb");
            ht.Add("text", "  봉사내용");
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Regular));
            contents_lb = common.GetLabel(ht, parentForm);
            contents_lb.TextAlign = ContentAlignment.MiddleRight;

            ht = new Hashtable();
            ht.Add("width", 600);
            ht.Add("point", new Point(110, 345));
            ht.Add("name", "contents_tb");
            ht.Add("font", new Font("맑은 고딕", 13, FontStyle.Regular));
            contents_tb = common.GetTextBoxf(ht, parentForm);
            contents_tb.Multiline = true;
            contents_tb.Height = 200;

            //====================버튼추가===================================
            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(150, 80));
            ht.Add("point", new Point(390, 560));
            ht.Add("color", Color.LightGray);
            ht.Add("name", "ok_btn");
            ht.Add("text", "모집등록");
            ht.Add("click", (EventHandler)ok_btn_click);
            ok_btn = common.GetButton(ht, parentForm);

            ht = new Hashtable();
            ht.Add("font", new Font("맑은 고딕", 12, FontStyle.Bold));
            ht.Add("size", new Size(150, 80));
            ht.Add("point", new Point(560, 560));
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
            WebAPI api = new WebAPI();

            ht = new Hashtable();
            ht.Add("mno", Program.userInfo.MNo);
            ht.Add("name",name_tb.Text);
            ht.Add("contents", contents_tb.Text);
            ht.Add("city", city_combo.Text);
            ht.Add("gu", gu_combo.Text);
            ht.Add("field", field_combo.Text);
            ht.Add("place", place_tb.Text);
            ht.Add("startcollect", startcol_dt.Text);
            ht.Add("endcollect", endcol_dt.Text);
            ht.Add("startvol", startvol_dt.Text);
            ht.Add("endvol", endvol_dt.Text);
            ht.Add("collectnum", collectnum_tb.Text);
            ht.Add("time", time_tb.Text);
            if(mon_cb.Checked || thu_cb.Checked || wed_cb.Checked || thur_cb.Checked || fri_cb.Checked || sat_cb.Checked || sun_cb.Checked)
            {
                if (mon_cb.Checked)
                {
                    weekcount++;
                    week += mon_cb.Text;
                }
                if (thu_cb.Checked)
                {
                    weekcount++;
                    week += thu_cb.Text;
                }
                if (wed_cb.Checked)
                {
                    weekcount++;
                    week += wed_cb.Text;
                }
                if (thur_cb.Checked)
                {
                    weekcount++;
                    week += thur_cb.Text;
                }
                if (fri_cb.Checked)
                {
                    weekcount++;
                    week += fri_cb.Text;
                }
                if (sat_cb.Checked)
                {
                    weekcount++;
                    week += sat_cb.Text;
                }
                if (sun_cb.Checked)
                {
                    weekcount++;
                    week += sun_cb.Text;
                }
            }
            ht.Add("week", week);
            ht.Add("vobject", object_combo.Text);
            ht.Add("count", weekcount);
            string result = api.Post(Program.serverUrl + "api/volunteerlistinsert", ht);
            //MessageBox.Show(result);
            parentForm.Close();
        }
    }
}
