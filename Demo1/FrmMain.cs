namespace Demo1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var userManagerFrom = new FrmUserManager
            {
                MdiParent = this,
                Parent = splitContainer1.Panel2,
                Dock = DockStyle.Fill,
            };
            userManagerFrom.Show();
        }
    }
}