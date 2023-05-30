using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample
{
    //The Adapter pattern allows incompatible classes to work together
    //by converting the interface of one class into another that the client expects.

    /*In this example, we have a target interface IAudioPlayer that defines the operations for playing audio files.
    The IAdvancedAudioPlayer interface represents the existing audio player interfaces that support advanced features.
    The Mp3Player and FlacPlayer classes are the adaptees that implement the IAdvancedAudioPlayer interface.
    The AudioPlayerAdapter class acts as the adapter, implementing the IAudioPlayer interface.
    It takes an instance of IAdvancedAudioPlayer in its constructor and adapts the Play method to use the methods of the IAdvancedAudioPlayer interface.
    By using the AudioPlayerAdapter, we can play different audio file formats(MP3 and FLAC in this example)
    using the common Play method from the IAudioPlayer interface. The adapter internally invokes the appropriate methods of the adaptee based on the audio type.*/

    // Target interface
    public interface IAudioPlayer
    {
        void Play(string audioType, string fileName);
    }

    // Adaptee interface
    public interface IAdvancedAudioPlayer
    {
        void LoadFile(string fileName);
        void Listen();
    }

    // Adaptee 1
    public class Mp3Player : IAdvancedAudioPlayer
    {
        public void LoadFile(string fileName)
        {
            Console.WriteLine($"Loading and decoding MP3 file: {fileName}");
        }

        public void Listen()
        {
            Console.WriteLine("Playing MP3 file");
        }
    }

    //Adaptee 1

    public class FlacPlayer : IAdvancedAudioPlayer
    {
        public void LoadFile(string fileName)
        {
            Console.WriteLine($"Loading and decoding FLAC file: {fileName}");
        }

        public void Listen()
        {
            Console.WriteLine("Playing FLAC file");
        }
    }

    //Adapter
    public class AudioPlayerAdapter : IAudioPlayer
    {
        private readonly IAdvancedAudioPlayer audioPlayer;

        public AudioPlayerAdapter(IAdvancedAudioPlayer audioPlayer)
        {
            this.audioPlayer = audioPlayer; 
        }

        public void Play(string audioType, string fileName)
        {
           if(audioType == "MP3")
            {
                audioPlayer.LoadFile(fileName);
                audioPlayer.Listen();
            }
           else if(audioType == "FLAC")
            {
                audioPlayer.LoadFile(fileName);
                audioPlayer.Listen();
            }
            else
            {
                Console.WriteLine($"Unsupported audio format: { audioType}");
            }
        }
    }
}
