using System;
using System.Collections.ObjectModel;

namespace FFmpeg.NET.Enums
{
    //public enum VideoCodec
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
    public static class VideoCodec
    {
        public static VideoCodecCollection SettingsCollection;

        public static string H264 { get { return "H264"; } }
        public static string H265 { get { return "H265"; } }
        public static string HEVC_nvenc { get { return "HEVC_nvenc"; } }
        public static string ProRes422_Proxy { get { return "ProRes422_Proxy"; } }
        public static string ProRes422_LT { get { return "ProRes422_LT"; } }
        public static string ProRes422_Normal { get { return "ProRes422_Normal"; } }
        public static string ProRes422_HQ { get { return "ProRes422_HQ"; } }
        public static string ProRes4444 { get { return "ProRes4444"; } }
        public static string ProRes4444Alpha { get { return "ProRes4444Alpha"; } }

        public static string Default = H264;

        static VideoCodec() {
            SettingsCollection = new VideoCodecCollection();
            SettingsCollection.Add(new VideoCodecEntry("H264") { 
                Encoder = "libx264", 
                FileExtension = ".mp4",
                QualityMode = "crf", QualityMin=0, QualityMax=51, QualityDefault=18
                });
            SettingsCollection.Add(new VideoCodecEntry("H265") { Encoder = "libx265", FileExtension = ".mp4" });
            SettingsCollection.Add(new VideoCodecEntry("HEVC_nvenc") { Encoder = "hevc_nvenc", OutputArgs= "-strict experimental", FileExtension=".mp4" });
            SettingsCollection.Add(new VideoCodecEntry("ProRes422_Proxy") { Encoder = "prores_ks", OutputArgs= "-profile:v 0 -pix_fmt yuv422p10", FileExtension = ".mov" });
            SettingsCollection.Add(new VideoCodecEntry("ProRes422_LT") { Encoder = "prores_ks", OutputArgs = "-profile:v 1 -pix_fmt yuv422p10", FileExtension = ".mov" });
            SettingsCollection.Add(new VideoCodecEntry("ProRes422_Normal") { Encoder = "prores_ks", OutputArgs = "-profile:v 2 -pix_fmt yuv422p10", FileExtension = ".mov" });
            SettingsCollection.Add(new VideoCodecEntry("ProRes422_HQ") { Encoder = "prores_ks", OutputArgs = "-profile:v 3 -pix_fmt yuv422p10", FileExtension = ".mov" });
            SettingsCollection.Add(new VideoCodecEntry("ProRes4444") { Encoder = "prores_ks", OutputArgs = "-profile:v 4 -pix_fmt yuv444p10", FileExtension = ".mov" });
            SettingsCollection.Add(new VideoCodecEntry("ProRes4444Alpha") { Encoder = "prores_ks", OutputArgs = "-profile:v 4 -pix_fmt yuv4444p10", FileExtension = ".mov" });
        }

        public static VideoCodecEntry Settings(string codecName)
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

    
    public class VideoCodecCollection : KeyedCollection<string, VideoCodecEntry>
    {
        protected override string GetKeyForItem(VideoCodecEntry item)
        {
            // In this example, the key is the part number.
            return item.Name;
        }
    }

    [Serializable]
    public class VideoCodecEntry
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
        public string FileExtension { get; set; }

        public string QualityMode {get; set;} = "crf";
        public int QualityMin {get;set;} = 0;
        public int QualityMax {get;set;} = 51;
        public int QualityDefault {get;set;} = 18;

        /// <summary>
        /// Summary of various codec specific settings to be used with ffmpeg.
        /// </summary>
        /// <param name="Name">A unique name given to this entry. This is used as the collection Key value.</param>
        public VideoCodecEntry(string Name)
        {
            this.Name = Name;
        }
    }
}
