using System.Diagnostics;

namespace Test;

public class GameEvents
{
    public Player PlayerCreateEvent()
    {
        try
        {
            string newPlayerName = "";
            while (newPlayerName == "")
            {
                Console.Write("Name: ");
                newPlayerName = Console.ReadLine();
            }

            try
            {
                string capitalized = Extensions.CapitalizeFirstLetter(newPlayerName);

                newPlayerName = capitalized;
            }
            catch(Exception) { }

            Player player = new Player(1, newPlayerName, 3, 10);

            Console.WriteLine($"Player {player.name} has been created.");
            Console.WriteLine(PlayerShowStatsEvent(player));
            return player;
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input. Please enter a valid value.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        return null;
    }

    public void ChangePlayerNameEvent(Player player)
    {
        Console.Write("Enter your new name: ");
        try
        {
            player.name = Console.ReadLine();
            string capitalized = Extensions.CapitalizeFirstLetter(player.name);
            player.name = capitalized;

        }
        catch(Exception ex) 
        {
        }
    }
    public string PlayerShowStatsEvent(Player player)
    {
        return $"{player.name}: Level: {player.level}, Attack Power: {player.attackPower}, Health Points: {player.healthPoints}";
    }

    public void ExperienceGainEvent(Player player, int xp)
    {
        try
        {
            player.exp += xp;

            while (player.exp >= 100)
            {
                player.exp -= 100;
                LevelUpEvent(player);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    private int[] levelHealthPoints = { 0, 10, 12, 14, 16, 18 };
    private int[] levelAttackPower = { 0, 1, 2, 3, 4, 5 };

    public void LevelUpEvent(Player player)
    {
        int maxLevel = levelHealthPoints.Length - 1;

        if (player.level < maxLevel)
        {
            player.level++;

            player.healthPoints += levelHealthPoints[player.level];
            player.attackPower += levelAttackPower[player.level];

            Console.WriteLine("You have leveled up! Level: " + player.level);
        }
        else
        {
            Console.WriteLine("You have reached the maximum level!");
        }
    }

    public void CombatEvent(Player player)
    {
        Monster monster = new Monster(12, "Goblin", 2, 10, 10);

        while (player.healthPoints > 0 && monster.healthPoints > 0)
        {
            string playerAttack = "Player attacks for " + player.attackPower + " damage.";
            Console.WriteLine(playerAttack);

            monster.healthPoints -= player.attackPower;

            if (monster.healthPoints <= 0)
            {
                string monsterDefeated = "Monster is defeated. Player wins!";
                Console.WriteLine(monsterDefeated);
                break;
            }

            string monsterAttack = "Monster attacks for " + monster.attackPower + " damage.";
            Console.WriteLine(monsterAttack);

            player.healthPoints -= monster.attackPower;

            if (player.healthPoints <= 0)
            {
                string playerDefeated = "Player is defeated. Monster wins!";
                Console.WriteLine(playerDefeated);
                break;
            }
        }



        // Not Yet Implemented
    }
}
