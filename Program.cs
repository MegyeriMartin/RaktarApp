using RaktarApp;

List<Termek> termekek = new List<Termek>();
int hibassorokszama = 0;
foreach (string sor in File.ReadAllLines("termekek.txt").Skip(1))
{
    if (string.IsNullOrWhiteSpace(sor))
    {
        hibassorokszama++;
        continue;
    }
    string[] mezok = sor.Split("|");
    if (mezok.Length != 4)
    {
        hibassorokszama++;
        continue;
    }
    if (mezok[0]!="S" && mezok[0] != "G")
    {
        hibassorokszama++;
        continue;
    }
    if (!int.TryParse(mezok[2], out int alapar) || !int.TryParse(mezok[3], out int garancia))
    {
        hibassorokszama++;
        continue;
    }
    if (mezok[0] == "S")
    {
        Termek aktualistermek = new Termek(mezok[0], alapar);
        termekek.Add(aktualistermek);
    }
    else
    {
        TartosTermek aktualistermek = new TartosTermek(mezok[0], alapar, garancia);
        termekek.Add(aktualistermek);
    }
    
}
Console.WriteLine($"sikeresen beolvasott Termkekek: {termekek.Count} db");
Console.WriteLine($"Sikertelenul beolvasott termekek: {hibassorokszama} db");

foreach (Termek termek in termekek){
    Console.WriteLine(termek);
}
Console.WriteLine();
int teljesertek = termekek.Sum(t => t.ErtekSzamitas(10));
Console.WriteLine($"A teljes raktarkeszlet osszerteke: {teljesertek}");

Console.WriteLine($"\nösszes termek szama : {Termek.OsszesTermekSzama} db ");
