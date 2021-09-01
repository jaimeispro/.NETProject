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
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info=False;";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {

                con.Open();
                CC.Text = "Connection to the DataBase is good.";
                myGlobal.updateAll();
                //MessageBox.Show(myGlobal.calendarToString(myGlobal.users[1]));//Testing purposes
               
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            con.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            command.CommandText = "select * from Users where Username = '" + UsernameTB.Text + "' and Password = '" + PasswordTB.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            if (count == 1)
            {
                myGlobal.activeIndex= myGlobal.getIndex(UsernameTB.Text);
                myGlobal.updateAll();
                this.Hide();
                //NewMeeting nmet = new NewMeeting();
                //nmet.Show();
                MainPage main = new MainPage();
                main.Show();

            }

            else
            {

            }


            con.Close();
        }

        private void NewUser_Click(object sender, EventArgs e)
        {
            this.Hide();

            Newuser nuser = new Newuser();        
            nuser.Show();            
                     
        }


    }

    class myGlobal
    {
        public static OleDbConnection connection = new OleDbConnection();
        
        
           
        myGlobal()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info=False;";
        }

        public static int SIZE;

        public static int meetingSIZE;
        
        public static int activeIndex;

        public static User[] users = new User[500];

        public static Meeting[] meetings = new Meeting[500];

        public static string[] meetingTimes = new string[18] { "8:00 AM", "8:30 AM", "9:00 AM", "9:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM", "12:00 PM", "12:30 PM", "1:00 PM", "1:30 PM", "2:00 PM", "2:30 PM", "3:00 PM", "3:30 PM", "4:00 PM", "4:30 PM" };

        public static string[] weekDays = new string[15];

        public static string[] wDays = new string[15];

        public static string[] nextWeekDays = new string[8];



        public static void initialize_users()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info=False;";
            connection.Open();
            for (int x = 0; x < SIZE; x++)
            {
                users[x] = new User();
                for (int i = 0; i < 15; i++)
                {
                    users[x].CALENDAR[i] = new string[18];
                }
            }

            for(int e = 0; e<meetingSIZE; e++)
            {
                meetings[e] = new Meeting();
                for(int x =0; x<50;x++)
                {
                    meetings[e].ATTEINDICES[x] = -1;
                }
            }

            

            connection.Close();

        }

        public static void updateMeeting(int x)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info=False;";
            connection.Open();
            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;
            command.CommandText = "Select * from CreateMeeting where ID = '" + (x + 1).ToString() + "' ";
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                meetings[x].id = (x + 1).ToString();
                meetings[x].TITLE = reader["meetingTitle"].ToString();
                meetings[x].TIME = reader["Time"].ToString();
                meetings[x].LOCATION = reader["Location"].ToString();
                meetings[x].ATTENDEES = reader["Attendees"].ToString();
                meetings[x].DATE = reader["dateMeeting"].ToString();
            }
            connection.Close();
        }

        public static void updateMeetings()
        {
            for(int i=0; i<meetingSIZE;i++)
            {
                updateMeeting(i);
            } 
        }

        public static void updateUser(int x)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info=False;";
            connection.Open();
            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;
            command.CommandText = "Select * from Users where ID = '" + (x + 1).ToString() + "' ";
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())

            {




                users[x].FNAME = reader["firstName"].ToString();
                users[x].LNAME = reader["lastName"].ToString();
                string[] temp_cal = reader["calendar"].ToString().Split('|');

                for(int i = 0; i < 15;i++)
                {
                    users[x].CALENDAR[i] = temp_cal[i].Split(',');
                }

                users[x].EMAIL = reader["email"].ToString();
                users[x].TITLE = reader["title"].ToString();
                users[x].USERNAME = reader["Username"].ToString();





            }
            connection.Close();
        }

        public static void updateUsers()
        {
            for (int i = 0; i < SIZE; i++)
            {
                updateUser(i);
            }
        }


        public static void getDays()
        {
            string t = "";//Testing purposes
            string n = "1";//Testing purposes
            DateTime days = DateTime.Now;
            
            for (int i = 0; i < weekDays.Length; i++)
            {
                weekDays[i] = (days.AddDays(i - 7)).ToString("dddd, dd MMMM yyyy");
                t += (weekDays[i]) + "\n";
                days = DateTime.Now;
            }

            
            for (int i = 0; i < nextWeekDays.Length; i++)
            {
                nextWeekDays[i] = (days.AddDays(i)).ToString("dddd, dd MMMM yyyy");
                n += (nextWeekDays[i]) + "\n";
                days = DateTime.Now;
            }

            for (int i = 0; i < wDays.Length; i++)
            {
                wDays[i] = (days.AddDays(i - 7)).ToString("dddd, dd MMMM ");
                t += (wDays[i]) + "\n";
                days = DateTime.Now;
            }
            //MessageBox.Show(t); //Testing purposes


        }



        public static void getSize()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info=False;";
            OleDbCommand command = new OleDbCommand();
            connection.Open();
            command.Connection =  connection;
            command.CommandText = "SELECT COUNT(*) FROM Users";
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                SIZE = reader.GetInt32(0);
                
            }

            connection.Close();


        }

        public static void getMeetings()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info=False;";
            OleDbCommand command = new OleDbCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(*) FROM CreateMeeting";
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                meetingSIZE = reader.GetInt32(0);
                
            }

            connection.Close();
        }

        public static int getIndex(string username)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info=False;";
            OleDbCommand command = new OleDbCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "Select * from Users where Username = '" + username + "' ";
            OleDbDataReader reader = command.ExecuteReader();
            int x = -1;
            while (reader.Read())
            {
                x = Int32.Parse(reader["ID"].ToString());
                
            }

            connection.Close();
            return x-1;
            
           
        }

        public static void getAttIndeces()
        {
            
            
            
            for (int i = 0;i<meetingSIZE;i++)
            {
                int count = 0;
                
                string[] atte = meetings[i].ATTENDEES.Split(',');
                for(int j = 0; j<SIZE;j++)
                {

                    for (int x = 0;x<atte.Length;x++)
                    {
                        if(atte[x]!=" "&&(atte[x] == (users[j].FNAME+" "+users[j].LNAME)))
                        {
                            meetings[i].ATTEINDICES[count] = j;
                            count++;
                        }
                    }
                }
            }
        }

        public static void getTimeInd()
        {
            for(int i=0; i<meetingSIZE;i++)
            {
                for(int j=0;j<meetingTimes.Length;j++)
                {
                    if (meetingTimes[j] == meetings[i].TIME)
                    {
                        meetings[i].TIMEIND = j;
                    }
                }
            }
        }

        public static void getDateInd()
        {
            for (int i = 0; i < meetingSIZE; i++)
            {
                for (int j = 0; j < weekDays.Length; j++)
                {
                    if (weekDays[j] == meetings[i].DATE)
                    {
                        meetings[i].DATEIND = j;
                    }
                }
            }
        }

        public static void updateCalendars()
        {
            

            for (int x=0;x<SIZE;x++)
            {
                for(int i = 0; i < 15; i++)
                {
                    for(int j=0;j<18;j++)
                    {
                        users[x].CALENDAR[i][j] = "0";
                    }
                }
                
            }

            for(int i=0;i<meetingSIZE;i++)
            {
                for(int a=0; meetings[i].ATTEINDICES[a]!=-1;a++)
                {
                    if(a!=-1)
                    {
                        users[meetings[i].ATTEINDICES[a]].CALENDAR[meetings[i].DATEIND][meetings[i].TIMEIND] = meetings[i].TITLE;
                    }
                }
            }

            

        }


        public static string calendarToString(User u)
        {
            string temp="";
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    temp+=u.CALENDAR[i][j];
                    if (j < 17)
                        temp += ',';
                }
                if (i < 14)
                    temp += '|';
            }
            return temp;
        }

        public static void updateCalDB(int i)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb;
            Persist Security Info=False;";
            connection.Open();
            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;
            command.CommandText = "update Users set Calendar='"+calendarToString(users[i]) + "'where ID = '" + (i + 1).ToString() + "' ";
            OleDbDataReader reader = command.ExecuteReader();

            connection.Close();
        }

        public static void updateCalsDB()
        {
            for(int x = 0; x < SIZE; x++)
            {
                updateCalDB(x);
            }
        }

        public static void updateAll()
        {
            myGlobal.getSize();
            myGlobal.getMeetings();
            myGlobal.initialize_users();

            myGlobal.updateMeetings();
            myGlobal.updateUsers();

            myGlobal.getAttIndeces();
            myGlobal.getDays();
            myGlobal.getTimeInd();
            myGlobal.getDateInd();

            myGlobal.updateCalendars();
            myGlobal.updateCalsDB();
        }
    }


}


