namespace MusicApp;

public class Program
{
    public static void Main(string[] args)
    {
        List<Song> songs = new List<Song>();

        StreamReader sr = null;
        try
        {
            sr = new StreamReader(@"C:\Users\pinte\OneDrive\sznikak\hf_1\Feladat1\Input\music.txt");
            string line;
            while((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] lineItems = line.Split(';');

                string artist = lineItems[0].Trim();

                for(int i = 1; i < lineItems.Length; i++)
                {
                    Song song = new Song(artist, lineItems[i].Trim());
                    songs.Add(song);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("A fájl feldolgozása sikertelen.");
            Console.WriteLine(ex.Message);
        }
        finally 
        {
            if(sr != null) sr.Close();
        }

        foreach (Song song in songs)
            Console.WriteLine(song.ToString());
    }
}
