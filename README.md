# WordPuzzle

## Problem

- Select a start word, for example, *same*.
- Choose an end word, for example, *cost*.
- Develop a list of words that transition from the start word to the end word.
- Only one letter can change between any two words.
- Each intermediate step must be a valid word from the provided dictionary file.

**Example:**
**S**AME => **C**AME => CA**S**E => CAS**T** => C**O**ST

## Solution Steps

**SAME** => **COST**

1. From the start word (*SAME*), generate a list containing all valid words from the dictionary, changing only one character at a time. This list is named *wordList*.

    ```
    wordList = [tame, name, dame, lame, game, came, fame, some, sane, sale, sage, sake, safe, save]
    ```

2. Filter the *wordList* to find the word closest to the end word using the [***Levenshtein Distance***](https://en.wikipedia.org/wiki/Levenshtein_distance) algorithm, imported from the [*LevenshteinDistance* library](https://www.nuget.org/packages/LevenshteinDistance/1.0.0) . The word closest to the end word is named *bestWord*.

    ```
    bestWord = came
    ```

3. Add *bestWord* to the list of intermediate words between the start word and the end word.
4. Update the start word with the value of *bestWord*.
5. Repeat the cycle until one of the following conditions is met:
   - A) The start word equals the end word, then return the list of intermediate words between startWord and endWord.
   - B) While it is possible to create a *wordList* of possible words. When no possible words are found to continue the loop, add "No intermediate word found" and end the loop.
  

## App Functions

1 - The application operates as a console application that prompts the user to input the start word and the end word.
![read inputs](https://github.com/PedroBelfort/TechTest/blob/main/WordPuzzle/Assets/step-1.png)  <br>

2 - Upon receiving the inputs, the app processes them and prints the intermediate words on the console. Additionally, it exports a solution file (solution.txt) to the Desktop. <br>
![process](https://github.com/PedroBelfort/TechTest/blob/main/WordPuzzle/Assets/step-2.png)  <br>

3 - The solution file is exported to the Desktop. <br>
![file exported](https://github.com/PedroBelfort/TechTest/blob/main/WordPuzzle/Assets/step3.png)  <br>

4 - The user can exit the application at any time by typing "bye".
![bye](https://github.com/PedroBelfort/TechTest/blob/main/WordPuzzle/Assets/step4.png)  <br>

5 - The user can clear the application's data at any time by typing "clear".
![bye](https://github.com/PedroBelfort/TechTest/blob/main/WordPuzzle/Assets/step5.png)  <br>

6- When no intermediate word is found, the application prints "No intermediate word found".
![not found](https://github.com/PedroBelfort/TechTest/blob/main/WordPuzzle/Assets/step-6.png)  <br>

7 - The application throws an exception when a business rule is violated.
![exception](https://github.com/PedroBelfort/TechTest/blob/main/WordPuzzle/Assets/step-7.png)
