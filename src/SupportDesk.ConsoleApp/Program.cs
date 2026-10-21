using System.Text.Json;
Console.WriteLine("welcome to SupportDesk");

List<Ticket> tickets = LoadTickets(); // inja List tickets ro az file load mikonim.
int nextTicketId = 1; // chon Ticket class ro edit kardim va property Id ro add kardim, alan bayad baraye har ticket jadid yek Id unique ham set konim. pas nextTicketId ro dar aval barabar 1 gharar midim va har bar ke ticket jadid sakhte shod, in value ro be ticket Id midim va bad az an nextTicketId ro 1 afzayesh midim.

foreach (Ticket ticket in tickets) // inja baraye har ticket ke az file load shode, check mikonim ke agar Id ticket az nextTicketId bozorgtar ya barabar bood, nextTicketId ro be ticket.Id + 1 set mikonim ta baraye ticket badi unique bashe.
{
    if (ticket.Id >= nextTicketId)
    {
        nextTicketId = ticket.Id + 1;
    }
}

bool isRunning = true;
while (isRunning)
{
    Console.WriteLine("1. Create Ticket :");
    Console.WriteLine("2. View Ticket :");
    Console.WriteLine("3. Search Ticket :");
    Console.WriteLine("4. Change Ticket Status");
    Console.WriteLine("5. Exit :");
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
        ChangeTicketStatus(tickets);
    }
    else if (choice == "5")
    {
        SaveTickets(tickets); // inja List tickets ro be Methode bede ta save beshe.
        Console.WriteLine("Tickets saved. Goodbye");
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

        newTicket.Id = nextTicketId; // baraye ticket jadid yek Id unique set mikonim
        nextTicketId++; // bad az set kardan Id, nextTicketId ro 1 afzayesh midim ta baraye ticket badi unique bashe.
        newTicket.Title = title;
        newTicket.Description = description ?? "";

        ticketList.Add(newTicket);

        Console.WriteLine("Ticket saved.");
        Console.WriteLine($"ID: {newTicket.Id}");
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
        int count = GetTicketCount(ticketList);
        Console.WriteLine($"all Tickets Number : {count}");
        foreach (Ticket ticket in ticketList)
        {
            Console.WriteLine($"ID: {ticket.Id}");
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
                Console.WriteLine($"ID: {ticket.Id}");
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
int GetTicketCount(List<Ticket> ticketList) // Count Methode
{
    return ticketList.Count;
}
void ChangeTicketStatus(List<Ticket> ticketList)
{
    Console.WriteLine("Enter ticket ID to change status:");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int ticketId))
    {
        Console.WriteLine("Invalid ticket ID.");
        return;
    }

    foreach (Ticket ticket in ticketList)
    {
        if (ticket.Id == ticketId)
        {
            Console.WriteLine($"Title: {ticket.Title}");
            Console.WriteLine($"Current status: {ticket.Status}");

            Console.WriteLine("1. Open");
            Console.WriteLine("2. InProgress");
            Console.WriteLine("3. Closed");
            Console.Write("Choose the new status: ");

            string? statusChoice = Console.ReadLine();

            if (statusChoice == "1")
            {
                ticket.Status = TicketStatus.Open;
            }
            else if (statusChoice == "2")
            {
                ticket.Status = TicketStatus.InProgress;
            }
            else if (statusChoice == "3")
            {
                ticket.Status = TicketStatus.Closed;
            }
            else
            {
                Console.WriteLine("Invalid status option.");
                return;
            }

            Console.WriteLine($"Status updated to: {ticket.Status}");
            return;
        }
    }
    Console.WriteLine("Ticket not found.");
}
void SaveTickets(List<Ticket> ticketList) // inja List tickets ro be Methode bede ta save beshe.
{
    string json = JsonSerializer.Serialize(ticketList); // inja List tickets ro be format JSON tabdil mikonim.
    File.WriteAllText("tickets.json", json); // inja List tickets ro be format JSON tabdil mikonim va dar file tickets.json save mikonim.
}

List<Ticket> LoadTickets() // inja List tickets ro az file load mikonim.
{
    if (!File.Exists("tickets.json")) // agar file tickets.json vojod nadashte bashad, yani hich ticketi save nashode, pas bayad yek List khali baraye tickets return konim.
    {
        return new List<Ticket>(); // yani agar file vojod nadashte bashad, hich ticketi save nashode, pas bayad yek List khali baraye tickets return konim.
    }

    string json = File.ReadAllText("tickets.json"); // inja file tickets.json ro mikhanim va dar variable json save mikonim.

    List<Ticket> loadedTickets = // inja List tickets ro az file load mikonim.
        JsonSerializer.Deserialize<List<Ticket>>(json)
        ?? new List<Ticket>(); // yani agar file tickets.json vojod nadashte bashad, hich ticketi save nashode, pas bayad yek List khali baraye tickets return konim.

    return loadedTickets; // inja List tickets ro az file load mikonim va return mikonim.
}