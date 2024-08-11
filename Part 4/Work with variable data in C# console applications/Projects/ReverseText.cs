Console.WriteLine(" 4. Reverse the text:  The quick brown fox jumps over the lazy dog \n");
string pangram = "The quick brown fox jumps over the lazy dog";
string[] words = pangram.Split();
string result = "";
foreach (var word in words)
{
    char[] valueAsArray = word.ToCharArray();
    Array.Reverse(valueAsArray);
    result += new string(valueAsArray) + " ";
}
Console.WriteLine(result);