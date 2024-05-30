public class Program
{
    public static void Main()
    {
        string? userEnteredText = String.Empty;
        string? filePath = String.Empty;
        string? encryptedText = String.Empty;
        string? decryptedText = String.Empty;
        bool doesPathExist = false;
        bool textWrittenToFile = false;
        int choice = 0;
        
        do
        {
            if (filePath == string.Empty && !doesPathExist)
            {
                Console.Write("\nBefore we begin, enter the absolute path to the file you want to read from or write to: ");
                filePath = Console.ReadLine();
                doesPathExist = Directory.Exists(Path.GetDirectoryName(filePath));
                if (!doesPathExist)
                {
                    Console.Write($"The path entered does not exist: {Path.GetFullPath(filePath)}");
                    continue;
                }
            }
            choice = displayMenu(userEnteredText, encryptedText, decryptedText, filePath);

            switch (choice)
            {
                case 1:
                    userEnteredText = getUserEnterText();
                    break;

                case 2:
                    encryptedText = encryptText(userEnteredText, decryptedText);
                    break;

                case 3:
                    decryptedText = decryptText(encryptedText);
                    break;

                case 4:
                    encryptedText = readEncryptedTextFile(filePath, encryptedText);
                    break;

                case 5:
                    textWrittenToFile = writeEncryptedTextToFile(filePath, encryptedText);
                    break;

                case 6:
                    Console.WriteLine("Exit");
                    break;
            }

        }
        while (choice != 6);
    }

    private static int displayMenu(string userEnteredText, string encryptedText, string decryptedText, string filePath)
    {
        if(userEnteredText != string.Empty)
        {
            Console.WriteLine("\n1. Enter text to use");
        }
        if(userEnteredText != string.Empty || decryptedText != string.Empty)
        {
            Console.WriteLine("2. Encrypt text");
        }
        if(encryptedText != string.Empty)
        {
            Console.WriteLine("3. Decrypt text");
        }
        if(filePath != string.Empty)
        {
            Console.WriteLine("4. Read encrypted text from a file");
        }
        if(encryptedText != string.Empty)
        {
            Console.WriteLine("5. Write encrypted text to a file");
        }
        Console.WriteLine("6. Exit");
        Console.Write("\nEnter your choice: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    private static string getUserEnterText()
    {
        Console.Write("\nEnter text: ");
        string userEnteredText = Console.ReadLine();
        Console.WriteLine($"Text entered was: {userEnteredText}");
        return userEnteredText;
    }
    
    private static string encryptText(string userEnteredText, string decryptedText)
    {
        Console.WriteLine("Encrypted text here");
        if(userEnteredText == string.Empty || decryptedText == string.Empty)
        {
            Console.WriteLine("\nYou must enter text before you can encrypt it.");
            Console.WriteLine("Use menu option 1 to enter text");
            Console.WriteLine("or menu option 4 to read encrypted text from a file.");
            return String.Empty;
        }
        // TODO: encrypt text here
        return String.Empty;
    }

    private static string decryptText(string encryptedText)
    {
        Console.WriteLine("Decrypted text here");
        if(encryptedText == string.Empty)
        {
            Console.WriteLine("\nYou must have encrypted text before you can decrypt it.");
            Console.WriteLine("Either use menu option 2 to encrypt text text you've entered");
            Console.WriteLine("or menu option 4 to read encrypted text from a file.");
            return String.Empty;
        }
        // TODO: decrypt text here
        return String.Empty;
    }

    private static string readEncryptedTextFile(string filePath, string encryptedText) {
        Console.WriteLine("Read encrypted text from file");
        if(!File.Exists(filePath))
        {
            Console.WriteLine("\nNo file found at the path entered.");
            Console.WriteLine("Use menu option 5 to write encrypted text to a file.");
            return String.Empty;
        }
        if (filePath != null)
        {
            encryptedText = File.ReadAllText(filePath);
        }
        if(encryptedText == string.Empty)
        {
            Console.WriteLine("\nNo encrypted text found in the file.");
            Console.WriteLine("Use menu option 5 to write encrypted text to a file.");
            return String.Empty;
        }
        // TODO: read encrypted text from file
        return String.Empty;
    }

    private static bool writeEncryptedTextToFile(string filePath, string encryptedText)
    {
        Console.WriteLine("Write encrypted text to file");
        if(encryptedText == string.Empty)
        {
            Console.WriteLine("\nYou must have encrypted text before you can write it to a file.");
            Console.WriteLine("Use menu option 2 to encrypt text you've entered.");
            return false;
        }
        // TODO: write encrypted text to file
        return false;
    }
}
