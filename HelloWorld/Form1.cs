namespace HelloWorld
{
    /// <summary>
    /// 窗口类：1.继承自窗口 2.部分类，可以分散写在不同的文件中，逻辑和设计分离
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClickThis_Click(object sender, EventArgs e)
        {
            lblHelloWorld.Text = "Hello World";

        }
    }

    
}