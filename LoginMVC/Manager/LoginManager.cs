using LoginMVC.Models;
using System;
using System.Data.SqlClient;

namespace LoginMVC.Manager
{
    public class LoginManager
    {
        string connstring = null;
        SqlConnection conn = null;

        public LoginManager()
        {
            connstring = @"DataSource=HP;InitialCatalog=BloodFynder;IntegratedSecurity=True";
            conn = new SqlConnection(connstring);
        }

        public bool CheckLogin(Register register)
        {
            bool userStatus = false;
            string cmd = "SELECT COUNT(*) FROM [Register] WHERE [UserName] = @UserName && [Password] = @Password";
            using (SqlCommand loginCmd = new SqlCommand(cmd, this.conn))
            {
                loginCmd.Parameters.AddWithValue("@UserName", register.username);
                loginCmd.Parameters.AddWithValue("@Password", register.password);
                this.conn.Open();
                int UserExist = (int)loginCmd.ExecuteScalar();
                if (UserExist > 0) {
                    userStatus = false;
                }
            }

            return userStatus;
        }

        public Register RegisterUser(Register register)
        {
            string cmdstr = "INSERT INTO ContactUs(Name,Email, UserName, Password) output INSERTED.ID VALUES(@Name,@Email, @UserName, @Password)";
            using (SqlCommand cmd = new SqlCommand(cmdstr, this.conn))
            {
                cmd.Parameters.AddWithValue("@Name", register.name);
                cmd.Parameters.AddWithValue("@Email", register.email);
                cmd.Parameters.AddWithValue("@UserName", register.username);
                cmd.Parameters.AddWithValue("@Password", register.password);
                register.id = (int)cmd.ExecuteScalar();
                if (this.conn.State == System.Data.ConnectionState.Open)
                    this.conn.Close();
                return register;
            }
        }
    }
}