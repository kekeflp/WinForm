using System.Data;
using System.Data.SqlClient;

namespace WinFormSuperMarket
{
    public class DBHelper
    {
        // 连接字符串
        //string conStr = @"Data Source=SuperMarket.db3;Version=3;FailIfMissing=false;PRAGMA foreign_keys=ON;";
        // "AttachDbFileName=SuperMarket.mdf"
        string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuperMarket;User ID=sa;Password=sa;";
        private SqlConnection liteCon;
        public SqlConnection LiteCon
        {
            get
            {
                if (liteCon == null)
                {
                    liteCon = new SqlConnection(conStr);
                }
                return liteCon;
            }
        }

        #region 打开或关闭数据库
        /// <summary>
        /// 打开SQLite数据库
        /// </summary>
        public void OpenDB()
        {
            if (liteCon.State == ConnectionState.Closed)
            {
                LiteCon.Open();
            }
            else if (liteCon.State == ConnectionState.Broken)
            {
                LiteCon.Close();
                LiteCon.Open();
            }
        }

        /// <summary>
        /// 关闭SQLite数据库
        /// </summary>
        public void CloseDB()
        {
            if (liteCon.State == ConnectionState.Open || liteCon.State == ConnectionState.Broken)
            {
                LiteCon.Close();
            }
        }
        #endregion
    }
}
