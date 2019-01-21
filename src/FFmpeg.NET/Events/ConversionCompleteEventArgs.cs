using System;
using System.Collections.Generic;

namespace FFmpeg.NET.Events
{
    public class ConversionCompleteEventArgs : EventArgs
    {
        public ConversionCompleteEventArgs(MediaFile input, MediaFile output)
        {
            Input = input;
            Output = output;
            Messages = new List<string>();
        }

        public ConversionCompleteEventArgs(MediaFile input, MediaFile output, List<string> messages)
        {
            Input = input;
            Output = output;
            Messages = messages;
        }

        public MediaFile Input { get; }
        public MediaFile Output { get; }
        public List<string> Messages { get; }
    }
}