using System;
using System.Collections.ObjectModel;

namespace FFmpeg.NET.Enums
{
    //public enum AudioCodec
    //{
    //    H264,
    //    H265,
    //    HEVC,
    //    ProRes422_Proxy,
    //    ProRes422_LT,
    //    ProRes422_Normal,
    //    ProRes422_HQ,
    //    ProRes4444
    //}
    public static class AudioCodec
    {
        public static AudioCodecCollection SettingsCollection;

        public static string AAC { get { return "AAC"; } }
        public static string Vorbis { get { return "Vorbis"; } }
        public static string FLAC { get { return "FLAC"; } }
        public static string WavPack { get { return "WavPack"; } }
        public static string Opus { get { return "Opus"; } }
        public static string MP2 { get { return "MP2"; } }
        public static string MP3 { get { return "MP3"; } }
        public static string Copy { get { return "Copy"; } }
        public static string Default = AAC;

        static AudioCodec() {
            SettingsCollection = new AudioCodecCollection();
            SettingsCollection.Add(new AudioCodecEntry("AAC") {Encoder = "aac", FileExtension = ".m4a", QualityMode = "q", QualityMin=32, QualityMax=320, QualityDefault=128, QualityStep=8});
            SettingsCollection.Add(new AudioCodecEntry("MP3") { Encoder = "libmp3lame", FileExtension = ".mp3", QualityMode = "b", QualityMin = 32, QualityMax = 320, QualityDefault = 160, QualityStep = 8 });
            SettingsCollection.Add(new AudioCodecEntry("FLAC") { Encoder = "flac", FileExtension = ".flac", QualityMode= "compression_level", QualityMin = 0, QualityMax = 12, QualityDefault = 5 });
            SettingsCollection.Add(new AudioCodecEntry("Vorbis") { Encoder = "libvorbis", FileExtension = ".ogg", QualityMode = "q", QualityMin = 0, QualityMax = 10, QualityDefault = 3 });
            SettingsCollection.Add(new AudioCodecEntry("WavPack") { Encoder = "wavpack", FileExtension = ".wv", QualityMode = "compression_level", QualityMin = 0, QualityMax = 8, QualityDefault = 0 });
            SettingsCollection.Add(new AudioCodecEntry("Opus") { Encoder = "libopus", FileExtension=".opus", QualityMode = "b", QualityMin = 32000, QualityMax = 320000, QualityDefault = 128000, QualityStep = 8000 });
            SettingsCollection.Add(new AudioCodecEntry("MP2") { Encoder = "libtwolame", FileExtension = ".m2a", QualityMode = "b", QualityMin = 32, QualityMax = 320, QualityDefault = 128, QualityStep = 8 });
            SettingsCollection.Add(new AudioCodecEntry("Copy") { Encoder = "copy", FileExtension = null, QualityMode=null });
        }

        public static AudioCodecEntry Settings(string codecName)
        {
            if (SettingsCollection.Contains(codecName))
            {
                return SettingsCollection[codecName];
            }
            else
            {
                return SettingsCollection[Default];
            }
        }
    }

    
    public class AudioCodecCollection : KeyedCollection<string, AudioCodecEntry>
    {
        protected override string GetKeyForItem(AudioCodecEntry item)
        {
            // In this example, the key is the part number.
            return item.Name;
        }
    }

    [Serializable]
    public class AudioCodecEntry
    {
        /// <summary>
        /// A unique name given to this entry. This is used as the collection Key value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Encoder library used to encode preview file
        /// </summary>
        public string Encoder { get; set; }

        /// <summary>
        /// Additional codec specific arguments to be added to the output arguments
        /// </summary>
        public string OutputArgs { get; set; } = "";

        /// <summary>
        /// Default file extension
        /// </summary>
        public string FileExtension { get; set; } = null;

        public string QualityMode {get; set;} = null;
        public int QualityMin {get;set;} = 0;
        public int QualityMax {get;set;} = 51;
        public int QualityDefault {get;set;} = 18;
        public int QualityStep { get; set; } = 1;
        /// <summary>
        /// Summary of various codec specific settings to be used with ffmpeg.
        /// </summary>
        /// <param name="Name">A unique name given to this entry. This is used as the collection Key value.</param>
        public AudioCodecEntry(string Name)
        {
            this.Name = Name;
        }
    }
}
