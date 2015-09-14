using System;

namespace VideoViewer.Model
{
    /// <summary>
    /// The model (data) class representing a single video.
    /// </summary>
    public class Video
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Published { get; set; }
    }
}