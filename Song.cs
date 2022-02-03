using System;
using System.Collections.Generic;

namespace PA1_1
{
    public class Song
    {
        public int ID {get; set;}
        public string Title {get; set;}
        public DateTime DateAdded {get; set;}
        private bool isDeleted;

        public void SetIsDeleted()
        {
            isDeleted = true;
        }

        public bool GetIsDeleted()
        {
            return isDeleted;
        }

        public override string ToString()
        {
            return "ID: " + this.ID + " Title: " + this.Title + " Date Added: " + this.DateAdded.ToShortDateString();
        }

        public int CompareTo(Song temp)
        {
            return this.ID.CompareTo(temp.ID);
        }
        public static int CompareByDateAdded(Song x, Song y)
        {
            return y.DateAdded.CompareTo(x.DateAdded);
        }
    }
}