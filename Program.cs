
using Reading_File_Using_Dictionary;

namespace CountryDemoApp 
{ 
class Program
{
    private static void Main(string[] args)
    {
            String CsvFile = "C:\\Users\\user\\source\\repos\\Reading File Using Dictionary\\Country.Csv";
            ReadingCsvFile readingCsvFile = new ReadingCsvFile(CsvFile);
            Dictionary<string, Country> dictionary = new Dictionary<string, Country>();
            Console.WriteLine("Enter Country Code");
            String UserInput = Console.ReadLine();
            dictionary = readingCsvFile.ReadFile();
            bool isExist = dictionary.TryGetValue(UserInput, out Country country);
            if (isExist)
            {
                Console.WriteLine($"The Country is: {country.Name} and ThePopulation is : {country.Population} ");
            }
            else
            {
                Console.WriteLine("The Country iS Not Exist");
            }
    }
}
}