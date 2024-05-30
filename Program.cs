public class Program
{
    private static int choice = 0;
    private static string? filePath = String.Empty;
    private static string? userEnteredText = String.Empty;
    private static string? encryptedText = String.Empty;
    private static string? decryptedText = String.Empty;
    private static bool doesPathExist = false;

    public static void Main()
    {


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
            choice = displayMenu();

            switch (choice)
            {
                case 1:
                    Console.Write("\nEnter text: ");
                    userEnteredText = Console.ReadLine();
                    Console.WriteLine($"Text entered was: {userEnteredText}");
                    break;

                case 2:
                    Console.WriteLine("Encrypted text here");
                    if(userEnteredText == string.Empty || decryptedText == string.Empty)
                    {
                        Console.WriteLine("\nYou must enter text before you can encrypt it.");
                        Console.WriteLine("Use menu option 1 to enter text");
                        Console.WriteLine("or menu option 4 to read encrypted text from a file.");
                        break;
                    }
                    break;

                case 3:
                    Console.WriteLine("Decrypted text here");
                    if(encryptedText == string.Empty)
                    {
                        Console.WriteLine("\nYou must have encrypted text before you can decrypt it.");
                        Console.WriteLine("Either use menu option 2 to encrypt text text you've entered");
                        Console.WriteLine("or menu option 4 to read encrypted text from a file.");
                        break;
                    }
                    break;

                case 4:
                    Console.WriteLine("Read encrypted text from file");
                    if(!File.Exists(filePath))
                    {
                        Console.WriteLine("\nNo file found at the path entered.");
                        Console.WriteLine("Use menu option 5 to write encrypted text to a file.");
                        break;
                    }
                    if (filePath != null)
                    {
                        encryptedText = File.ReadAllText(filePath);
                    }
                    if(encryptedText == string.Empty)
                    {
                        Console.WriteLine("\nNo encrypted text found in the file.");
                        Console.WriteLine("Use menu option 5 to write encrypted text to a file.");
                        break;
                    }
                    break;

                case 5:
                    Console.WriteLine("Write encrypted text to file");
                    if (encryptedText == string.Empty)
                    {
                        Console.WriteLine("\nYou must have encrypted text before you can write it to a file.");
                        Console.WriteLine("Use menu option 2 to encrypt text you've entered.");
                        break;
                    }
                    break;

                case 6:
                    Console.WriteLine("Exit");
                    break;
            }

        }
        while (choice != 6);
    }

    private static int displayMenu()
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
}
