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
    public partial class NewMeeting : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public NewMeeting()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info = False; ";
        }
        private void save_data_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string str = string.Empty;
                int[] check = new int[50];
                string at = "";
                foreach (int indexChecked in attendees_checkedListBox1.CheckedIndices)
                {
                    at += myGlobal.users[indexChecked].FNAME + " " + myGlobal.users[indexChecked].LNAME + ",";

                }
                
                if(attendees_checkedListBox1.CheckedIndices.Count > 0)
                {
                   
                    if(txt_meetingtitle.Text != "" && dateBox.Text != "" && timeBox.Text != "" && comboBox1.Text != "")
                    {
                        bool rep = false;
                        string pe = "";
                        foreach (int indexChecked in attendees_checkedListBox1.CheckedIndices)
                        {
                            if (myGlobal.users[indexChecked].CALENDAR[dateBox.SelectedIndex + 7][timeBox.SelectedIndex] != "0")
                            {
                                rep = true;
                                pe += myGlobal.users[indexChecked].FNAME + " " + myGlobal.users[indexChecked].LNAME + "\n";
                            }
                        }
                        if (!rep)
                        {
                            command.CommandText = "insert into CreateMeeting ([ID],[meetingTitle],[dateMeeting] ,[Time], [Location],[Attendees]) VALUES ('" + (myGlobal.meetingSIZE + 1).ToString() + "', '" + txt_meetingtitle.Text + "', '" + dateBox.SelectedItem + "', '" + timeBox.SelectedItem + "', '" + comboBox1.SelectedItem + "', '" + at + "')";
                            command.ExecuteNonQuery();
                            MessageBox.Show("Data Saved");

                            myGlobal.updateAll();
                            this.Hide();
                            MainPage main = new MainPage();
                            main.Show();

                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("The following people are not available at this time: \n" + pe);
                            
                            connection.Close();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Please fill the required fields");
                        connection.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please select at least one attendee.");
                    connection.Close();
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
                connection.Close();

            }
        }

        private void NewMeeting_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Users";
                command.CommandText = query;

                myGlobal.updateAll();

                //label7.Text = "Welcome, " + myGlobal.users[myGlobal.activeIndex].FNAME;

                OleDbDataReader reader = command.ExecuteReader();

                for(int i=0;i<myGlobal.SIZE;i++)
                {
                    attendees_checkedListBox1.Items.Add(myGlobal.users[i].FNAME+" "+ myGlobal.users[i].LNAME);
                }

              
                for (int i = 0; i < myGlobal.meetingTimes.Length; i++)
                {
                    timeBox.Items.Add(myGlobal.meetingTimes[i]);
                }

                for (int i = 0; i < myGlobal.nextWeekDays.Length; i++)
                {
                    dateBox.Items.Add(myGlobal.nextWeekDays[i]);
                }

                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);

            }
        }


        private void txt_team_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] count = new int[18];
            int max = -5;
            string output = "Most of your invited people is available at these times: ";
            //MessageBox.Show(dateBox.SelectedIndex.ToString());
            //MessageBox.Show(timeBox.SelectedIndex.ToString());
            for (int i=0;i<myGlobal.meetingTimes.Length;i++)
            {

                count[i] = 0;
                foreach (int indexChecked in attendees_checkedListBox1.CheckedIndices)
                {
                    
                    if (myGlobal.users[indexChecked].CALENDAR[(dateBox.SelectedIndex+7)][i]=="0")
                    {
                        count[i]++;
                    }
                    if(count[i]>max)
                    {
                        max = count[i];
                    }


                }


            }

            for(int i=0;i<myGlobal.meetingTimes.Length;i++)
            {
                if(count[i]==max)
                {
                    output += "\n"+myGlobal.meetingTimes[i];
                }
            }

            MessageBox.Show(output);

            

        }
    }
}
