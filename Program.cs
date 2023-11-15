namespace HotelLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lift> listaLiftek = File.ReadAllLines("lift.txt").Select(x => new Lift(x)).ToList();
            Console.WriteLine($"3. feladat: Összes lifthasználat: {listaLiftek.Count}");
            Console.WriteLine($"4. feladat: Időszak: {listaLiftek.MinBy(x => x.Idopont)?.Idopont.ToShortDateString()} " +
                $"- {listaLiftek.MaxBy(x => x.Idopont)?.Idopont.ToShortDateString()}");
            Console.WriteLine($"5. feladat: Célszint max: {listaLiftek.MaxBy(x => x.CelSorszam)?.CelSorszam}");

            //Console.WriteLine($"5. feladat: Célszint max: {lista.OrderBy(x => x.CelSorszam).Last().CelSorszam}");
            //Console.WriteLine($"5. feladat: Célszint max: {lista.Select(x => x.CelSorszam).Max()}");

            Console.WriteLine("6. feladat:");
            int kartyaSorszam = 0;
            int celSorszam = 0;
            try
            {
                kartyaSorszam = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                kartyaSorszam = 5;
            }
            try
            {
                celSorszam = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                celSorszam = 5;
            }
            Console.WriteLine($"\tKártya szám: {kartyaSorszam}");
            Console.WriteLine($"\tCélszint szám: {celSorszam}");
            Console.WriteLine(listaLiftek.Exists(x => x.KartyaSorszam == kartyaSorszam && x.CelSorszam == celSorszam)
                ? $"7. feladat: A(z) {kartyaSorszam}. kártyával utaztak a(z) {celSorszam}. emeletre"
                : $"7. feladat: A(z) {kartyaSorszam}. kártyával nem utaztak a(z) {celSorszam}. emeletre");
            /*string a = "";
            string b = "nem";
            Console.WriteLine($"7. feladat: A(z) {kartyaSorszam}. kártyával " +
                $"{(lista.Any(x => x.KartyaSorszam == kartyaSorszam && x.CelSorszam == celSorszam) ? a : b)} utaztak a(z) {celSorszam}. emeletre");*/

            File.WriteAllLines("statisztika.txt", listaLiftek.GroupBy(x => x.Idopont).Select(x => $"\t{x.Key} - {x.Count()}x"));
        }
    }
}