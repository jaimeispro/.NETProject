using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_version_app
{
    class Meeting
    {
        private string ID;
        private string title;
        private string date;
        private string time;
        private string location;
        private string attendees;
        private int[] atteIndeces= new int[50];
        private int timeInd;
        private int dateInd;

        public Meeting()
        {

        }

        public string TITLE
        {
            get { return title; }
            set { title = value; }
        }

        public string DATE
        {
            get { return date; }
            set { date = value; }
        }

        public string TIME
        {
            get { return time; }
            set { time = value; }
        }

        public string LOCATION
        {
            get { return location; }
            set { location = value; }
        }

        public string ATTENDEES
        {
            get { return attendees; }
            set { attendees = value; }
        }

        public int[] ATTEINDICES
        {
            get { return atteIndeces; }
            set { atteIndeces = value; }
        }

        public int TIMEIND
        {
            get { return timeInd; }
            set { timeInd = value; }
        }

        public int DATEIND
        {
            get { return dateInd; }
            set { dateInd = value; }
        }

        public string id
        {
            get { return ID; }
            set { ID = value; }
        }

    }
}
