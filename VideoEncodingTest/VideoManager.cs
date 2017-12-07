using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace VideoEncodingTest
{
    public class VideoManager
    {
        public VideoManager()
        {

        }

        public string FileName { get; private set; }

        public string OutputPath { get; private set; }

        public Conversion VideoInfo { get; private set; }

        public Size FrameSize { get; private set; }

        public void LosdVideoFile(string fileName)
        {
            FileName = fileName;
            VideoInfo = new Conversion();
            VideoInfo.SetInput(fileName);
        }

        public void SetOutputFile(string outputPath)
        {
            OutputPath = outputPath;
            if (VideoInfo == null)
                throw new Exception("Please Load a Video File First");
            VideoInfo.SetOutput(outputPath);
        }

        public void SetSize(Size size)
        {
            FrameSize = size;
            if (VideoInfo == null)
                throw new Exception("Please Load a Video File First");
            VideoInfo.SetSize(size);
        }

        public void SetSize(int width, int height)
        {
            FrameSize = new Size(width, height);
            if (VideoInfo == null)
                throw new Exception("Please Load a Video File First");
            VideoInfo.SetSize(FrameSize);
        }

        public async Task<Tuple<bool, string>> TranscodeVideoFile()
        {
            string outputPath = @"C:\Users\tomne\Documents\TestVideoTranscoded.mp4";
            bool status = await VideoInfo.Start();
            return new Tuple<bool, string>(status, outputPath);
        }
    }
}
