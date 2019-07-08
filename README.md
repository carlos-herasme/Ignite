# Ignite
Ignite is a numeric system converter that allow works with binary, decimal, octal and hexadecimal numeric systems

## How to use
Ignite is simple to use, you just have to clone the code into your computer and thereafter press the run button (or command).

## Considerations

Data source have to be in the next schema:

![Data order](https://i.ibb.co/pQ63csx/Capture.png)

Ignite reads Excel files in an specific order, so it's not like that it'll throw exceptions.

### Steps to use Ignite demo console application
1. Clone the repository.
2. Run the console application.
3. Put your source file directory path and press enter.
4. Put your source file name with its file extention and press enter.
5. Put your destionation file name and press enter.
    1. Destionation file will be saved into source directory.
6. Open your generated file and be happy!

### Steps to use Ignite dll
1. Clone the repository
2. Create a project.
3. Reference Ignite into your project.
4. Instance the Controller class and pass the required arguments.
    1. Source file name.
    2. Source file path.
    3. Destionation file name.
5. Use as you need.

## Output file

Ignite will generate an Excel file very similar to original, but with an aditional column. This aditional column is the converted value that you want.
