using MarsRover.ConsoleApp.ProcessInputFile;

internal class Program
{
    private static void Main(string[] args)
    {
        ProcessInput processInput = new ProcessInput();

        processInput.Process();
    }
}