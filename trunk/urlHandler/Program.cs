/*
Manage browser launching
Copyright (C) 2012  Ivan Derevyanko aka Druss. Seven Programmers Group.

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

using System;
using System.Configuration;
using System.IO;

namespace urlHandler
{
    class Program
    {
        static void Main(string[] args)
        {
			if (args.Length != 1)
            {
				Console.WriteLine ("Wrong argument!\nUse: urlHandler.exe \"url\"");
                return;
            }

            string url = args[0];

            try
            {
                if (!UrlChecker.CheckUrl(url))
                {
					Console.WriteLine("No rule or default application for " + url);                    
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                //Console.ReadKey();
            }
            catch (ConfigurationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                //Console.ReadKey();
            }
        }
    }
}
