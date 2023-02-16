using MarsRover.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ConsoleApp.ProcessInputFile
{
    public class ProcessInput
    {
        public void Process()
        {
            string[] inputInstructions = GetInputInstructions();

            Coordinate upperLeftCoordinate = GetCoordinate(inputInstructions[0]);

            Rover roverOne = GetRover(inputInstructions[1], "Rover One");

            Rover roverTwo = GetRover(inputInstructions[3], "Rover Two");

            ExecuteRoverInstructions(inputInstructions[2], roverOne, upperLeftCoordinate);
            ExecuteRoverInstructions(inputInstructions[4], roverTwo, upperLeftCoordinate);
        }

        private static string[] GetInputInstructions()
        {
            return File.ReadAllLines(@"C:\InputFile\InputFile.txt");
        }

        private static void ExecuteRoverInstructions(string roverInstructions, Rover rover, Coordinate upperLeftCoordinate)
        {
            rover.ExecuteInstructions(roverInstructions, upperLeftCoordinate);
            rover.ReportLocation();
        }

        private static Rover GetRover(string roverPosition, string roverName)
        {
            string[] result = SplitString(roverPosition, separator:' ');

            return new Rover(roverName, new Coordinate(x: int.Parse(result[0]), y: int.Parse(result[1])), char.Parse(result[2]));
        }

        private static string[] SplitString(string stringToSplit, char separator)
        {
            return stringToSplit.Split(separator);
        }

        private static Coordinate GetCoordinate(string coordinate)
        {
            string[] result = SplitString(coordinate, separator:' ');

            return new Coordinate(x:int.Parse(result[0]), y:int.Parse(result[1]));
        }
    }
}
