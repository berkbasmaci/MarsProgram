using System;
using System.Linq;
namespace MarsProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int roverCounts = 0;
            Console.WriteLine("Enter the size of area: "); 
            var area_coordinates = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList(); //Alanın boyutu kullanıcıdan istenir.
            Console.WriteLine("Enter the count of rovers: ");
            roverCounts = Convert.ToInt32(Console.ReadLine()); //Alana kaç araç gönderileceği kullanıcıdan istenir.
            string X;
            string Y;
            string dir;
            bool flag = false;
            string ordinal;
            try
            {
                for (int i = 1; i < roverCounts+1; i++) //Döngü araç sayısı kadar döner.
                {
                    if(i%10 == 1)
                    {
                        ordinal = "st"; //Araç numarasının son ek'i belirlenir
                    }
                    else if(i%10 == 2)
                    {
                        ordinal = "nd"; 
                    }
                    else if (i % 10 == 3)
                    {
                        ordinal = "rd"; 
                    }
                    else
                    {
                        ordinal = "th"; 
                    }

                    Console.WriteLine("Enter the initial values of the " + i + ordinal + " rover: ");
                    var initial = Console.ReadLine().Trim().Split(' '); //Aracın başlangıç pozisyonu ve yönü belirlenir.
                    if (Convert.ToInt32(initial[0]) < 0 || Convert.ToInt32(initial[0]) > area_coordinates[0] || Convert.ToInt32(initial[1]) < 0 || Convert.ToInt32(initial[1]) > area_coordinates[1])
                    {
                        //Aracın başlangıç pozisyonu, belirlenen alanın dışında ise hata belirtilir. Exception atılır.
                        throw new Exception("You can't place your rover outside of the plateau! Limits were at X: " + area_coordinates[0] + " and at Y: " + area_coordinates[1]);
                    }
                    else 
                    {
                        Rover rover = new Rover(); //Obje oluşturulur.
                        if (initial.Count() == 3) //Aracın başlangıç pozisyonunda beklenenden az veya fazla girilip girilmediği kontrol edilir.
                        {
                            rover.X = Convert.ToInt32(initial[0]); //Aracın başlangıç pozisyonunun X eksenindeki değeri objenin X eksenindeki değerine atanır.
                            rover.Y = Convert.ToInt32(initial[1]); //Aracın başlangıç pozisyonunun Y eksenindeki değeri objenin Y eksenindeki değerine atanır.
                            rover.Dir = (Cardinals)Enum.Parse(typeof(Cardinals), initial[2]); //Aracın başlangıç pozisyonundaki yönü objenin yönüne atanır.
                            Console.WriteLine("Enter the movements of the " + i + ordinal + " rover: ");
                            var commands = Console.ReadLine().ToUpper(); //Araca verilecek komutlar kullanıcıdan istenir.
                            rover.Move(commands, area_coordinates); //Aracın harekete başlaması için Move metodu, komut ve alan büyüklüğü parametreleri ile çağırılır.
                            X = rover.X.ToString();
                            Y = rover.Y.ToString();
                            dir = rover.Dir.ToString();
                            Console.Write(i + ordinal + " rover final position is: " + X + " " + Y + " " + dir);
                        }
                        else
                        {
                            flag = true; //Aracın başlangıç pozisyonunda beklenenden az veya fazla girildiği tespit edilip flag atanır.
                            break;
                        }
                    }
                }
                if(flag)
                {
                    throw new Exception("You gave the initial values wrong. Terminating.");
                }
                else
                {
                    Console.WriteLine("Program finished. Thank you!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
