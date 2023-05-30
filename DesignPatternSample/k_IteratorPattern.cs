using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample
{   //Iterator pattern provides a way to access elements of an aggregate object sequentially
    //without exposing its underlying representation.

    //In this example, The Iterator pattern allows us to iterate over the songs in the playlist
    //without exposing the internal structure of the playlist. It provides a consistent
    //and unified way to traverse the collection, regardless of the implementation details of the playlist.

    // Iterator interface
    public interface ISongIterator
    {
        bool HasNext();
        object Next();
    }

    // Concrete iterator
    public class PlaylistIterator : ISongIterator
    {
        private Playlist playlist;
        private int currentPosition;

        public PlaylistIterator(Playlist playlist)
        {
            this.playlist = playlist;
            currentPosition = 0;
        }

        public bool HasNext()
        {
            return currentPosition < playlist.GetSongCount();
        }

        public object Next()
        {
            if (HasNext())
            {
                var song = playlist.GetSong(currentPosition);
                currentPosition++;
                return song;
            }

            return null;
        }
    }

    // Aggregate interface
    public interface IPlaylist : IEnumerable
    {
        ISongIterator CreateIterator();
    }

    // Concrete aggregate
    public class Playlist : IPlaylist
    {
        private ArrayList songs = new ArrayList();

        public void AddSong(string song)
        {
            songs.Add(song);
        }

        public int GetSongCount()
        {
            return songs.Count;
        }

        public string? GetSong(int index)
        {
            return songs[index] as string;
        }

        public ISongIterator CreateIterator()
        {
            return new PlaylistIterator(this);
        }

        public IEnumerator GetEnumerator()
        {
            return songs.GetEnumerator();
        }
    }
}
