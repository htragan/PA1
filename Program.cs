using System;
using System.Collections.Generic;
using System.IO;

namespace PA1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMainMenu();
        }

        static void DisplayMainMenu()
        {
            List<Song> mySongs = SongFile.GetSongs();
            
            Console.WriteLine("Welcome to Big Al's Playlist! Please choose from the following: \n1. Show All Songs \n2. Add a Song \n3. Delete a Song");
            int menuSelection = int.Parse(Console.ReadLine());

            switch(menuSelection)
            {
                case 1: ShowAllSongs(mySongs);
                        DisplayMainMenu();
                        break;
                case 2: AddSong(mySongs);
                        DisplayMainMenu();
                        break;
                case 3: DeleteSong(mySongs);
                        DisplayMainMenu();
                        break;
                default: DisplayMainMenu();
                        break;
            }
        }

        static void ShowAllSongs(List<Song> mySongs)
        {
            Console.WriteLine("Here is a list of all the songs you have added:");
            Console.WriteLine();
            
            foreach(Song song in mySongs)
            {
                Console.WriteLine(song.ToString());
            }

            Console.WriteLine();
        }

        static void AddSong(List<Song> mySongs)
        {
            int songID = mySongs.Count + 1;
            
            Console.WriteLine("What is the title of the song you want to add?");
            string songName = Console.ReadLine();

            mySongs.Add(new Song(){ID = songID, Title = songName, DateAdded = DateTime.Now});

            SongFile.AddSongsToFile(mySongs);

            Console.WriteLine("You successfully added a song to your list! Sending you back to the menu...");
            Console.WriteLine();
        }

        static void DeleteSong(List<Song> mySongs)
        {
            ShowAllSongs(mySongs);

            Console.WriteLine("Enter the ID of the song you would like to delete.");
            int searchValue = int.Parse(Console.ReadLine());

            foreach(Song song in mySongs)
            {
                if(searchValue == song.ID)
                {
                    song.SetIsDeleted();
                }
            }

            SongFile.AddSongsToFile(mySongs);
        }
    }
}

    

