namespace Test;

public class Player : Creature
{

    public int exp { get; set; }


    public Player(int Level, string Name, int AttackPoints, int HealthPoints)
    {
        this.level = Level;
        this.name = Name;
        this.attackPower = AttackPoints;
        this.healthPoints = HealthPoints;
    }
}


