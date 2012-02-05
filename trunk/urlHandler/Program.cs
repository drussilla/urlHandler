using System;
using System.Configuration;
using System.Windows.Forms;

namespace urlHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                return;
            }

            string url = args[0];

            try
            {
                if (!UrlChecker.CheckUrl(url))
                {
                    MessageBox.Show("No rule or default application for " + url);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                //Console.ReadKey();
            }
            catch (ConfigurationException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                //Console.ReadKey();
            }
        }
    }
}
