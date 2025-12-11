using System.Text;

var fileData = File.ReadAllLines("snooker.txt", Encoding.UTF7).Skip(1);
var competitors = new List<Competitor>();

foreach (var line in fileData)
{
    var data = line.Split(';');
    competitors.Add(new Competitor
    {
        Placement = int.Parse(data[0]),
        Name = data[1],
        Country = data[2],
        Prize = int.Parse(data[3])
    });
}
var count = competitors.Count();
Console.WriteLine($"3. feladat: A világranglistán {count} versenyző szerepel");

var averageIncome = competitors.Average(v => v.Prize);
Console.WriteLine($"\n4. feladat: A versenyzők átlagos nyereménye: {averageIncome:F2} font");

var bestCompetitorInChina = competitors.Where(v => v.Country == "Kína")
                                       .OrderBy(v => v.Placement)
                                       .First();
Console.WriteLine($"5. feladat: A legjobban kereső kínai versenyző:\n\tHelyezés: {bestCompetitorInChina.Placement}\n\tNév: {bestCompetitorInChina.Name}\n\tOrszág: {bestCompetitorInChina.Country}\n\tNyeremény összege: {bestCompetitorInChina.Prize * 380} Ft");

var norwegianCompetitor = competitors.FirstOrDefault(v => v.Country == "Norvégia");

if (norwegianCompetitor != null)
{
    Console.WriteLine($"6. feladat: A versenyzők között van norvég versenyző.");
} else {
    Console.WriteLine("6. feladat: Nincs norvég versenyző a világranglistán.");
}

Console.WriteLine("7. feladat: Statisztika országok szerint csoportosításban");
var statisticsByCountry = competitors.GroupBy(v => v.Country)
                                     .Where(g => g.Count() > 4)
                                     .Select(g => new
                                     {
                                         Country = g.Key,
                                         Count = g.Count()
                                     })
                                     .OrderByDescending(x => x.Count);


foreach (var country in statisticsByCountry)
{
    Console.WriteLine($"\t{country.Country} - {country.Count} fő");
}

Console.ReadKey();