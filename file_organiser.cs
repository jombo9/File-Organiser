using System;
using System.IO;

namespace FileOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the directory to organize
            string directoryPath = @"C:\Your\Directory\Path";

            // Organize the files in the directory
            OrganizeFiles(directoryPath);

            Console.WriteLine("File organization complete.");
            Console.ReadLine();
        }

        static void OrganizeFiles(string directoryPath)
        {
            try
            {
                // Get all files in the directory
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string filePath in files)
                {
                    // Get the extension of the file
                    string extension = Path.GetExtension(filePath).TrimStart('.');

                    // Create a directory for the extension if it doesn't exist
                    string destinationDirectory = Path.Combine(directoryPath, extension);
                    Directory.CreateDirectory(destinationDirectory);

                    // Move the file to the appropriate directory
                    string fileName = Path.GetFileName(filePath);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(filePath, destinationPath);

                    Console.WriteLine($"Moved {fileName} to {extension} directory.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
