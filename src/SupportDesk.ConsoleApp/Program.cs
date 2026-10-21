Console.WriteLine("welcome to SupportDesk");

List<Ticket> tickets = new List<Ticket>();

bool isRunning = true;
while (isRunning)
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
        CreateTicket(tickets); // yani List tickets ro be Methode bede, edame ccomment ro to Methode dar paien bekhon 
    }

    else if (choice == "2")
    {
        ViewTickets(tickets);
    }
    else if (choice == "3")
    {
        SearchTickets(tickets);
    }
    else if (choice == "4")
    {
        Console.WriteLine("Exit");
        isRunning = false;
    }
    else
    {
        Console.WriteLine("Invalid option");
    }
}

void CreateTicket(List<Ticket> ticketList) //اینجا ticketList اسمی است که برای دریافت لیست در تعریف متد انتخاب کرده‌ایم؛ به آن «پارامتر» می‌گویند.
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

        Ticket newTicket = new Ticket();

        newTicket.Title = title;
        newTicket.Description = description ?? "";

        ticketList.Add(newTicket);

        Console.WriteLine("Ticket saved.");
        Console.WriteLine($"Title: {newTicket.Title}");
        Console.WriteLine($"Description: {newTicket.Description}");
    }
}
void ViewTickets(List<Ticket> ticketList) // esme list da Methode va biroone Methode hatman nabayad hatman motefavest bashan mitonan shabih beham bashan.
{
    if (ticketList.Count == 0)
    {
        Console.WriteLine("No tickets available.");
    }
    else
    {
        int count = GetTicketCount(tickets);
        Console.WriteLine($"all Tickets Number : {count}");
        foreach (Ticket ticket in ticketList)
        {
            Console.WriteLine($"Title: {ticket.Title}");
            Console.WriteLine($"Description: {ticket.Description}");
            Console.WriteLine();
        }
    }
}
void SearchTickets(List<Ticket> ticketList)
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
        foreach (Ticket ticket in ticketList) // inja to kode ghabli intori bood (Ticket ticket in tickets)
        {
            if (ticket.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Found ticket: {ticket.Title}");
                Console.WriteLine($"Description: {ticket.Description}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No matching tickets found.");
        }
    }
}
int GetTicketCount (List<Ticket> ticketlist) // Count Methode
{
    return ticketlist.Count;
}