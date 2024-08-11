Console.WriteLine(" 5. Order the next string: B123,C234,A345,C15,B177,G3003,C235,B179 \n");
string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
string[] orderArray = orderStream.Split(',');
Array.Sort(orderArray);
foreach (var word in orderArray)
{
    if (word.Length != 4)
    {
        Console.WriteLine(word + "\t- Error");
    }
    else
    {
        Console.WriteLine(word);
    }
}