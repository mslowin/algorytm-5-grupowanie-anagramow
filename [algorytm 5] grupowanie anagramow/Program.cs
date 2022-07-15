// See https://aka.ms/new-console-template for more information
using System.Text;

bool run = true;
List<string> words = new();
List<string> group = new();
List<string> ListOfGroups = new();
Console.WriteLine("Type some words to see if there are anagrams within them. Press 'q' to exit \n");

while (run)
{
    var input = Console.ReadLine();

    if (input == null)
    {
        Console.WriteLine("Coś poszło nie tak");
    }
    else if (input == "q")
    {
        run = false;
    }
    else
    {
        input = input.ToString();
        input = RemoveSpecialCharacters(input); // after this operation what is left are just characters and commas
        words = input.Split(',').ToList();

        for (int j = 0; j < words.Count; j++)
        {
            string tmp = String.Concat(words[j].OrderBy(ch => ch)).ToLower(); // sorting word in alphabetical order

            for (int x = 0; x < words.Count; x++)
            {
                string tmp2 = String.Concat(words[x].OrderBy(ch => ch)).ToLower(); // sorting other words in alphabetical order

                if (tmp2 == tmp) // if they are the same we add them to a group
                {
                    group.Add(words[x]);
                }
            }
            var result = String.Join(", ", group.ToArray()); // making a string from a group list
            ListOfGroups.Add(result); // and placing the string into final list of anagrams
            group.Clear(); // clearing group to chceck next word
        }
        ListOfGroups = ListOfGroups.Distinct().ToList(); // getting rid of dupilcates
        ListOfGroups.ForEach(x => Console.WriteLine(x)); // final output
        Console.WriteLine();
        words.Clear();
        ListOfGroups.Clear();
    }
}

static string RemoveSpecialCharacters(string str)
{
    StringBuilder sb = new StringBuilder();
    foreach (char c in str)
    {
        if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ',')
        {
            sb.Append(c);
        }
    }
    return sb.ToString();
}