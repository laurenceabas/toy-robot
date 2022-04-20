using System;
using System.Collections.Generic;
using System.IO;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> commands = new List<string>();
            var board = new Board(5, 5);
            string argument = string.Empty;

            if (args.Length > 0)
            {
                var testFile = args[0];
                commands = GetCommandsFromFile(testFile);
            } 
            else
            {
                do
                {
                    argument = Console.ReadLine();

                    var newCmd = argument.ToUpper();

                    if (newCmd.StartsWith("PLACE ") || newCmd.Trim().Equals("MOVE") || newCmd.Trim().Equals("LEFT") || newCmd.Trim().Equals("RIGHT") || newCmd.Trim().Equals("REPORT"))
                    {
                        commands.Add(newCmd);
                    }
                    else
                    {
                        Console.WriteLine("ERROR. Invalid command. Only commands that are accepted are PLACE MOVE LEFT RIGHT & REPORT");
                    }
                } while (!argument.ToLowerInvariant().Equals("report"));

            }

            bool isInitialized = false;
            bool canMove = true;
            Robot robot = new Robot(null, null);
            Position position;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();

            foreach(var cmd in commands)
            {
                Console.WriteLine(cmd.ToUpper());

                if(cmd.StartsWith("PLACE "))
                {
                    var pos = cmd.Replace("PLACE ", string.Empty);
                    position = InitializePosition(pos);

                    robot = new Robot(position, board);
                    isInitialized = true;
                }

                if(isInitialized)
                {
                    if(canMove)
                    {
                        switch (cmd)
                        {
                            case "MOVE":
                                canMove = robot.MoveForward();
                                break;
                            case "LEFT":
                                robot.Rotate(Rotation.Left);
                                break;
                            case "RIGHT":
                                robot.Rotate(Rotation.Right);
                                break;

                        }
                    }

                    if (!canMove)
                    {
                        Console.WriteLine(robot.GetCurrentPosition().ErrorMessage);
                        Console.WriteLine("Last valid location: " + robot.ToString());
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        return;
                    }
                }
            }

            Console.WriteLine("Output: " + robot.ToString());
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        private static List<string> GetCommandsFromFile(string filefullpath)
        {
            var commands = new List<string>();
            if(!File.Exists(filefullpath))
            {
                Console.WriteLine("ERROR. File not found!");
                return null;
            }

            try
            {
                using (var file = File.OpenText(filefullpath))
                {
                    while (!file.EndOfStream)
                    {
                        var newCmd = file.ReadLine().ToUpper();
                        if (newCmd.StartsWith("PLACE ") || newCmd.Trim().Equals("MOVE") || newCmd.Trim().Equals("LEFT") || newCmd.Trim().Equals("RIGHT") || newCmd.Trim().Equals("REPORT"))
                        {
                            commands.Add(newCmd);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return commands;
        }

        private static Position InitializePosition(string initialPlace)
        {
            if(!string.IsNullOrWhiteSpace(initialPlace))
            {
                try
                {
                    var place = initialPlace.Split(',');
                    if (place.Length < 3)
                    {
                        Console.WriteLine("ERROR. Initial place of the toy robot is incorrect. Format is X, Y, F. Eg. 0, 0, N");
                        return null;
                    }

                    int x = 0;
                    if (!int.TryParse(place[0].Trim(), out x))
                    {
                        Console.WriteLine("ERROR. First coordinate should be a number");
                        return null;
                    }

                    int y = 0;
                    if (!int.TryParse(place[1].Trim(), out y))
                    {
                        Console.WriteLine("ERROR. Second coordinate should be a number");
                        return null;
                    }

                    string face = place[2].Trim().ToLowerInvariant();
                    if (!face.Equals("north") && !face.Equals("east") && !face.Equals("south") && !face.Equals("west"))
                    {
                        Console.WriteLine("ERROR. Incorrect initial stand of the toy robot. Acceptable inputs are North East South West");
                        return null;
                    }


                    return new Position(x, y, face);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return null;
        }
    }
}
