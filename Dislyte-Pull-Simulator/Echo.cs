namespace Dislyte_Pull_Simulator;

public class Echo
{
    private Random rand;
    private int pity;
    
    public Echo()
    {
        this.rand = new Random();
        this.pity = 100;
    }

    public Esper Summon()
    {
        var element = GetElemental(this.rand.Next(1, 100));
        var rarity = GetRarity(this.rand.Next(1, 100));
        
        this.pity--;
        if (rarity == Rarity.Legendary) pity = 100;
        
        return new Esper(element, rarity);
    }

    public int GetPity()
    {
        return this.pity;
    }

    private int shimmer = 7;
    private int wind = 31;
    private int flow = 31;
    private int inferno = 31;
    
    private Element GetElemental(int rng)
    {
        if (rng <= shimmer) return Element.Shimmer;
        if (rng <= shimmer + wind) return Element.Wind;
        if (rng <= shimmer + wind + flow) return Element.Flow;
        return Element.Inferno;
    }

    private int legendary = 1;
    private int epic = 9;
    private int rare = 90;
    
    private Rarity GetRarity(int rng)
    {
        if (this.pity == 1) return Rarity.Legendary;
        
        if (rng <= legendary) return Rarity.Legendary;
        if (rng <= legendary + epic) return Rarity.Epic;
        return Rarity.Rare;
    }
}