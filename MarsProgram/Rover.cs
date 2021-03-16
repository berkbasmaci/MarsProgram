using System;
using System.Collections.Generic;
using System.Text;

namespace MarsProgram
{
    public enum Cardinals //Yönler enum olarak tanımlanır.
    {
        N = 1,
        S = 2,
        E = 3,
        W = 4
    }

    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Cardinals Dir { get; set; }

        public Rover()
        {
            X = 0;
            Y = 0;
            Dir = Cardinals.N;
        }

        private void Forward() 
        {
            switch (this.Dir) //İlerle komutu geldiğinde aracın o anlık yönüne göre X veya Y değerleri değiştirilir.
            {
                case Cardinals.N:
                    this.Y += 1;
                    break;
                case Cardinals.S:
                    this.Y -= 1;
                    break;
                case Cardinals.E:
                    this.X += 1;
                    break;
                case Cardinals.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }

        private void Right() //Sağa dön komutu geldiğinde aracın o anlık yönüne göre yeni yönü belirlenir.
        {
            switch (this.Dir)
            {
                case Cardinals.N:
                    this.Dir = Cardinals.E;
                    break;
                case Cardinals.S:
                    this.Dir = Cardinals.W;
                    break;
                case Cardinals.E:
                    this.Dir = Cardinals.S;
                    break;
                case Cardinals.W:
                    this.Dir = Cardinals.N;
                    break;
                default:
                    break;
            }
        }

        private void Left() //Sola dön komutu geldiğinde aracın o anlık yönüne göre yeni yönü belirlenir.
        {
            switch (this.Dir)
            {
                case Cardinals.N:
                    this.Dir = Cardinals.W;
                    break;
                case Cardinals.S:
                    this.Dir = Cardinals.E;
                    break;
                case Cardinals.E:
                    this.Dir = Cardinals.N;
                    break;
                case Cardinals.W:
                    this.Dir = Cardinals.S;
                    break;
                default:
                    break;
            }
        }

        public void Move(string commands, List<int> area_coordinates) 
        {
            foreach (var command in commands) //Gelen komut dizisindeki her bir komut için ilgili method çağırılır.
            {
                switch (command)
                {
                    case 'M':
                        this.Forward();
                        break;
                    case 'R':
                        this.Right();
                        break;
                    case 'L':
                        this.Left();
                        break;
                    default:
                        Console.WriteLine("Unknown command: " + command );
                        break;
                }

                if (this.X < 0 || this.X > area_coordinates[0] || this.Y < 0 || this.Y > area_coordinates[1]) // Aracın alan dışına çıkması durumunda Exception verilir.
                {
                    Console.WriteLine("Your rover cross the border of the plateau! Limits were at X: " + area_coordinates[0] + " and at Y: " + area_coordinates[1]);
                    throw new Exception();
                }
            }
        }
    }
}
