# Decoding a Message from a Text File
## Problem Description
In this exercise, we aim to decode a hidden message from a text file (test.txt). Each line in the file consists of a number followed by a word. The task is to organize these entries into a "pyramid" structure based on the numbers, and then extract a message using specific rules.

## Input Format
The input file (test.txt) has the following format:
3 love
6 computers
2 dogs
4 cats
1 i
5 you
Each line contains a number followed by a word. For instance, the line 3 love indicates that the word "love" corresponds to the number 3.

## Pyramid Structure
The numbers in the file are arranged into a pyramid structure:
```
  1
 2 3
4 5 6
```
Here, the smallest number is 1, and the numbers increase consecutively. Each row of the pyramid has one more number than the row above it.

## Decoding Process
To decode the message:
1. **Read and Parse**: Read the file and parse each line to extract the number and the corresponding word.
2. **Organize into Pyramid**: Sort the numbers in ascending order and arrange them into a pyramid structure.
3. **Extract Message**: Use the numbers at the end of each pyramid line to extract words from the file. For example, in the pyramid above (1, 3, 6), the words are "i", "love", and "computers".
4. **Format Output**: Concatenate the extracted words into a single string with spaces separating them.

## Example
For the input file:
3 love
6 computers
2 dogs
4 cats
1 i
5 you

The output should be the string:
"i love computers"

This Markdown document describes the problem of decoding a message from a text file based on a specific numeric-word association and pyramid structure. It outlines the steps involved in reading, organizing, and extracting the message using the provided code solution.