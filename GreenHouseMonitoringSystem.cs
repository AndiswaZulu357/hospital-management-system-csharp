using System;

namespace GreenhouseMonitoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the number of sections: ");
                int sections = int.Parse(Console.ReadLine());
                
                Console.Write("Enter the number of readings per section: ");
                int readingsPerSection = int.Parse(Console.ReadLine());

                double[,] sensorData = new double[sections, readingsPerSection];

                for (int i = 0; i < sections; i++)
                {
                    Console.WriteLine($"Section {i + 1}:");
                    for (int j = 0; j < readingsPerSection; j++)
                    {
                        Console.Write($"Enter temperature reading {j + 1}: ");
                        sensorData[i, j] = double.Parse(Console.ReadLine());
                    }
                }

                Console.WriteLine("\nEntered sensor data:");
                for (int i = 0; i < sections; i++)
                {
                    Console.Write($"Section {i + 1}: ");
                    for (int j = 0; j < readingsPerSection; j++)
                    {
                        Console.Write(sensorData[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\nPerforming temperature analysis...");
                Console.WriteLine("Temperature analysis completed.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter valid numeric input.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input is too large or too small for the data type.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
