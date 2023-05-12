namespace Dislyte_Pull_Simulator {
    internal class Program
    {
        private static int totalSummons = 1 * (int)Math.Pow(10, 9);
        
        private static int _totalShimmerLeggies = 0;
        private static int _totalShimmerEpics = 0;
        private static int _totalLeggies = 0;
        private static int _totalEpics = 0;
        private static int _totalRares = 0;
        
        public static void Main(string[] args)
        {
            Reset();
            var echo = new Echo();
            for (var i = 0; i < totalSummons / 100; i++)
            {
                var espers = new List<Esper>();
                
                for (var j = 0; j < 100; j++)
                {
                    espers.Add(echo.Summon());   
                }
                
                AddStats(espers);
            }

            WriteStats();
        }

        private static void Reset()
        {
            _totalEpics = 0;
            _totalLeggies = 0;
            _totalRares = 0;
            _totalShimmerEpics = 0;
            _totalShimmerLeggies = 0;
        }

        private static void AddStats(List<Esper> espers)
        {
            foreach (var esper in espers)
            {
                switch (esper.Rarity)
                {
                    case Rarity.Legendary:
                    {
                        if (esper.Element == Element.Shimmer) _totalShimmerLeggies += 1;
                        _totalLeggies += 1;
                        break;
                    }
                    case Rarity.Epic:
                    {
                        if (esper.Element == Element.Shimmer) _totalShimmerEpics += 1;
                        _totalEpics += 1;
                        break;
                    }
                    case Rarity.Rare:
                        _totalRares += 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void WriteStats()
        {
            var str = new StringWriter();
            str.WriteLine("Pulls: " + totalSummons);
            str.WriteLine("Total Legendaries: " + _totalLeggies + " (" + Math.Round((double)_totalLeggies / (double)totalSummons * 100, 3) + "%)");
            str.WriteLine("where " + _totalShimmerLeggies + " were shimmers " + "(" + Math.Round((double)_totalShimmerLeggies / (double)_totalLeggies * 100, 3) + "%)");
            str.WriteLine("Total Epics: " + _totalEpics);
            str.WriteLine("where " + _totalShimmerEpics + " were shimmers");
            str.WriteLine("Total Rares: " + _totalRares);

            var finalString = str.ToString();
            Console.Write(finalString);
        }
    }
}