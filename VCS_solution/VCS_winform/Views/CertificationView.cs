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
using static System.Windows.Forms.ListView;

namespace VCS_winform.Views
{
    class CertificationView
    {
        private Common common;
        private Form parentForm, targetForm;
        private ListView apply_lv;
        private Label lb;
        private Hashtable ht;

        public CertificationView(Form parentForm)
        {
            this.parentForm = parentForm;
            common = new Common();
            if (Program.userInfo.DNo == 3)
            {
                getView();
            }
            else
            {
                getX();
            }
        }

        private void getX()
        {
            ht = new Hashtable();
            ht.Add("width", 200);
            ht.Add("point", new Point(320, 180));
            ht.Add("color", Color.Black);
            ht.Add("name", "name_lb");
            ht.Add("text", "X 권한이 없습니다 X");
            ht.Add("font", new Font("맑은 고딕", 20, FontStyle.Bold));
            lb = common.GetLabel(ht, parentForm);
            lb.TextAlign = ContentAlignment.MiddleRight;
        }

        private void getView()
        {
            ht = new Hashtable();
            ht.Add("color", Color.White);
            ht.Add("name", "listView");
            ht.Add("point", new Point(10, 20));
            ht.Add("size", new Size(860, 340));
            ht.Add("click", (MouseEventHandler)listView_click);
            apply_lv = common.GetListView(ht, parentForm);
            apply_lv.Columns.Add("번호", 105, HorizontalAlignment.Center);
            
            apply_lv.Columns.Add("작성자", 250, HorizontalAlignment.Center);
            apply_lv.Columns.Add("작성일", 500, HorizontalAlignment.Center);
            apply_lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            apply_lv.ColumnWidthChanging += ListView_ColumnWidthChanging;
            
            getList();
        }

        private void getList()
        {
            if (Program.userInfo.DNo == 3)
            {
                WebAPI api = new WebAPI();
                if (!api.GetListView(Program.serverUrl + "api/certificationlist", apply_lv))
                {
                    MessageBox.Show("리스트 불러오기 실패");
                }
            }
        }

        private void ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = apply_lv.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void listView_click(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            SelectedListViewItemCollection col = listView.SelectedItems;
            ListViewItem item = col[0];
            //MessageBox.Show(item.SubItems[0].Text + "선택");

            // form 초기화
            if (targetForm != null) targetForm.Dispose();
            targetForm = new CertificationDetailForm(Convert.ToInt32(item.SubItems[0].Text));
            targetForm.StartPosition = parentForm.StartPosition;
            // form 호출
            targetForm.ShowDialog();
            getList();
        }
    }
}
