using System;

class Program
{
    static void Main()
    {
        string[] ipv4Input = { "107.31.1.5", "255.0.0.255", "555..0.555", "255...255" };

        foreach (string ip in ipv4Input)
        {
            if (IsValidIPv4(ip))
            {
                Console.WriteLine($"{ip} is a valid IPv4 address");
            }
            else
            {
                Console.WriteLine($"{ip} is an invalid IPv4 address");
            }
        }
    }

    static bool IsValidIPv4(string ip)
    {
        string[] address = ip.Split(".", StringSplitOptions.RemoveEmptyEntries);

        // Validate Length: There should be exactly 4 parts
        if (address.Length != 4)
        {
            return false;
        }

        foreach (string part in address)
        {
            // Validate Zeroes and Range using TryParse and StartsWith
            if (part.Length > 1 && part.StartsWith("0"))
            {
                return false;
            }

            if (!int.TryParse(part, out int value) || value < 0 || value > 255)
            {
                return false;
            }
        }

        return true;
    }
}