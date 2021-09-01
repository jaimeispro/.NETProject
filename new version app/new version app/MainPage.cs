using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_version_app
{
    public partial class MainPage : Form
    {
        int d = 7;
        public MainPage()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            myGlobal.updateAll();
            showCal();
            string str = "";
            for (int x = 0; x < myGlobal.meetingSIZE; x++)
            {
                for (int i = 0; i < myGlobal.meetingTimes.Length; i++)
                {
                    if (myGlobal.users[myGlobal.activeIndex].CALENDAR[7][i] ==myGlobal.meetings[x].TITLE)
                    {
                        str += myGlobal.meetings[x].TITLE + "\n" + myGlobal.meetings[x].TIME + "\n" + myGlobal.meetings[x].LOCATION + "\nAtten: " + myGlobal.meetings[x].ATTENDEES + "\n\n ";
                    }
                }
                
            }
            label3.Text = str;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentCellAddress.X.ToString()) ;
            this.Hide();
            NewMeeting nmet = new NewMeeting();
            nmet.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Next Week
            if (d < 8)
            {
                d = d + 5;
                showCal();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Previous Week
            if (d > 5)
            {
                d = d - 5;
                showCal();
            }
        }
        private void showCal()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Hour", typeof(string));
            table.Columns.Add(myGlobal.wDays[d-2].ToString(), typeof(string));
            table.Columns.Add(myGlobal.wDays[d-1], typeof(string));
            table.Columns.Add(myGlobal.wDays[d], typeof(string));
            table.Columns.Add(myGlobal.wDays[d+1], typeof(string));
            table.Columns.Add(myGlobal.wDays[d+2], typeof(string));

            for (int i = 0; i < myGlobal.meetingTimes.Length; i++)
            {
                string[][] days = myGlobal.users[myGlobal.activeIndex].CALENDAR;
                if (days[d-2][i] == "0")
                    days[d-2][i] = " ";
                if (days[d-1][i] == "0")
                    days[d-1][i] = " ";
                if (days[d][i] == "0")
                    days[d][i] = " ";
                if (days[d+1][i] == "0")
                    days[d+1][i] = " ";
                if (days[d+2][i] == "0")
                    days[d+2][i] = " ";
                table.Rows.Add(myGlobal.meetingTimes[i], days[d-2][i], days[d-1][i], days[d][i], days[d+1][i], days[d+2][i]);
            }
            dataGridView1.DataSource = table;
        }
       
    }
}
