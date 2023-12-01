public class Forca
{
    private string wordToGuess;
    private int maxAttempts;
    private List<char> guessedLetters;
    private int wrongAttempts;

    public Forca(string wordToGuess, int maxAttempts)
    {
        this.wordToGuess = wordToGuess;
        this.maxAttempts = maxAttempts;
        this.guessedLetters = new List<char>();
        this.wrongAttempts = 0;
    }

    public bool CheckLetter(char letter)
    {
        if (wordToGuess.Contains(letter))
        {
            guessedLetters.Add(letter);
            return true;
        }
        else
        {
            wrongAttempts++;
            return false;
        }
    }

    public bool IsWordComplete()
    {
        foreach (char letter in wordToGuess)
        {
            if (!guessedLetters.Contains(letter))
            {
                return false;
            }
        }
        return true;
    }

    public bool IsGameOver()
    {
        return wrongAttempts >= maxAttempts;
    }

    public string GetGuessedWord()
    {
        string guessedWord = "";
        foreach (char letter in wordToGuess)
        {
            if (guessedLetters.Contains(letter))
            {
                guessedWord += letter;
            }
            else
            {
                guessedWord += "_";
            }
        }
        return guessedWord;
    }

    public int GetRemainingAttempts()
    {
        return maxAttempts - wrongAttempts;
    }

    public string GetWordToGuess()
    {
        return wordToGuess;
    }

    public string GetStickman()
    {
        string[] stickman = new string[7] {
            " +---+\n |   |\n     |\n     |\n     |\n     |\n=========\n",
            " +---+\n |   |\n O   |\n     |\n     |\n     |\n=========\n",
            " +---+\n |   |\n O   |\n |   |\n     |\n     |\n=========\n",
            " +---+\n |   |\n O   |\n/|   |\n     |\n     |\n=========\n",
            " +---+\n |   |\n O   |\n/|\\  |\n     |\n     |\n=========\n",
            " +---+\n |   |\n O   |\n/|\\  |\n/    |\n     |\n=========\n",
            " +---+\n |   |\n O   |\n/|\\  |\n/ \\  |\n     |\n=========\n"
        };
        return stickman[wrongAttempts];
    }
}

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("\n███████  ██████  ██████   ██████  █████  ");
        Console.WriteLine("██      ██    ██ ██   ██ ██      ██   ██ ");
        Console.WriteLine("█████   ██    ██ ██████  ██      ███████ ");
        Console.WriteLine("██      ██    ██ ██   ██ ██      ██   ██ ");
        Console.WriteLine("██       ██████  ██   ██  ██████ ██   ██ ");
        Console.WriteLine("\nBem-vindo ao Jogo da Forca!\n");

        List<string> words = new List<string>()
        {
            "cachorro",
            "gato",
            "elefante",
            "girafa",
            "leão",
            "tigre",
            "zebra",
            "hipopótamo",
            "rinoceronte",
            "macaco",
            "papagaio",
            "tucano",
            "arara",
            "jacaré",
            "crocodilo",
            "camaleão",
            "tartaruga",
            "cobra",
            "lagarto",
            "iguana"
        };

        Random rand = new Random();
        string wordToGuess = words[rand.Next(words.Count)];
        Forca game = new Forca(wordToGuess, 6);

        while (!game.IsGameOver() && !game.IsWordComplete())
        {
            Console.Write("Digite uma letra: ");
            char letter = Console.ReadLine()[0];
            Console.Write("\n");
            if (!game.CheckLetter(letter))
            {
                Console.WriteLine("Errou! Letra não existe na palavra-chave.\n");
            }
            Console.WriteLine(game.GetStickman());
            Console.WriteLine(game.GetGuessedWord());
            Console.WriteLine($"\nTentativas restantes: {game.GetRemainingAttempts()}\n");
        }

        if (game.IsWordComplete())
        {
            Console.WriteLine("Parabéns, você adivinhou a palavra!");
        }
        else
        {
            Console.WriteLine("Fim de jogo, você atingiu o número máximo de tentativas.");
            Console.WriteLine($"A palavra era: {game.GetWordToGuess()}");
        }
    }
}