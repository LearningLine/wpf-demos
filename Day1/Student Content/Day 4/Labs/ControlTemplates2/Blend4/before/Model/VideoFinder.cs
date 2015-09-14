using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Windows;

namespace VideoViewer.Model
{
    public static class VideoFinder
    {
        private static readonly string[] VideoExtensions = { ".wmv", ".avi", ".mp4" };
        private static readonly string[] FileLocations = 
        {
            @"C:\Users\Public\Videos\Sample Videos",
            @"C:\Videos",
            // Add more folders here
        };

        public static List<Video> FindVideos(string searchTerm)
        {
            var files = from dir in FileLocations where Directory.Exists(dir)
                        from file in Directory.GetFiles(dir)
                        where VideoExtensions.Contains(Path.GetExtension(file).ToLower()) &&
                            (string.IsNullOrEmpty(searchTerm) || file.ToLower().Contains(searchTerm.ToLower()))
                        select new Video
                                   {
                                       Name = Path.GetFileNameWithoutExtension(file).ToUpper(),
                                       Published = File.GetCreationTime(file),
                                       Url = file
                                   };
            try
            {
                return files.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Found no files matching specified pattern.");
                return new List<Video>();
            }
        }
    }
}
