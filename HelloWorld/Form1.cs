namespace HelloWorld
{
    /// <summary>
    /// �����ࣺ1.�̳��Դ��� 2.�����࣬���Է�ɢд�ڲ�ͬ���ļ��У��߼�����Ʒ���
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