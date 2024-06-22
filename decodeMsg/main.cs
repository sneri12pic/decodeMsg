using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace decodeMsg
{
    class Program
    {
        static void Main()
        {
            // Get the directory with the executable file
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("Write name of a file to decode without .txt extension");
            string name = Console.ReadLine();
            // Combine the current directory with the path to the text file
            string message_file = Path.Combine(exeDirectory, name+=".txt");

            // Call the method to read file massage
            string fileContent = decodeMessageFile(message_file);

            // Print the file content to the console
            if (fileContent != null)
            {
                Console.WriteLine(fileContent);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("File not found.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
        static string decodeMessageFile(string message_file)
        {

            // Create a Dictionary to store digits as keys
            Dictionary<int, string> map = new Dictionary<int, string>();
            
            StringBuilder decodedMsg = new StringBuilder();

            // Ensure the file exists before trying to read it
            if (File.Exists(message_file))
            {
                try
                {
                    // Open the file for reading
                    using (StreamReader reader = new StreamReader(message_file))
                    {                
                        string line = "";
                        while((line = reader.ReadLine()) != null)
                        {
                            // Split the line to extract digit and word by saving parts after and before ' '
                            string[] parts = line.Split(' ');
                            if (parts.Length >= 2)
                            {
                                // Assuming the first part is the digit and the rest is the word
                                int key = int.Parse(parts[0]);
                                string word = string.Join(" ", parts.Skip(1));
                                map[key] = word;
                            }
                        }
                    }
                    // Sort keys in ascending order
                    var sortedKeys = map.Keys.OrderBy(k => k).ToList();
                    int index = 0; // Start from index 0
                    int step = 1; // Step size increases with each row
                    StringBuilder pyramid = new StringBuilder();
                    while (index < sortedKeys.Count)
                    {
                        int lastKey = 0;
                        for (int i = 0; i < step && index < sortedKeys.Count; i++, index++)
                        {
                            lastKey = sortedKeys[index];
                        }
                        pyramid.Append(lastKey).AppendLine(); // Append only the last key of the current step
                        step++; // Increase the step size for the next row
                    }

                    // Convert the pyramid to an integer array
                    string pyramidStr = pyramid.ToString().Trim();
                    string[] lines = pyramidStr.Split('\n');
                    int[] pyramidArr = lines.Select(line => int.Parse(line.Split(' ').Last())).ToArray();

                    for (int i = 0;i < pyramidArr.Length; i++)
                    {
                        decodedMsg.Append(map[pyramidArr[i]] + " ");
                    }
                    return decodedMsg.ToString();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during file reading
                    Console.WriteLine($"Error reading the file: {ex.Message}");
                    return null;
                }
            }
            else // File not found
            {
                return null; 
            }
        }
    
    }
}
