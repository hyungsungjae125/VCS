﻿using System;
using System.Collections;
using System.Collections.Generic;
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

        private Hashtable ht;

        public CertificationDetailView(Form parentForm)
        {
            this.parentForm = parentForm;
            common = new Common();
            getView();
        }

        private void getView()
        {

        }
    }
}
