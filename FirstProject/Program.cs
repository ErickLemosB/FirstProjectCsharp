string welcomeMessage = "Welcome to Neo CH - CineHome!"; 
//List<string> listOfMovies = new List<string>();
Dictionary<string, List<int>> moviesAdded = new Dictionary<string, List<int>>();
moviesAdded.Add("Inception", new List<int> { 5, 4, 5 });
moviesAdded.Add("The Matrix", new List<int>());
void showWelcomeMessage()
{
    Console.WriteLine(@"
███╗░░██╗███████╗░█████╗░  ░█████╗░██╗░░██╗
████╗░██║██╔════╝██╔══██╗  ██╔══██╗██║░░██║
██╔██╗██║█████╗░░██║░░██║  ██║░░╚═╝███████║
██║╚████║██╔══╝░░██║░░██║  ██║░░██╗██╔══██║
██║░╚███║███████╗╚█████╔╝  ╚█████╔╝██║░░██║
╚═╝░░╚══╝╚══════╝░╚════╝░  ░╚════╝░╚═╝░░╚═╝
");
    Console.WriteLine(welcomeMessage);
}

void showOptionsOfMenu()
{
    showWelcomeMessage();
    Console.WriteLine("\nPlease type to choose an option:\n");
    Console.WriteLine("1. Add Movie");
    Console.WriteLine("2. List Movies");
    Console.WriteLine("3. Rate a Movie");
    Console.WriteLine("4. Average rate of a Movie");
    Console.WriteLine("5. Exit\n");
    string chosenOption = Console.ReadLine()!;
    int chosenOptionNum = int.Parse(chosenOption);

    switch (chosenOptionNum)
    {
        case 1:
            addMovie();
            break;
        case 2:
            showListOfMovies();
            break;
        case 3:
            rateAMovie();
            break;
        case 4:
            averageRateOfMovie();
            break;
        case 5:
            Console.WriteLine("Exiting the application. Goodbye!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            showOptionsOfMenu();
            break;
    }

}

void addMovie()
{
    Console.Clear();
    showOptionTitles("Add a Movie:");
    string response;
    do
    {
        Console.Write("Type the name of the Movie: ");
        String movieName = Console.ReadLine()!;
        moviesAdded.Add(movieName, new List<int>());
        Console.WriteLine($"The Movie '{movieName}' was added successfully!");
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("Do you want to add another movie? (yes/no)");
        response = Console.ReadLine()!.ToLower();
    }
    while (response == "yes");
    showOptionsOfMenu();
}

void showListOfMovies()
{
    Console.Clear();
    showOptionTitles("List of Movies:");
    if (moviesAdded.Count == 0) 
    {
        Console.WriteLine("No movies have been added yet.");
    }
    else
    {
        foreach (var movie in moviesAdded.Keys) 
        {
            Console.WriteLine($"- {movie}");
        }
    }
    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadKey();
    Console.Clear();
    showOptionsOfMenu();
}

void showOptionTitles (string title)
{
    int lettersQuantity = title.Length;
    string stars = string.Empty.PadLeft(lettersQuantity,'*');
    Console.WriteLine(stars);
    Console.WriteLine(title);
    Console.WriteLine(stars + "\n");  
}

void rateAMovie ()
{
    Console.Clear();
    showOptionTitles("Rate a Movie:");
    Console.Write("Type the name of the Movie you want to rate: ");
    string movieName = Console.ReadLine()!;

    if (moviesAdded.ContainsKey(movieName))
    {
        Console.Write($"Type your rating (1-10) for {movieName}: ");
        int rating = int.Parse(Console.ReadLine()!);

        if (rating < 1 || rating > 10)
        {
            Console.WriteLine("Invalid rating. Please enter a number between 1 and 10.");
            Thread.Sleep(2500);
            rateAMovie();
        }
        else
        {
            moviesAdded[movieName].Add(rating);
            Console.WriteLine($"Thank you! Your rating of {rating} for '{movieName}' has been recorded.");
            Thread.Sleep(2500);
            Console.Clear();
            showOptionsOfMenu();

        }
    }
    else
    {
        Console.WriteLine($"The movie '{movieName}' does not exist in the list.");
        Thread.Sleep(2000);
        Console.WriteLine("Do you want to try again? (yes/no)");
        string response = Console.ReadLine()!.ToLower();
        if (response == "yes")
        {
            rateAMovie();
        }
        else
        {
            Console.Clear();
            showOptionsOfMenu();
        }
    }

}

void averageRateOfMovie()
{
    Console.Clear();
    showOptionTitles("Average rate of a Movie:");
    Console.Write("Type the name of the Movie you want to get the average rating: ");
    string movieName = Console.ReadLine()!;
    if (moviesAdded.ContainsKey(movieName))
    {
        List<int> ratings = moviesAdded[movieName];
        if (ratings.Count == 0)
        {
            Console.WriteLine($"The movie '{movieName}' has no ratings yet.\n");
            Thread.Sleep(2000);
            Console.WriteLine("Do you want to try again? (yes/no)");
            string response = Console.ReadLine()!.ToLower();
            if (response == "yes")
            {
                averageRateOfMovie();
            }
            else
            {
                Console.Clear();
                showOptionsOfMenu();
            }
        }
        else
        {
            double average = ratings.Average();
            Console.WriteLine($"The average rating for '{movieName}' is {average:F2}.");
            Thread.Sleep(2500);
        }
    }
    else
    {
        Console.WriteLine($"The movie '{movieName}' does not exist in the list.\n");
        Console.WriteLine("Do you want to try again? (yes/no)");
        string response = Console.ReadLine()!.ToLower();
        if (response == "yes")
        {
            averageRateOfMovie();
        }
        else
        {
            Console.Clear();
            showOptionsOfMenu();
        }
    }
    Console.Clear();
    showOptionsOfMenu();
}

showOptionsOfMenu();
