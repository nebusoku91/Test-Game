namespace Test;

public class Monster : Creature
{
    public int killExp { get; set; }

    public Monster(int Level, string Name, int AttackPower, int HealthPoints, int KillExp)
    {
        this.level = Level;
        this.name = Name;
        this.attackPower = AttackPower;
        this.healthPoints = HealthPoints;
        this.killExp = KillExp;
    }
}
