namespace _10WordsFrequency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите пусть к файлу:");
            string file = Console.ReadLine();

            string text = File.ReadAllText(file);

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            char[] separators = {' ', '\n'};
            string[] words = noPunctuationText.Split(separators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var dictionaryWords = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (dictionaryWords.ContainsKey(word))
                    dictionaryWords[word] += 1;
                else
                    dictionaryWords.Add(word, 1);
            }
            var sotrDictionaryWords = dictionaryWords.OrderByDescending(value => value.Value).ToDictionary(key => key.Key, value => value.Value);

            int i = 0;
            foreach (var word in sotrDictionaryWords)
            {
                if (i == 10) break;
                Console.WriteLine($"Слово: '{word.Key}' встречается в тексте {word.Value} раз");
                i++;
            }
        }
    }
}