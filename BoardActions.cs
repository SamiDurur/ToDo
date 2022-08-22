using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal class BoardActions
    {
        private List<Card> cards;
        private Person persons;
        internal BoardActions()
        {
            Initialize();
        }
        public void CardAdd()
        {
            int sizeKey;
            int assignedPersonKey;
            bool nullControl;
            Card card = new Card();
            Console.Write("\n Başlık Giriniz                                         : ");
            card.Title = Console.ReadLine();

            Console.Write(" Açıklama Giriniz                                       : ");
            card.Content = Console.ReadLine();

            Console.Write(" Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)         : ");
            Int32.TryParse(Console.ReadLine(), out sizeKey);
            if (sizeKey > 0 && sizeKey < 6)
            {
                card.Size = (ToDoSize)sizeKey;

                Console.WriteLine(" ----- Kişi Seçiniz -----");
                persons.ListPerson();

                nullControl = Int32.TryParse(Console.ReadLine(), out assignedPersonKey);
                if (nullControl)
                {
                    card.AssignedPerson = persons.GetPerson(assignedPersonKey);
                    card.Line = "TODO";
                    cards.Add(card);
                    Console.WriteLine("\n Kart Başarı ile eklendi.Ana menü için bir tuşa basın.");
                }
                else
                    Console.WriteLine("\n Hatalı Giriş yapıldı.Kart Eklenmedi.Ana menü için bir tuşa basın.");
            }
            else
                Console.WriteLine("\n Hatalı Giriş yapıldı.Kart Eklenmedi.Ana menü için bir tuşa basın.");
            Console.ReadKey();

        }
        public void CardUpdate()
        {

            Card transferCard = new();
            bool isCardFound = false;
            int userChoice;

            Console.Write("\n Öncelikle Güncellemek istediğiniz kartı seçmeniz gerekiyor.\n Lütfen kart başlığını yazınız : ");
            transferCard.Title = Console.ReadLine();
            foreach (Card card in cards)
                if (card.Title == transferCard.Title)
                {
                    int thisUpdate = 0;
                    isCardFound = true;
                    Console.Write("\n\n Bulunan Kart Bilgileri :\n*******************************************************\n (1) Başlık       : {0}\n (2) İçerik       : {1}\n (3) Atanan Kişi  : {2}\n (4) Büyüklük     : {3}\n\n Hangisi güncellensin seçin: "
                        , card.Title, card.Content, card.AssignedPerson, card.Size);
                    Int32.TryParse(Console.ReadLine(), out thisUpdate);
                    if (thisUpdate == 1)
                    {
                        Console.Write("\n Yeni Başlık  : ");
                        card.Title = Console.ReadLine();
                        Console.WriteLine("\n Başlık '{0}' olarak gücellendi. Ana menü için bir tuşa basın.", card.Title);
                    }
                    else if (thisUpdate == 2)
                    {
                        Console.Write("\n Yeni İçerik : ");
                        card.Content = Console.ReadLine();
                        Console.WriteLine("\n İçerik '{0}' olarak güncellendi. Ana menü için bir tuşa basın.", card.Content);
                    }
                    else if (thisUpdate == 3)
                    {
                        int assignedPersonKey;
                        persons.ListPerson();
                        Console.Write("\n Yeni Atanacak Kişi : ");
                        Int32.TryParse(Console.ReadLine(), out assignedPersonKey);
                        if (assignedPersonKey > 0 && assignedPersonKey < 4)
                        {
                            card.AssignedPerson = persons.GetPerson(assignedPersonKey);
                            Console.WriteLine("\n Atanan kişi '{0}' olarak güncellendi. Ana menü için bir tuşa basın.", card.AssignedPerson);
                        }
                        else
                            Console.WriteLine("\n Hatalı tuşlama yapıldı.Güncelleme işlemi iptal edildi. Ana menü için bir tuşa basın.");
                    }
                    else if (thisUpdate == 4)
                    {
                        int sizeKey;
                        Console.Write("\n Yeni Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)     : ");
                        Int32.TryParse(Console.ReadLine(), out sizeKey);
                        if (sizeKey > 0 && sizeKey < 6)
                        {
                            card.Size = (ToDoSize)sizeKey;
                            Console.WriteLine("\n Büyüklük '{0}' olarak güncellendi. Ana menü için bir tuşa basın.", card.Size);
                        }

                        else
                            Console.WriteLine("\n Hatalı tuşlama yapıldı.Güncelleme işlemi iptal edildi. Ana menü için bir tuşa basın.");
                    }
                    else
                        Console.WriteLine("\n Hatalı tuşlama yapıldı.Güncelleme işlemi iptal edildi. Ana menü için bir tuşa basın.");
                }

            if (!isCardFound)
            {
                Console.WriteLine("\n Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n * İşlemi sonlandırmak için  : (1)\n * Yeniden denemek için      : (2)");
                Int32.TryParse(Console.ReadLine(), out userChoice);
                if (userChoice == 2)
                    CardTransfer();
                else
                    Console.WriteLine("\n Hatalı tuşlama yapıldı veya işlem iptal edildi. Ana menü için bir tuşa basın.");
            }
            Console.ReadKey();
        }
        public void CardDelete()
        {
            Card deleteCard = new();
            bool isCardFound = false;
            int userChoice;
            Console.Write("\n Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\n Lütfen kart başlığını yazınız : ");
            deleteCard.Title = Console.ReadLine();
            foreach (var card in cards.ToList())
                if (deleteCard.Title == card.Title)
                {
                    deleteCard = card;
                    cards.Remove(deleteCard);
                    Console.WriteLine("\n Kart Silme işlemi tamamlandı.Ana menü için bir tuşa basın.");
                    isCardFound = true;
                }
            if (!isCardFound)
            {
                Console.WriteLine("\n Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için      : (2)");
                Int32.TryParse(Console.ReadLine(), out userChoice);
                if (userChoice == 2)
                    CardDelete();
                else
                    Console.WriteLine("\n Hatalı tuşlama yapıldı veya işlem iptal edildi. Ana menü için bir tuşa basın.");
            }
            Console.ReadKey();

        }
        public void CardTransfer()
        {

            Card transferCard = new();
            bool isCardFound = false;
            int userChoice;


            Console.Write("\n Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.\n Lütfen kart başlığını yazınız : ");
            transferCard.Title = Console.ReadLine();
            foreach (var card in cards.ToList())
                if (transferCard.Title == card.Title)
                {
                    int selectLine = 0;
                    isCardFound = true;
                    Console.WriteLine("\n Bulunan Kart Bilgileri :\n *******************************************************\n Başlık       : {0}\n İçerik       : {1}\n Atanan Kişi  : {2}\n Büyüklük     : {3}\n Line         : {4}\n\n Lütfen taşımak istediğiniz Line'ı seçiniz.\n (1) TODO\n (2) IN PROGRESS \n (3) DONE"
                        , card.Title, card.Content, card.AssignedPerson, card.Size, card.Line);
                    Int32.TryParse(Console.ReadLine(), out selectLine);
                    if (selectLine == 1)
                    {
                        card.Line = "TODO";
                        ListBoard();
                    }
                    else if (selectLine == 2)
                    {
                        card.Line = "IN PROGRESS";
                        ListBoard();
                    }
                    else if (selectLine == 3)
                    {
                        card.Line = "DONE";
                        ListBoard();
                    }
                    else
                        Console.WriteLine("\n Hatalı tuşlama yapıldı.Taşıma işlemi iptal edildi. Ana menü için bir tuşa basın.");                    
                }

            if (!isCardFound)
            {
                Console.WriteLine("\n Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* İşlemi sonlandırmak için  : (1)\n* Yeniden denemek için      : (2)");
                Int32.TryParse(Console.ReadLine(), out userChoice);
                if (userChoice == 2)
                    CardTransfer();
                else
                    Console.WriteLine("\n Hatalı tuşlama yapıldı veya işlem iptal edildi. Ana menü için bir tuşa basın.");
            }
            Console.ReadKey();
        }
        public void ListBoard()
        {
            Console.WriteLine("\n TODO Line" + "\n *********************");
            ListSeparator("TODO");
            Console.WriteLine("\n IN PROGRESS Line" + "\n *********************");
            ListSeparator("IN PROGRESS");
            Console.WriteLine("\n DONE Line" + "\n *********************");
            ListSeparator("DONE");
            Console.WriteLine("\n Ana menü için bir tuşa basın");
            Console.ReadKey();
        }
        public void ListSeparator(string line)
        {
            int count = 0;
            foreach (var card in cards)
            {
                if (line == card.Line)
                {
                    Console.WriteLine("\n Başlık       : {0}\n İçerik       : {1}\n Atanan Kişi  : {2}\n Büyüklük     : {3}\n-", card.Title, card.Content, card.AssignedPerson, card.Size);
                    count++;
                }
            }
            if (count == 0)
                Console.WriteLine("\n ~ BOŞ ~");
        }
        public void Initialize()
        {
            if (cards == null) { persons = new(); cards = new List<Card>(); }
            cards.Add(new Card("Temizlik", "Odanı Süpür", persons.GetPerson(1), ToDoSize.S, "TODO"));
            cards.Add(new Card("Kıyafet", "Kıyafetleri Katla", persons.GetPerson(2), ToDoSize.M, "DONE"));
            cards.Add(new Card("Kahvaltı", "kahvaltı hazırla", persons.GetPerson(4), ToDoSize.L, "IN PROGRESS"));

        }
    }
}