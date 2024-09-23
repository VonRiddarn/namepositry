// TODO:
// Find a syntax that works for creating natural sounding word combinations

namespace namepositry;
class Program
{
	const string PREFIXES_FILE_PATH = "resources/prefixes.txt";
	const string WORDS_FILE_PATH = "resources/words.txt";
	
	const string CONC = "-";
	const int MAX_CONFLICT_RETRIES = 32;
	
	static string[] _prefixes = File.ReadAllLines(PREFIXES_FILE_PATH);
	static string[] _words = File.ReadAllLines(WORDS_FILE_PATH);
	
		
    static void Main(string[] args)
    {
		Console.WriteLine(GenerateName(int.Parse(args[0])));
    }
	
	// TODO:
	// Check for conflict and generate new name based on failed name
	static string GenerateName(int wordCount)
	{
		Random r = new Random();
		
		string prefix = $"{_prefixes[r.Next(0, _prefixes.Length - 1)]}{CONC}";
		string words = string.Empty;
		
		for(int i = 0; i < wordCount; i++)
		{
			string s = _words[r.Next(0, _words.Length - 1)];
			s = i == 0 ? s : $"{CONC}{s}";
			words += s;
		}
		
		return $"{prefix}{words}";
	}
}
