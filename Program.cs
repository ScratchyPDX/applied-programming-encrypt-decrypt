public class Program
{
    public static void Main()
    {
        int choice = 0;
        string filePath = String.Empty;
        string userEnteredText = String.Empty;
        string encryptedText = String.Empty;
        string decryptedText = String.Empty;
        bool doesPathExist = false;

        do
        {
            if (filePath == string.Empty & !doesPathExist)
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
            Console.WriteLine("\n1. Enter text to use");
            Console.WriteLine("2. Encrypt text");
            Console.WriteLine("3. Decrypt text");
            Console.WriteLine("4. Read encrypted text from a file");
            Console.WriteLine("5. Write encrypted text to a file");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter text: ");
                    userEnteredText = Console.ReadLine();
                    Console.WriteLine($"Text entered was: {userEnteredText}");
                    break;

                case 2:
                    Console.WriteLine("Encrypted text here");
                    break;

                case 3:
                    Console.WriteLine("Decrypted text here");
                    break;

                case 4:
                    Console.WriteLine("Read encrypted text from file");
                    break;

                case 5:
                    Console.WriteLine("Write encrypted text to file");
                    break;

                case 6:
                    Console.WriteLine("Exit");
                    break;
            }

        }
        while (choice != 6);
    }
}
