using System.Text;

var fileData = await File.ReadAllLinesAsync("EUcsatlakozas.txt", Encoding.UTF7);
var members = new List<Member>();


foreach (var line in fileData)
{
    var data = line.Split(';');
    members.Add(new Member
    {
        Country = data[0],
        JoinDate = DateTime.Parse(data[1])
    });
}


Console.WriteLine($"3. feladat: EU tagállamainak száma: {members.Count} db");


var joined2007 = members.Where(x => x.JoinDate.Year == 2007).Count();
Console.WriteLine($"4. feladat: 2007-ben {joined2007} ország csatlakozott.");


var hungaryJoinDate = members.FirstOrDefault(x => x.Country == "Magyarország");
Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma: {hungaryJoinDate.JoinDate:yyyy.MM.dd}");

bool mayJoin = members.Any(x => x.JoinDate.Month == 5);
Console.WriteLine("6. feladat: " + (mayJoin ? "Májusban volt csatlakozás!" : "Májusban nem volt csatlakozás."));


var last = members.OrderByDescending(x => x.JoinDate).First();
Console.WriteLine($"7. feladat: Legutoljára csatlakozott ország: {last.Country}");


Console.WriteLine("8. feladat: Statisztika");
var stats = members.GroupBy(x => x.JoinDate.Year)
                   .OrderBy(g => g.Key);


foreach (var group in stats)
{
    Console.WriteLine($"{group.Key} - {group.Count()} ország");
}


Console.ReadKey();