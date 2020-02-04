using System.Data;
using MySql.Data.MySqlClient;

namespace WinFormBooking
{
    public class DBHelper
    {
        private string conStr = @"server=localhost;user id=root;pwd=vislecaina;persistsecurityinfo=True;database=mytickets";

        private MySqlConnection mysqlCon;

        // 创建数据库连接对象
        public MySqlConnection MysqlCon
        {
            get
            {
                if (mysqlCon == null)
                {
                    mysqlCon = new MySqlConnection(conStr);
                }
                return mysqlCon;
            }
        }

        /// <summary>
        /// 打开数据库
        /// </summary>
        public void OpenDB()
        {
            if (mysqlCon.State == ConnectionState.Closed)
            {
                MysqlCon.Open();
            }
            else if (mysqlCon.State == ConnectionState.Broken)
            {
                MysqlCon.Close();
                MysqlCon.Open();
            }
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        public void CloseDB()
        {
            if (mysqlCon.State == ConnectionState.Open || mysqlCon.State == ConnectionState.Broken)
            {
                MysqlCon.Close();
            }
        }
    }
}
