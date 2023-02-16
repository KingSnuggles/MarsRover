using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ConsoleApp.Models
{
    public class Rover
    {
        public string Name { get; set; } = string.Empty;
        public Coordinate RoverLocation { get; set; } = new Coordinate();
        public char FacingDirection { get; set; }

        public Rover(string roverName, Coordinate coordinate, char facingDirection)
        {
            Name = roverName;
            RoverLocation = coordinate;
            FacingDirection = facingDirection;
        }

        public void ReportLocation()
        {
            Console.WriteLine($"{RoverLocation.X} {RoverLocation.Y} {FacingDirection}\t");
        }

        public void Move(Coordinate upperLeftCoordinate)
        {
            switch (FacingDirection)
            {
                case 'N':
                    if (RoverLocation.Y == upperLeftCoordinate.Y)
                    {
                        break;
                    }
                    RoverLocation.Y++;
                    break;
                case 'W':
                    if (RoverLocation.X == 0)
                    {
                        break;
                    }
                    RoverLocation.X--;
                    break;
                case 'S':
                    if (RoverLocation.Y == 0)
                    {
                        break;
                    }
                    RoverLocation.Y--;
                    break;
                case 'E':
                    if (RoverLocation.X == upperLeftCoordinate.X)
                    {
                        break;
                    }
                    RoverLocation.X++;
                    break;
                default:
                    break;
            } 
        }

        public void TurnLeft()
        {
            switch (FacingDirection)
            {
                case 'N':
                    FacingDirection = 'W';
                    break;
                case 'W':
                    FacingDirection = 'S';
                    break;
                case 'S':
                    FacingDirection = 'E';
                    break;
                case 'E':
                    FacingDirection = 'N';
                    break;
                default:
                    break;
            }
        }

        public void TurnRight()
        {
            switch (FacingDirection)
            {
                case 'N':
                    FacingDirection = 'E';
                    break;
                case 'W':
                    FacingDirection = 'N';
                    break;
                case 'S':
                    FacingDirection = 'W';
                    break;
                case 'E':
                    FacingDirection = 'S';
                    break;
                default:
                    break;
            }
        }

        public void ExecuteInstructions(string roverInstructions, Coordinate upperLeftCoordinate)
        {
            foreach (char roverInstruction in roverInstructions)
            {
                if (roverInstruction == 'M')
                {
                    Move(upperLeftCoordinate);
                }
                else if (roverInstruction == 'L')
                {
                    TurnLeft();
                }
                else if (roverInstruction == 'R')
                {
                    TurnRight();
                }
            }
        }
    }
}
