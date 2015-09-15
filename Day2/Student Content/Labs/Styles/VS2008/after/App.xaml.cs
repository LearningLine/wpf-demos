using System;
using System.Windows;

namespace StyleSwitch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public App()
        {
            //SkinTheApp("bluetheme.xaml");
        }

        public void SkinTheApp(string skinName)
        {
            // Load the skin
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri(skinName, UriKind.Relative);

            // Remove the old skin
            if (Resources.MergedDictionaries.Count > 0)
                Resources.MergedDictionaries.Remove(Resources.MergedDictionaries[0]);

            // Add the new skin
            Resources.MergedDictionaries.Add(rd);
        }
    }
}