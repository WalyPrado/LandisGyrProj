
#region Variables
using LandisGyrProj.Logic;
string option = string.Empty;
EndpointManager endpointManager = new EndpointManager();
#endregion

do
{
    Console.Clear();
    Console.WriteLine(@$"Hello! Please, type the number's option that you want!
1) Insert a new endpoint.
2) Edit an existing endpoint.
3) Delete an existing endpoint.
4) List all endpoints.
5) Find an endpoint by a serial number.
6) Exit.


9) Show logs.");
    option = Console.ReadLine() ?? string.Empty;

    Console.Write("\n\n");
    switch (option)
    {
        case "1":
            endpointManager.SaveEndpoint();
            break;
        case "2":
            endpointManager.EditEndpoint();
            break;
        case "3":
            endpointManager.DeleteEndpoint();
            break;
        case "4":
            endpointManager.ListAllEndpoints();
            break;
        case "5":
            endpointManager.FindEndpointBySerial();
            break;
        case "6":
            Console.WriteLine("Are you sure that you want to exit? (Y/N)");
            option = Console.ReadLine() ?? string.Empty;

            if (option.ToLower() == "y")
                return;
            break;

        case "9":
            endpointManager.ShowLogs();
            break;
        default:
            Console.WriteLine("\nInvalid option!");
            break;
    }

    Console.WriteLine("Type any key to continue.");
    Console.ReadLine();

} while (option != "6");