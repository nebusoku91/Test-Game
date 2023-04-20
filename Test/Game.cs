namespace Test;

public class Game
{
    private GameEvents gameEvents;
    private int menuChoice;

    public Game(GameEvents gameEvents)
    {
        this.gameEvents = gameEvents;
    }

    public void LaunchMenu(Player player)
    {
        while (true)
        {
            Console.WriteLine("1. Show Stats");
            Console.WriteLine("2. Fight Monster");
            Console.WriteLine("3. Edit Player Name");
            Console.WriteLine("4. Exit Game");

            try
            {
                menuChoice = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please choose an option from the menu. ");
                LaunchMenu(player);
            }


            if (menuChoice > 0 && menuChoice <= 4)
                switch (menuChoice)
                {
                    case 1:
                        Console.WriteLine(gameEvents.PlayerShowStatsEvent(player));
                        break;
                    case 2:
                        Console.WriteLine("Fighting some monsters...");
                        gameEvents.CombatEvent(player);
                        break;
                        case 3:
                        gameEvents.ChangePlayerNameEvent(player);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }

            else
            {
                Console.WriteLine("Something went wrong.");
                LaunchMenu(player);
            }
        }
    }
}
