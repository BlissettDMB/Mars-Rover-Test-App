using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class RoverMovementComponent
    {
        public MessageQueue RoverMessageQueue { get; set; }
        public TerrainSection[,] Grid = new TerrainSection[6,6];
        public List<Rover> Rovers = new List<Rover>();


        public RoverMovementComponent(MessageQueue RoverMessageQueue)
        {
            this.RoverMessageQueue = RoverMessageQueue;
            this.Rovers = RoverMessageQueue.RoversOnMarsToList;
            InitialGrid();
        }

        public void InitialGrid() {
            for (int iGridColumnIndex = 0; iGridColumnIndex <= 5; iGridColumnIndex++)
            {
                for (int iGridRowIndex = 0; iGridRowIndex <= 5; iGridRowIndex++)
                {
                    Grid[iGridColumnIndex, iGridRowIndex] = new TerrainSection(iGridColumnIndex, iGridRowIndex);
                }
            }

            foreach (Rover rover in Rovers)
            {
                SetRoverDefaults(rover);
            }
        }

        private void SetRoverDefaults(Rover rover)
        {
            //The Grid knows which rover is where
            Grid[rover.Heading.Axis.X, rover.Heading.Axis.Y].Occupiers.Add(rover);
            //The Rover Knows where it is on the Grid
            rover.CurrentTerrainSection = Grid[rover.Heading.Axis.X, rover.Heading.Axis.Y];

            rover.Heading.CurrentOrientationDegrees = GetOrientationByOrientationEnum(rover.Heading.CurrentOrientation);
        }

        private void MoveRover(Message message)
        {
            Rover rover = message.Target;
            if (message.Data == "L")
            {
                int newOrientation = rover.Heading.CurrentOrientationDegrees - 90;
                newOrientation = newOrientation < 0 ? 270 : newOrientation;
                rover.Heading.CurrentOrientation =  GetOrientationByDegrees(newOrientation);
                rover.Heading.CurrentOrientationDegrees = newOrientation;
            }
            if (message.Data == "R")
            {
                int newOrientation = rover.Heading.CurrentOrientationDegrees + 90;
                newOrientation = newOrientation > 270 ? 0 : newOrientation;
                rover.Heading.CurrentOrientation = GetOrientationByDegrees(newOrientation);
                rover.Heading.CurrentOrientationDegrees = newOrientation;
            }

            if (message.Data == "M")
            {
                TerrainSection CurrentSectionRoverIsIn = Grid[rover.Heading.Axis.X, rover.Heading.Axis.Y];
                Grid[rover.Heading.Axis.X, rover.Heading.Axis.Y].Occupiers.Remove(rover);
                switch (rover.Heading.CurrentOrientation)
                {
                    case OrientationEnum.North:
                        {
                            if (Grid.GetLength(0) - 1 > CurrentSectionRoverIsIn.NorthCell.X &&
                               Grid.GetLength(1) - 1 > CurrentSectionRoverIsIn.NorthCell.Y)
                            {
                                rover.Heading.Axis.X = CurrentSectionRoverIsIn.NorthCell.X;
                                rover.Heading.Axis.Y = CurrentSectionRoverIsIn.NorthCell.Y;
                            }
                            break;
                        }
                    case OrientationEnum.East:
                        {
                            if (Grid.GetLength(0) - 1 >= CurrentSectionRoverIsIn.EastCell.X &&
                                Grid.GetLength(1) - 1 >= CurrentSectionRoverIsIn.EastCell.Y)
                            {
                                rover.Heading.Axis.X = CurrentSectionRoverIsIn.EastCell.X;
                                rover.Heading.Axis.Y = CurrentSectionRoverIsIn.EastCell.Y;
                            }
                            break;
                        }
                    case OrientationEnum.South:
                        {
                            if (Grid.GetLength(0) - 1 >= CurrentSectionRoverIsIn.SouthCell.X &&
                                Grid.GetLength(1) - 1 >= CurrentSectionRoverIsIn.SouthCell.Y)
                            {
                                rover.Heading.Axis.X = CurrentSectionRoverIsIn.SouthCell.X;
                                rover.Heading.Axis.Y = CurrentSectionRoverIsIn.SouthCell.Y;
                            }
                            break;
                        }
                    case OrientationEnum.West:
                        {
                            if (Grid.GetLength(0) - 1 >= CurrentSectionRoverIsIn.WestCell.X &&
                                Grid.GetLength(1) - 1 >= CurrentSectionRoverIsIn.WestCell.Y)
                            {
                                rover.Heading.Axis.X = CurrentSectionRoverIsIn.WestCell.X;
                                rover.Heading.Axis.Y = CurrentSectionRoverIsIn.WestCell.Y;
                            }
                            break;
                        } 
                }
                Grid[rover.Heading.Axis.X, rover.Heading.Axis.Y].Occupiers.Add(rover);
            }
        }



        public int GetOrientationByOrientationEnum(OrientationEnum CurrentOrientation)
        {
            int Orientation = 0;
            switch (CurrentOrientation)
            {
                case OrientationEnum.North:
                    {
                        Orientation = 0;
                        break;
                    }
                case OrientationEnum.East:
                    {
                        Orientation = 90;
                        break;
                    }
                case OrientationEnum.South:
                    {
                        Orientation = 180;
                        break;
                    }
                case OrientationEnum.West:
                    {
                        Orientation = 270;
                        break;
                    }


            }
            return Orientation;
        }

        public OrientationEnum GetOrientationByDegrees(int CurrentOrientationDegrees)
        {
            OrientationEnum Orientation = 0;
            switch (CurrentOrientationDegrees)
            {
                case 0:
                    {
                        Orientation = OrientationEnum.North;
                        break;
                    }
                case 90:
                    {
                        Orientation = OrientationEnum.East;
                        break;
                    }
                case 180:
                    {
                        Orientation = OrientationEnum.South;
                        break;
                    }
                case 270:
                    {
                        Orientation = OrientationEnum.West;
                        break;
                    }


            }
            return Orientation;
        }
        public void ProcessMessages()
        {
            int TotalNASACommands = RoverMessageQueue.TotalNASACommands;

            for (int iCommand = 0; iCommand < TotalNASACommands; iCommand++)
            {
                Message message = RoverMessageQueue.GetMessage(iCommand);
                MoveRover(message);
            }
            
        }
    }
}
