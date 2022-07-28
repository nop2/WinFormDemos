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
            // 配置连接字符串
            SqlHelper.ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            // 初始化
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMain());
        }
    }
}