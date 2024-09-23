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
		int wordCount = 2;
		
		try 
		{ 
			wordCount = int.TryParse(args[0], out int _w) ? _w : 2;
			if(wordCount <= 0)
				throw new Exception("Input cannot be less than or equal to 0");
		}
		catch
		{
			Console.WriteLine("Couldn't parse wordcount arg. Defaulting to: 2.");
		}
		
		Console.WriteLine(GenerateName(wordCount));
    }
	
	// TODO:
	// Check for conflict and generate new name based on failed name
	static string GenerateName(int wordCount)
	{
		Random r = new Random();
		
		string prefix = $"{_prefixes[r.Next(0, _prefixes.Length)]}{CONC}";
		string words = string.Empty;
		
		for(int i = 0; i < wordCount; i++)
		{
			string s = _words[r.Next(0, _words.Length)];
			s = i == 0 ? s : $"{CONC}{s}";
			words += s;
		}
		
		return $"{prefix}{words}";
	}
}
