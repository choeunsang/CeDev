using CeDev.Models;
using CeDev.Models.BaseMng;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CeDev.DataMng
{
    public partial class HisPop : Form
    {
        private List<TargetItem> _list;

        public HisPop()
        {
            InitializeComponent();
        }

        public HisPop(List<TargetItem> pList): this()
        {
            _list = pList;
        }

        private void HisPop_Load(object sender, EventArgs e)
        {
            if (_list != null)
            {
                gridTarget.DataSource = _list;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
