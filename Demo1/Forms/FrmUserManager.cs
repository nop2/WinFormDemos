using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo1.Models;

namespace Demo1
{
    public partial class FrmUserManager : Form
    {
        public FrmUserManager()
        {
            InitializeComponent();
        }

        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            InitAppraisalBaseList();
        }

        /// <summary>
        /// 初始化人员类型列表
        /// </summary>
        private void InitAppraisalBaseList()
        {
            var appraisalBaseList = new List<AppraisalBases>()
            {
                new()
                {
                    Id = 0,
                    BaseType = "-选择所有-",
                    AppraisalBase = 0,
                    IsDel = false,
                }
            };
            appraisalBaseList.AddRange(AppraisalBases.ListAll());
            cbxAppraisalBase.DataSource = appraisalBaseList;
            cbxAppraisalBase.DisplayMember = "BaseType";
            cbxAppraisalBase.ValueMember = "Id";
        }
    }
}