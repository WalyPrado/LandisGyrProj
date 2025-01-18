using LandisGyrProj.Classes;
using LandisGyrProj.Interfaces;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LandisGyrProj.Logic
{
    public class EndpointManager : Storage, IEndpointManager
    {
        public ILogSystem Logs { get; set; }

        public EndpointManager()
        {
            Logs = new LogsSystem();
        }

        public void SaveEndpoint()
        {
            Console.WriteLine("To cancel, type 'Cancel'.");
            try
            {
                Endpoint endpoint = new Endpoint();
                string value = string.Empty;

                #region Serial Number
                while (value.ToLower() != "cancel")
                {
                    Console.WriteLine("Please, enter a valid Serial Number:");
                    value = Console.ReadLine() ?? string.Empty;

                    if (value.ToLower() == "cancel")
                        break;

                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Invalid serial number!");
                    }
                    else
                    {
                        var result = FindBySerial(value);

                        if (!string.IsNullOrEmpty(result.endpointSerialNumber))
                        {
                            Console.WriteLine("Serial Number is already in use!");
                            value = "cancel";
                            break;
                        }
                        endpoint.endpointSerialNumber = value;
                        break;
                    }
                }
                #endregion

                #region Meter Model
                while (value.ToLower() != "cancel")
                {
                    Console.WriteLine("Please, enter the code of a valid State:\n"
                                    + "Valid values: 16 - NSX1P2W, 17 - NSX1P3W, 18 - NSX2P3W, 19 - NSX3P4W");

                    value = Console.ReadLine() ?? string.Empty;

                    if (value.ToLower() == "cancel")
                        break;

                    if (string.IsNullOrEmpty(value) || !new string[] { "16", "17", "18", "19" }.Contains(value))
                        Console.WriteLine("Invalid Meter Model Id!");
                    else
                    {
                        endpoint.meterModelId = (Enums.MeterModel)Convert.ToInt32(value);
                        break;
                    }
                }
                #endregion

                #region Meter Number
                while (value.ToLower() != "cancel")
                {
                    Console.WriteLine("Please, enter a valid Meter Number:");
                    value = Console.ReadLine() ?? string.Empty;

                    if (value.ToLower() == "cancel")
                        break;

                    if (Int32.TryParse(value, out int intValue))
                    {
                        endpoint.meterNumber = intValue;
                        break;
                    }
                    else
                        Console.WriteLine("Invalid Meter Number!");
                }
                #endregion

                #region Meter Firmware Version
                while (value.ToLower() != "cancel")
                {
                    Console.WriteLine("Please, enter a valid Meter Firmware Version:");
                    value = Console.ReadLine() ?? string.Empty;

                    if (value.ToLower() == "cancel")
                        break;

                    if (string.IsNullOrEmpty(value))
                        Console.WriteLine("Invalid Meter Firmware Version!");
                    else
                    {
                        endpoint.meterFirmwareVersion = value;
                        break;
                    }
                }
                #endregion

                #region Switch State
                while (value.ToLower() != "cancel")
                {
                    Console.WriteLine("Please, enter the code of a valid State:\n"
                                       + "Valid values: 0 - Disconnected, 1 - Connected, 2 - Armed");
                    value = Console.ReadLine() ?? string.Empty;

                    if (value.ToLower() == "cancel")
                        break;

                    if (string.IsNullOrEmpty(value) || !new string[] { "0", "1", "2" }.Contains(value))
                        Console.WriteLine("Invalid Meter Firmware Version!");
                    else
                    {
                        endpoint.switchState = (Enums.State)Convert.ToInt32(value);
                        break;
                    }
                }
                #endregion

                if (value.ToLower() == "cancel")
                {
                    Console.WriteLine("Action Canceled!");
                    return;
                }

                Console.WriteLine(Save(endpoint));
            }
            catch (Exception exception)
            {
                Logs.SaveLog(string.Format("An error was found when executing \"SaveEndpoint\": {0}", exception.Message));
                Console.WriteLine("An error occurred, please try again later!");
            }
        }

        public void EditEndpoint()
        {
            if (!GetAll().Any())
            {
                Console.WriteLine("There is no endpoint saved!");
                return;
            }

            Console.WriteLine("To cancel this action, type 'Cancel'.");
            try
            {
                string value = string.Empty;
                Enums.State valueState = 0;
                Endpoint endpoint = new Endpoint();

                #region Serial Number
                while (value.ToLower() != "cancel")
                {
                    Console.WriteLine("Please, enter a valid Serial Number:");
                    value = Console.ReadLine() ?? string.Empty;

                    if (value.ToLower() == "cancel")
                        break;

                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Invalid serial number!");
                    }
                    else
                    {
                        endpoint = FindBySerial(value);

                        if (!string.IsNullOrEmpty(endpoint.endpointSerialNumber))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Endpoint not found, please confirm the serie number and try again.");
                        }
                    }
                }
                #endregion

                #region Switch State
                while (value.ToLower() != "cancel")
                {
                    Console.WriteLine("Please, enter the code of a valid State:\n"
                                       + "Valid values: 0 - Disconnected, 1 - Connected, 2 - Armed");
                    value = Console.ReadLine() ?? string.Empty;

                    if (value.ToLower() == "cancel")
                        break;

                    if (string.IsNullOrEmpty(value) || !new string[] { "0", "1", "2" }.Contains(value))
                    {
                        Console.WriteLine("Invalid Meter Firmware Version!");
                    }
                    else
                    {
                        valueState = (Enums.State)Convert.ToInt32(value);
                        break;
                    }
                }
                #endregion

                if (value.ToLower() == "cancel")
                {
                    Console.WriteLine("Action Canceled!");
                    return;
                }

                Console.WriteLine(Edit(endpoint, valueState));
            }
            catch (Exception exception)
            {
                Logs.SaveLog(string.Format("An error was found when executing \"EditEndpoint\": {0}", exception.Message));
                Console.WriteLine("An error occurred, please try again later!");
            }
        }

        public void DeleteEndpoint()
        {
            if (!GetAll().Any())
            {
                Console.WriteLine("There is no endpoint saved!");
                return;
            }

            Console.WriteLine("To cancel this action, type 'Cancel'.");
            try
            {
                string value = string.Empty;
                Endpoint endpoint = new Endpoint();

                while (value.ToLower() != "cancel")
                {
                    Console.WriteLine("Please, enter a valid Serial Number:");
                    value = Console.ReadLine() ?? string.Empty;

                    if (value.ToLower() == "cancel")
                        break;

                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Invalid serial number!");
                    }
                    else
                    {
                        endpoint = FindBySerial(value);

                        if (!string.IsNullOrEmpty(endpoint.endpointSerialNumber))
                        {
                            Console.WriteLine(string.Format("Are you sure that you want to delete the endpoint {0}? This action cannot be undone. (Type 'YES' to confirm)", endpoint.endpointSerialNumber));
                            value = Console.ReadLine() ?? string.Empty;

                            if (value == "YES")
                            {
                                Delete(endpoint);
                                Console.WriteLine(string.Format("The endpoint {0} has been excluded!", endpoint.endpointSerialNumber));

                                break;
                            }
                            else
                                value = string.Empty;
                        }
                        else
                        {
                            Console.WriteLine("Endpoint not found!");
                        }
                    }
                }

                if (value.ToLower() == "cancel")
                {
                    Console.WriteLine("Action Canceled!");
                }
            }
            catch (Exception exception)
            {
                Logs.SaveLog(string.Format("An error was found when executing \"DeleteEndpoint\": {0}", exception.Message));
                Console.WriteLine("An error occurred, please try again later!");
            }
        }

        public void FindEndpointBySerial()
        {
            if (!GetAll().Any())
            {
                Console.WriteLine("There is no endpoint saved!");
                return;
            }

            Console.WriteLine("To cancel this action, type 'Cancel'.");
            try
            {
                string value = string.Empty;
                Endpoint endpoint = new Endpoint();

                while (value.ToLower() != "cancel")
                {
                    Console.WriteLine("Please, enter a valid Serial Number:");
                    value = Console.ReadLine() ?? string.Empty;

                    if (value.ToLower() == "cancel")
                        break;

                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Invalid serial number!");
                    }
                    else
                    {

                        endpoint = FindBySerial(value);

                        if (!string.IsNullOrEmpty(endpoint.endpointSerialNumber))
                        {
                            Console.WriteLine(string.Format("The endpoint {0} was finded!\n\n", endpoint.endpointSerialNumber) +
                                $"Endpoint Serial Number: {endpoint.endpointSerialNumber}\n" +
                                $"Meter Model Identifier: {endpoint.meterModelId}\n" +
                                $"Meter Number:           {endpoint.meterNumber}\n" +
                                $"Meter Firmware Version: {endpoint.meterFirmwareVersion}\n" +
                                $"State:                  {endpoint.switchState}\n");


                            break;
                        }
                        else
                        {
                            Console.WriteLine("Endpoint not found, please confirm the serie number and try again.");
                        }
                    }
                }

                if (value.ToLower() == "cancel")
                {
                    Console.WriteLine("Action Canceled!");
                }
            }
            catch (Exception exception)
            {
                Logs.SaveLog(string.Format("An error was found when executing \"FindEndpointBySerial\": {0}", exception.Message));
                Console.WriteLine("An error occurred, please try again later!");
            }
        }

        public void ListAllEndpoints()
        {
            List<Endpoint> result = GetAll();

            if (result.Any())
            {
                Console.WriteLine(result.Count == 1 ? "1 endpoint was found!" : string.Format("{0} endpoints were found!", result.Count));

                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine($"\n\nENDPOINT {i + 1}\n" +
                                $"Endpoint Serial Number: {result[i].endpointSerialNumber}\n" +
                                $"Meter Model Identifier: {result[i].meterModelId}\n" +
                                $"Meter Number:           {result[i].meterNumber}\n" +
                                $"Meter Firmware Version: {result[i].meterFirmwareVersion}\n" +
                                $"State:                  {result[i].switchState}\n");
                }
            }
            else
            {
                Console.WriteLine("There is no endpoint saved!");
            }
        }

        public void ShowLogs()
        {
            Logs.ShowLogs();
        }
    }
}
