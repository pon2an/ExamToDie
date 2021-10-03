using System;
using System.Text;
using System.Collections.Generic;
// ใช้ system Collections.Generic & Text มาเก็บข้อมูลเข้าไปในลิสต์
enum Menu
{   PlayGame = 1,   Exit   }
//การเรียงลำดับโดยกำหนดค่าตัวเลขเริ่มต้นไว้ แล้วหลังจากนั้นก็จะเรียงต่อกันไปเป็นเรื่อยๆ

namespace SuperDeadExam1_Hangman //ชื่อบ่งบอกความยาก
{
    class Program //ประกาศใช้งานคลาสหลัก
    {
        static void Main(string[] args)
        {   Menuscreen();   InputMenu();   }
        //ทำการเรียกค่าจากคลาส Menuscreen และ inputmenu

        static void Menuscreen()
        {   Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1.Play game");
            Console.WriteLine("2.Exit");    }
        //หน้าDisplay ตอนต้นโปรแกรม

        static void InputMenu()
        {   Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));
            PresentMenu(menu);   }
        //หน้าเลือกเมนู ใส่เลขเมนูเพื่อดำเนินการต่อ โดยรับค่ามากจาก PresentMenu

        static void PresentMenu(Menu menu)
        {   if (menu == Menu.PlayGame)
            {   ShowHangManGame();    }
            else if (menu == Menu.Exit)
            {   Console.ReadLine();    }    }
        // ถ้าป้อนค่ามาแล้ว ค่าเป็น 1 ก็จะดำเนินการต่อไป ถ้านอกจากนั้นจะรัน Cs.ReadLine แล้วจบการทำงาน

        static void PlayGameHangman()
        {   Console.Clear();
            Console.WriteLine("PlayGameHangman");
            Console.WriteLine("----------------------------------------");   }
        //หน้าDisplay ตอนเข้ามาสู่เกมส์

        static void ShowHangManGame()
        {   Console.Clear();
            string[] Words = new string[3]; //มี3ข้อมูลที่ลิสต์ไว้
            Words[0] = "tennis";
            Words[1] = "football";
            Words[2] = "badminton";
            //ตัวอักษรคำศัพท์ที่ให้มาอยู่ในพารามิเตอร์ที่ประกาศแล้วลิสต์ข้อมูลไว้ 
            Random random = new Random();
            int resultRandom = random.Next(0, 2);// แรนดอมข้อมูลที่ลิสต์ไว้ 0 , 1 , 2
            //randomค่าตามชื่อตัวแปร
            string mysteryWord = Words[resultRandom];
            StringBuilder displayToPlayer = new StringBuilder(mysteryWord.Length);
            //ใช้object เป็นชนิดของข้อมูล โดย Data Types สืบถอดาจาก Object
            int underscore = mysteryWord.Length;
            int incorrectWords = 0;
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();
            // อ่านค่าจากฟังก์ชั่น โดยมี value เป็น char เพื่อเก็บข้อมูล

            int lives = 6;//มี6ชีวิต
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;
            //เป็น value เก็บค่าตาม data type ต่างๆ (เลข,ตัวอักษร)

            PlayGameHangman();
            Console.WriteLine("Incorrect score : "+ incorrectWords);
            //เข้าสู่เกมโดยเรียกค่า playGH มาเป็น display อีกครั้ง แล้วก็แสดง จำนวณค่าที่ผิดในแต่ละครั้ง

            for (int i = 0; i < underscore; i++)
            {    Console.Write("_");    }
            //ตัวแสดง _ underscore เส้นข้างล่างนี่แหละครับ

            for (int i = 0; i < mysteryWord.Length; i++)
            displayToPlayer.Append('_');
            // _ จะดูตามจำนวณคำที่สุ่มได้มาแล้วเพิ่มไปจนกว่าจะครบจำนวณตัวอักษร

                while (!won && lives > 0)
                {   Console.Write("\nInput letter alphabet: ");

                    input = Console.ReadLine();
                    guess = input[0];


                    if (mysteryWord.Contains(guess))
                    {   correctGuesses.Add(guess);

                        for (int i = 0; i < mysteryWord.Length; i++)
                        {   if (mysteryWord[i] == guess)
                            {   displayToPlayer[i] = mysteryWord[i];
                                lettersRevealed++;    }    }

                        if (lettersRevealed == mysteryWord.Length)
                            won = true;    }
                    //ถ้าตอบถูก เกมก็จะดำเนินการต่อไปเรื่อยๆจาก i++ จนกว่าจะถึงค่าจำนวณตัวอักษร

                    else
                    {   incorrectGuesses.Add(guess);
                        incorrectWords++;
                        lives--;
                        PlayGameHangman();
                        Console.WriteLine("Incorrect score : " + incorrectWords);   }
                    //ถ้าผิดก็จะถูกเพิ่มเลขที่ผิด จนครบจำนวณ เมื่อครบจำนวณก็จะรันออกไปสู่ค่า else

                Console.WriteLine(displayToPlayer.ToString());
                }

                if (won)
                    Console.WriteLine("You win!!");
                else
                    Console.WriteLine("Game Over");
                //ค่า output ตอนเล่นเกมผ่าน หรือแพ้ ในตอนสุดท้าย

                Console.Write("Press ENTER to exit...");
                Console.ReadLine();    }
        //จบแล้วครับ จบแล้ว ชีวิตกับเกรดอะจบแล้ว
        // TwT แง๊
    }
}




