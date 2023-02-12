using Lab7;

String pathFile = @"..\..\..\files\script.txt";
Interpreter interpreter = new Interpreter();

var collLines = File.ReadLines(pathFile);
interpreter.readCommand(collLines);