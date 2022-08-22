using ToDo;
BoardActions boardAction = new();
while (true)
{
    Console.WriteLine("\n *******************************************");
    Console.WriteLine("                 ANA MENÜ");
    Console.WriteLine("  Lütfen yapmak istediğiniz işlemi seçiniz");
    Console.WriteLine(" *******************************************");
    Console.WriteLine(" (1) Board'a Kart Ekle");
    Console.WriteLine(" (2) Board'daki Kartı Güncelle");
    Console.WriteLine(" (3) Board'dan Kart Sil");
    Console.WriteLine(" (4) Kartı Taşı");
    Console.WriteLine(" (5) Board'u Listele");
    Console.WriteLine(" (6) Uygulamayı Sonlandır");
    int caseNumber = 0;
    Int32.TryParse(Console.ReadLine(), out caseNumber);
    switch (caseNumber)
    {
        case 1:
            boardAction.CardAdd();
            break;
        case 2:
            boardAction.CardUpdate();
            break;
        case 3:
            boardAction.CardDelete();
            break;
        case 4:
            boardAction.CardTransfer();
            break;
        case 5:
            boardAction.ListBoard();
            break;
        case 6:
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine(" Geçersiz giriş");
            break;
    }
}