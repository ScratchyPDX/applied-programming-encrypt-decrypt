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
            choice = displayMenu(userEnteredText, encryptedText, decryptedText, filePath);

            switch (choice)
            {
                case 1:
                    userEnteredText = getUserEnterText();
                    break;

                case 2:
                    encryptedText = encryptText(userEnteredText, decryptedText);
                    Console.WriteLine($"\nEncrypted text: {encryptedText}");
                    break;

                case 3:
                    decryptedText = decryptText(encryptedText);
                    break;

                case 4:
                    encryptedText = readEncryptedTextFile(filePath);
                    break;

                case 5:
                    textWrittenToFile = writeEncryptedTextToFile(filePath, encryptedText);
                    if(textWrittenToFile) { 
                        // reinitialize variables
                        userEnteredText = string.Empty;
                        encryptedText = string.Empty;
                        decryptedText = string.Empty;
                    }
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
        Console.WriteLine($"displayMenu: userEnteredText: {userEnteredText}");
        Console.WriteLine($"displayMenu: encryptedText: {encryptedText}");
        Console.WriteLine($"displayMenu: decryptedText: {decryptedText}");
        Console.WriteLine($"displayMenu: filePath: {filePath}");
        Console.WriteLine();
        
        if(userEnteredText == string.Empty)
        {
            Console.WriteLine("1. Enter text to use");
        }
        if(userEnteredText != string.Empty || decryptedText != string.Empty)
        {
            Console.WriteLine("2. Encrypt text");
        }
        if(decryptedText != string.Empty || encryptedText != string.Empty)
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
        if(userEnteredText == string.Empty && decryptedText == string.Empty)
        {
            Console.WriteLine("\nYou must enter text before you can encrypt it.");
            Console.WriteLine("Use menu option 1 to enter text");
            Console.WriteLine("or menu option 4 to read encrypted text from a file.");
            return String.Empty;
        }
        string encryptedText = Crypto.EncryptString(userEnteredText);
        Console.WriteLine($"encryptText: encrypted text: {encryptedText}");
        return encryptedText;
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
        string decryptedText = Crypto.DecryptString(encryptedText);
        Console.WriteLine($"decryptText: decrypted text: {decryptedText}");
        return decryptedText;
    }

    private static string readEncryptedTextFile(string filePath) {
        Console.WriteLine("Read encrypted text from file");
        string encryptedTextReadFromFile = string.Empty;
        if(!File.Exists(filePath))
        {
            Console.WriteLine("\nNo file found at the path entered.");
            Console.WriteLine("Use menu option 5 to write encrypted text to a file.");
            return String.Empty;
        }
        if (filePath != null)
        {
            encryptedTextReadFromFile = File.ReadAllText(filePath);
            Console.WriteLine($"readEncryptedTextFile: Encrypted text read from file: {encryptedTextReadFromFile}");
        }
        return encryptedTextReadFromFile;
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
        File.WriteAllText(filePath, encryptedText);
        Console.WriteLine("Text written to file.");
        return true;
    }
}
