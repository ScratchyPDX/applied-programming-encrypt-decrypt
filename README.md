# Overview

This program uses the ability built-in to C# to encrypt and decrypt text. Optionally, it can also write the encrypted to text to a file or read the text from a file. Since this is a console project, a menu has been implemented, and conditional logic has been added to present the actively available options. Exception handling has been added to ensure users cannot select an invalid option, and to ensure that necessary data properties are not null when used.

This project uses AES for symmetric encryption. AES (Advanced Encryption Standard) is a symmetric encryption algorithm established by the U.S. National Institute of Standards and Technology (NIST) in 2001. It is widely regarded as the most secure symmetric encryption algorithm available today.

AES operates on blocks of data and uses a secret key that is either 128, 192, or 256 bits long. The same key is used for both encryption and decryption, which is why it's referred to as symmetric encryption.

AES uses a series of transformations, including substitution, permutation, and mixing, to convert plaintext data into encrypted ciphertext. These transformations are repeated over multiple rounds to ensure a high level of security.

Despite its complexity, AES is efficient and can be implemented on various platforms, making it a popular choice for securing sensitive data.



{Provide a link to your YouTube demonstration. It should be a 4-5 minute demo of the software running and a walkthrough of the code. Focus should be on sharing what you learned about the language syntax.}

[Software Demo Video](http://youtube.link.goes.here)




# Development Environment

Visual Studio Code, .NET 7.0, and C# version 10 were used as the development environment for this project. Below is a list of .NET namespaces (classes)that were used:

[**System.Collections**](https://learn.microsoft.com/en-us/dotnet/api/system.collections?view=net-7.0) - Contains interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries. Used in this project to track valid menu options and provide feedback to user if an invalid option is selected.

[**System.Text.RegularExpressions**](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-7.0) - Represents an immutable regular expression. This project used this namespace to validate selected menu option.

[**System.Security.Cryptography**](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography?view=net-7.0) - Provides cryptographic services, including secure encoding and decoding of data, as well as many other operations, such as hashing, random number generation, and message authentication. This namspace is used for the main encryption class in this project.

[**System.Text**](https://learn.microsoft.com/en-us/dotnet/api/system.text?view=net-7.0) - Contains classes that represent ASCII and Unicode character encodings; abstract base classes for converting blocks of characters to and from blocks of bytes; and a helper class that manipulates and formats String objects without creating intermediate instances of String. This project uses this namespace for manipulating text.

[**System.IO.File**](https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-7.0) - Provides static methods for the creation, copying, deletion, moving, and opening of a single file, and aids in the creation of FileStream objects. This project uses this namespace for reading and writing text to a file.

[**System.Console**](https://learn.microsoft.com/en-us/dotnet/api/system.console?view=net-7.0) - Represents the standard input, output, and error streams for console applications, and used by this project to interact with the user.

[**System.Environment**](https://learn.microsoft.com/en-us/dotnet/api/system.environment?view=net-7.0) - Provides information about, and means to manipulate, the current environment and platform. This namespace =is used by this project to determine where the "Desktop" folder is, as this is the defaulted location for where a file will be written.

# Useful Websites

- [Introduction to C#](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/)
- [C# Language Reference](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
- [Create a .NET console application using Visual Studio Code](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code?pivots=dotnet-7-0)
- [AES Encryption Standard](https://www.geeksforgeeks.org/advanced-encryption-standard-aes/?ref=gcse)

# Future Work

- Make this a dynamic link library or other object that could be used by another application to perform text encryption
- Add a real frontend to the app and not just a console I/O
- Add In a real-world project, unit tests would have been added
