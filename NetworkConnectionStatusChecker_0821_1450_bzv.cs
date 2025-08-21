// 代码生成时间: 2025-08-21 14:50:29
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace NetworkStatusChecker
{
    /// <summary>
    /// This class is used to check the network connection status.
    /// </summary>
    public class NetworkConnectionStatusChecker
    {
        /// <summary>
        /// Checks if the current machine has a network connection.
        /// </summary>
        /// <returns>A boolean indicating whether the machine is connected to a network.</returns>
        public bool IsConnectedToNetwork()
        {
            try
            {
                // Get all the network interfaces on the machine
                var interfaces = NetworkInterface.GetAllNetworkInterfaces();

                // Check if any of the network interfaces are up and running
                foreach (var interfaceInfo in interfaces)
                {
                    if (interfaceInfo.OperationalStatus == OperationalStatus.Up)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception if any error occurs during the process
                Console.WriteLine($"Error checking network connection: {ex.Message}");
            }

            // Return false if no network interfaces are up
            return false;
        }

        /// <summary>
        /// Asynchronously checks if the current machine has a network connection.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation and contains a boolean indicating whether the machine is connected to a network.</returns>
        public async Task<bool> IsConnectedToNetworkAsync()
        {
            try
            {
                // Get all the network interfaces on the machine
                var interfaces = NetworkInterface.GetAllNetworkInterfaces();

                // Check if any of the network interfaces are up and running
                foreach (var interfaceInfo in interfaces)
                {
                    if (interfaceInfo.OperationalStatus == OperationalStatus.Up)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception if any error occurs during the process
                Console.WriteLine($"Error checking network connection: {ex.Message}");
            }

            // Return false if no network interfaces are up
            return false;
        }
    }
}
