using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace new_version_app
{
    public partial class Newuser : Form
    {
        OleDbConnection con = new OleDbConnection();
        public Newuser()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info=False;";
        }

        private void Newuser_Load(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                CC.Text = "Connection to the DataBase is good.";
                myGlobal.updateAll();
                

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void SubmitBTN_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(myGlobal.SIZE.ToString()); //Testing Purposes
            con.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            string[] name = new string[2];
            name = FullNameBox.Text.Split(' ');//Split full name into first and last name
            if (name.Length > 1)
            {
                if(FullNameBox.Text!="" && IDBox.Text!="" && EmailBox.Text !="" && UsernameBox.Text!="" && PasswordBox.Text != "" && FullNameBox.Text != " " && IDBox.Text != " " && EmailBox.Text != " " && UsernameBox.Text != " " && PasswordBox.Text != " ")
                {
                    if(UsernameBox.Text.ToCharArray().Length>4 && PasswordBox.Text.ToCharArray().Length>4)
                    {
                        if(PasswordBox.Text.Any(char.IsDigit))
                        {
                            bool rep = false;
                            for (int i = 0; i < myGlobal.SIZE; i++)
                            {
                                if(UsernameBox.Text==myGlobal.users[i].USERNAME)
                                {
                                    rep = true;
                                }
                            }

                            if(!rep)
                            {
                                command.CommandText = "insert into Users ([ID],[firstName],[lastName],[title],[email],[Username],[Password],[Calendar]) values('" + (myGlobal.SIZE + 1).ToString() + "','" + name[0] + "','" + name[1] + "','" + IDBox.Text + "','" + EmailBox.Text + "','" + UsernameBox.Text + "','" + PasswordBox.Text + "','" + "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0|0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0" + "')";
                                command.ExecuteNonQuery();
                                MessageBox.Show("Data Saved");
                                myGlobal.activeIndex = myGlobal.getIndex(UsernameBox.Text);//This sets the new user as the active user

                                myGlobal.updateAll();
                                con.Close();
                                this.Hide();
                                MainPage main = new MainPage();
                                main.Show();
                            }
                            else
                            {
                                MessageBox.Show("Credentials already exist.");
                                con.Close();
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Password must contain at least one number");
                            con.Close();
                        }

                       
                    }
                    else
                    {
                        MessageBox.Show("Invalid input, username and password must be at least 5 characters long");
                        con.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please fill the required fields.");
                    con.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Please input at least a first and a last name.");
                con.Close();
            }
            
            


        }

        private void IDBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
