namespace Dislyte_Pull_Simulator;

public class Esper
{
    public Element Element;
    public Rarity Rarity;
    
    public Esper(Element element, Rarity rarity)
    {
        this.Element = element;
        this.Rarity = rarity;
    }

    public override string ToString()
    {
        return "Element: " + GetElementalName() + ", Rarity: " + GetRarityName();
    }

    private string GetElementalName()
    {
        return this.Element switch
        {
            Element.Flow => "Flow",
            Element.Wind => "Wind",
            Element.Inferno => "Inferno",
            Element.Shimmer => "Shimmer",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private string GetRarityName()
    {
        return this.Rarity switch
        {
            Rarity.Legendary => "Legendary",
            Rarity.Epic => "Epic",
            _ => "Rare"
        };
    }
}