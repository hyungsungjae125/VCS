using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCS_winform.Modules
{
    class WebAPI
    {
        public string Post(string url,Hashtable ht)
        {
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection nameValue = new NameValueCollection();

                foreach(DictionaryEntry data in ht)
                {
                    nameValue.Add(data.Key.ToString(), data.Value.ToString());
                }

                byte[] result = wc.UploadValues(url, "POST", nameValue);
                string resultStr = Encoding.UTF8.GetString(result);
                return resultStr;
            }
            catch
            {
                return "";
            }
        }

        public bool GetListView(string url,ListView listView)
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);
                StreamReader sr = new StreamReader(stream);
                string result = sr.ReadToEnd();
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);
                listView.Items.Clear();

                for (int i = 0; i < list.Count; i++)
                {
                    JArray jArray = (JArray)list[i];
                    string[] arr = new string[jArray.Count];
                    for (int j = 0; j < jArray.Count; j++)
                    {
                        arr[j] = jArray[j].ToString();
                    }
                    listView.Items.Add(new ListViewItem(arr));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
