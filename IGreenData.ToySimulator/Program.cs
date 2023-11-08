// See https://aka.ms/new-console-template for more information
using IGreenData.ToyApplication;

IToySurfacer tableSurfacer = new ToySurface(5, 5);
IToy robot = new Toy(tableSurfacer);
IToySimulator simulator = new ToySimulator(robot);

string command;
do
{
    Console.Write("Plese give your input: ");
    command = Console.ReadLine().Trim().ToUpper();
    simulator.TriggerCommand(command);
} while (command != "EXIT");
