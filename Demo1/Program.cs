using System.Configuration;
using Demo1.Utils;

namespace Demo1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ���������ַ���
            SqlHelper.ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            // ��ʼ��
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMain());
        }
    }
}