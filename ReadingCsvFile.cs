using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reading_File_Using_Dictionary
{
     class ReadingCsvFile
    {
        private String _csvFileName;
        public ReadingCsvFile(String _csvFileName)
        {
            this._csvFileName = _csvFileName;
        }
        
        public Dictionary<String,Country> ReadFile()
        {
            Dictionary<String,Country> result = new Dictionary<String,Country>();

            using(StreamReader reader = new StreamReader(this._csvFileName))
            {
                reader.ReadLine();
                String line;
                while((line = reader.ReadLine()) != null){
                    Country country = ConvartedLineToArray(line);
                    result.Add(country.Code.ToString(), country);
                }
            }

            return result;
        }
        private Country ConvartedLineToArray(String line)
        {
            String[] lineArray = line.Split(',');
            String name;
            String Code;
            String Region;
            String Population;
            switch (lineArray.Length)
            {
                case 4:
                    name = lineArray[3];    
                    Code = lineArray[2];    
                    Region = lineArray[1];
                    Population = lineArray[0];
                    break;
                case 5:
                    name = lineArray[3] + "," + lineArray[4];
                    name = name.Replace("\'", null).Trim();
                    Code = lineArray[2];
                    Region = lineArray[1];
                    Population = lineArray[0];
                    break;

                 default:
                    throw new Exception($"Error  {line} ");
            };
            int.TryParse(Population, out int population);
            return new Country(name,Code,Region,population);
        }
        


        
    }
}
