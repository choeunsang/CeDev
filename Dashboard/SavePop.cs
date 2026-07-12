using CeDev.Models;
using CeDev.Models.BaseMng;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CeDev.DataMng
{
    public partial class SavePop : Form
    {
        private List<TargetItem> _list;

        public SavePop()
        {
            InitializeComponent();
        }

        public SavePop(List<TargetItem> plist) :this()
        {
            _list = plist;            
        }

        private void SavePop_Load(object sender, EventArgs e)
        {            
            if (_list != null)
            {                
                gridTarget.DataSource = _list;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Declare and initialize variables 
            if(string.IsNullOrEmpty(txtChgReason.Text.Trim()))
            {
                MessageBox.Show("변경사유를 먼저 입력 해 주세요.");
                return;
            }


            //Processing 
        }
    }
}
