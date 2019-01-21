using System;
using System.Collections.Generic;
using FFmpeg.NET.Exceptions;

namespace FFmpeg.NET.Events
{
    public class ConversionErrorEventArgs : EventArgs
    {
        public ConversionErrorEventArgs(FFmpegException exception, MediaFile input, MediaFile output, List<string> messages)
        {
            Exception = exception;
            Input = input;
            Output = output;
            Messages = messages;
        }

        public ConversionErrorEventArgs(FFmpegException exception, MediaFile input, MediaFile output)
        {
            Exception = exception;
            Input = input;
            Output = output;
            Messages = new List<string>();
        }

        public FFmpegException Exception { get; }
        public MediaFile Input { get; }
        public MediaFile Output { get; }
        public List<string> Messages { get; }
    }
}