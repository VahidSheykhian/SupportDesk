Console.WriteLine("welcome to SupportDesk");

List<string> titletickets = new List<string>();

bool IsRunning = true;
while (IsRunning)
{
    Console.WriteLine("1. Create Ticket :");
    Console.WriteLine("2. View Ticket :");
    Console.WriteLine("3. Search Ticket :");
    Console.WriteLine("4. Exit :");
    Console.Write("Choose an option :");
    string? choice = Console.ReadLine();
    Console.WriteLine($"you selected:{choice}");

    if (choice == "1")
    {
        Console.Write("Enter ticket title: ");
        string? title = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Invalid ticket title.");
        }
        else
        {
            Console.Write("Enter ticket description: ");
            string? description = Console.ReadLine();

            titletickets.Add(title);
            Console.WriteLine("Ticket title saved");

            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Description: {description}");
        }
    }
    else if (choice == "2")
    {
        Console.WriteLine("View Ticket");
        if (titletickets.Count == 0)
        {
            Console.WriteLine("No tickets available.");
        }
        else
        {
            Console.WriteLine("Tickets:");
            foreach (string ticket in titletickets)
            {
                Console.WriteLine($"- {ticket}");
            }
        }
    }
    else if (choice == "3")
    {
        Console.WriteLine("Search Ticket");
        string? keyword = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Search keyword is required.");
        }
        else
        {
            bool found = false;
            foreach (string ticket in titletickets)
            {
                if (ticket.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found ticket: {ticket}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No matching tickets found.");
            }
        }
    }
    else if (choice == "4")
    {
        Console.WriteLine("Exit");
        IsRunning = false;
    }
    else
    {
        Console.WriteLine("Invalid option");
    }
}