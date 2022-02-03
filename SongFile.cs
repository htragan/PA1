using System;
using System.IO;
using System.Collections.Generic;

namespace PA1_1
{
    public class SongFile
    {
        public static List<Song> GetSongs()
        {        
            List<Song> mySongs = new List<Song>();
            
            StreamReader inFile = null;

            try
            {
                inFile = new StreamReader("songs.txt");
                // if(inFile.ReadLine() == null)
                // {
                //     throw(new Exception("No songs in file."));
                // } 
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Something went wrong.", e);
            }

            string line = inFile.ReadLine();
            while(line!=null)
            {
                string[] temp = line.Split("#");
                int id = int.Parse(temp[0]);
                DateTime currentDate = DateTime.Parse(temp[2]);
                mySongs.Add(new Song(){ID = id, Title = temp[1], DateAdded = currentDate});
                line = inFile.ReadLine();
            }

            inFile.Close();

            return mySongs;
        }

        public static void AddSongsToFile(List<Song> mySongs)
        {
            mySongs.Sort(Song.CompareByDateAdded);

            StreamWriter outFile = new StreamWriter("songs.txt");

            foreach(Song song in mySongs)
            {
                if(song.GetIsDeleted() == false)
                {
                    outFile.WriteLine($"{song.ID}#{song.Title}#{song.DateAdded.ToShortDateString()}");
                }
            }

            outFile.Close();
        }
    }
}