// setup promenne predstavujici LED žarovku
bool led = false;
// nekonečná smyčka opakující se do konce

while (true)
{
    Console.WriteLine("Zmačkni mezerník pro rožnutí LED");
    
    ConsoleKeyInfo klavesa = Console.ReadKey();
    // rozhodovací podmínka
    // pokud je splněná vykoná se navazující blok
    if(klavesa.Key == ConsoleKey.Spacebar)
    {
        led = true;
    }
    if(led)
    {
        Console.WriteLine("sviti");
    }
    else
    {
        Console.WriteLine("nesviti");

    }
    led = false;
    Thread.Sleep(500);
}