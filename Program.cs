﻿using System.Collections;
using System.Text.RegularExpressions;

namespace std
{
    public class Program
    {
        static ArrayList validMenuOptions = new ArrayList();

        protected Program() { }

        public static void Main()
        {
            string? userEnteredText = String.Empty;
            string? filePath = String.Empty;
            string? encryptedText = String.Empty;
            string? decryptedText = String.Empty;
            bool doesPathExist = false;
            int choice = 0;
            
            do
            {
                if (filePath != null && filePath == string.Empty && !doesPathExist)
                {   string defaultFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.txt");
                    Console.WriteLine("\nBefore we begin, enter the absolute path to the file you want to read from or write to?");
                    Console.Write($"Enter the full path OR press ENTER to accept the default path of {defaultFilePath}: ");
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    filePath = Console.ReadLine();
                    if(filePath == string.Empty)
                    {
                        filePath = defaultFilePath;
                    }
                    doesPathExist = Directory.Exists(Path.GetDirectoryName(filePath));
                    if (!doesPathExist)
                    {
                        Console.Write($"The path entered does not exist: {Path.GetFullPath(filePath)}");
                        continue;
                    }
                }
                displayMenu(userEnteredText, encryptedText, decryptedText, filePath);
                
                choice = getMenuChoice();

                switch (choice)
                {   case 0:
                        // invalid input was detected. Reset menu
                        break;
                    case 1:
                        userEnteredText = getUserEnterText();
                        Console.WriteLine($"\nText entered: {userEnteredText}");
                        break;

                    case 2:
                        encryptedText = encryptText(userEnteredText, decryptedText);
                        Console.WriteLine($"\nEncrypted text: {encryptedText}");
                        break;

                    case 3:
                        decryptedText = decryptText(encryptedText);
                        Console.WriteLine($"\nDecrypted text: {decryptedText}");
                        break;

                    case 4:
                        encryptedText = readEncryptedTextFile(filePath);
                        Console.WriteLine($"\nEncrypted text read from file: {encryptedText}");
                        break;

                    case 5:
                        if(writeEncryptedTextToFile(filePath, encryptedText)) { 
                            // reinitialize variables
                            userEnteredText = string.Empty;
                            encryptedText = string.Empty;
                            decryptedText = string.Empty;
                            Console.WriteLine("\nEncrypted text written to file and apps has been reinitialized");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Exit");
                        break;
                }

            }
            while (choice != 6);
        }

        private static void displayMenu(string? userEnteredText, string encryptedText, string decryptedText, string? filePath)
        {
            Console.WriteLine();
            validMenuOptions.Clear();
            
            if(userEnteredText == string.Empty)
            {
                Console.WriteLine("1. Enter text to use");
                validMenuOptions.Add(1);
            }
            if(userEnteredText != string.Empty || decryptedText != string.Empty)
            {
                Console.WriteLine("2. Encrypt text");
                validMenuOptions.Add(2);
            }
            if(decryptedText != string.Empty || encryptedText != string.Empty)
            {
                Console.WriteLine("3. Decrypt text");
                validMenuOptions.Add(3);
            }
            if(filePath != string.Empty)
            {
                Console.WriteLine("4. Read encrypted text from a file");
                validMenuOptions.Add(4);
            }
            if(encryptedText != string.Empty)
            {
                Console.WriteLine("5. Write encrypted text to a file");
                validMenuOptions.Add(5);
            }
            Console.WriteLine("6. Exit");
            validMenuOptions.Add(6);
        }

        private static string? getUserEnterText()
        {
            Console.Write("\nEnter text: ");
            return Console.ReadLine();
        }

        private static int getMenuChoice()
        {
            Console.Write("\nEnter your choice: ");
            string? choice = Console.ReadLine();
            if(Regex.Matches(choice, @"[a-zA-Z]").Count > 0 || !validMenuOptions.Contains(Convert.ToInt32(choice)))
            {
                Console.WriteLine("\nInvalid menu choice. Please try again.");
                return 0;
            }
            return Convert.ToInt32(choice);
        }
        
        private static string encryptText(string? userEnteredText, string decryptedText)
        {
            if(userEnteredText != null){
                return Crypto.EncryptString(userEnteredText);
            }
            else if(decryptedText != string.Empty)
            {
                return Crypto.EncryptString(decryptedText);
            }
            Console.WriteLine("\nYou must enter text before you can encrypt it.");
            Console.WriteLine("Use menu option 1 to enter text");
            Console.WriteLine("or menu option 4 to read encrypted text from a file.");
            return String.Empty;
        }

        private static string decryptText(string? encryptedText)
        {
            if(encryptedText != null && encryptedText != string.Empty)
            {
                return Crypto.DecryptString(encryptedText);
            }
            Console.WriteLine("\nYou must have encrypted text before you can decrypt it.");
            Console.WriteLine("Either use menu option 2 to encrypt text text you've entered");
            Console.WriteLine("or menu option 4 to read encrypted text from a file.");
            return String.Empty;
    }

        private static string readEncryptedTextFile(string? filePath) {
            if(!File.Exists(filePath))
            {
                Console.WriteLine("\nNo file found at the path entered.");
                Console.WriteLine("Use menu option 5 to write encrypted text to a file.");
                return String.Empty;
            }
            return File.ReadAllText(filePath);
        }

        private static bool writeEncryptedTextToFile(string? filePath, string? encryptedText)
        {
            if(encryptedText == string.Empty)
            {
                Console.WriteLine("\nYou must have encrypted text before you can write it to a file.");
                Console.WriteLine("Use menu option 2 to encrypt text you've entered.");
                return false;
            }
            
            if(filePath != null)
            {
                File.WriteAllText(filePath, encryptedText);
                return true;
            }
            
            Console.WriteLine("\nInvalid file path. Please try again.");
            return false;
        }
    }
}
