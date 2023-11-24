// See https://aka.ms/new-console-template for more information
using Alghrithm;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Algorithm
{
    class Program
    {
        
        static void Main(string[] args) 
        {
            int selected = 0;
            bool validInput = true;
            while (validInput)
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("[HELLO .NET 6.0]");
                Console.WriteLine("알고리즘, 코딩테스트 구현");
                Console.WriteLine(DateTime.Now.ToString("yyyy년 MM월 dd일 HH:mm:ss"));
                Console.WriteLine("=================================================");
                Console.WriteLine("목록을 선택하세요. 종료하려면 '0'을 입력하세요.");
                Console.WriteLine("[1] 코딩테스트");
                Console.WriteLine("[2] 알고리즘");

                try
                {
                    Console.Write("입력 : ");
                    selected = Convert.ToInt32(Console.ReadLine());
                    switch(selected)
                    {
                        case 0:
                            Console.WriteLine("프로그램을 종로합니다.");
                            return;
                        case 1:
                            CodingTest codingTest= new CodingTest();
                            break;
                        case 2:
                            break;

                        default:
                            validInput = false;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("올바른 숫자를 입력하세요.");
                }
            }
                
        }


    }
}