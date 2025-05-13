# iron_coding_challenge

Old phone keypad with alphabetical letters, a backspace key, and a send button

## Old Phone Pad Translator

This project is a simple translator that takes a string of numbers and converts it into a corresponding string of letters, using the old phone pad layout.

### Getting Started

To run the program, navigate to the project directory that's called "old_phone" and execute the following command:

`dotnet run`

This will compile and run the program, allowing you to input a string of numbers and see the corresponding translated string of letters.

### Running Tests

To run the unit tests for this project, at root folder, execute the following command:

`dotnet test`

This will run all the tests in the NumberMessage_TranslateTo_TextMessage test class, including the test cases in the OldPhonePadTestData enumerable.

### Adding More Test Cases

To add more test cases, go to the UnitTests.Test project, there look for the NumberMessage_TranslateTo_Text_Message.cs file, there go to the OldPhonePadTestData enumerable, then simply add a new tuple to the list with the input string and expected output string. For example:

```
 public static IEnumerable<object[]> OldPhonePadTestData =>
        [
            ["33#", "E"],
            ["227*#", "B"],
            ["4433555 555666#", "HELLO"],
            ["*6 666 6#", "MOM"],
            ["6 666 6*#", "MO"],
            ["22222*****5555444********#",""],
            ["22222*****5555444***#","J"],
            ["22222****5555444***#","AJ"],
            ["****22222#","B"],
            //add new tuple here, the second element is the expected outupt
        ];
```

#### Note

This project uses the dotnet CLI to build and run the program, as well as to execute the unit tests. Make sure you have the .NET Core SDK installed on your machine to use this project.
