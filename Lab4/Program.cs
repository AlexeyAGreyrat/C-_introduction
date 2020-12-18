using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1
            char[] BoxUp = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'К' };
            string[] Boxdown = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            int decks3 = 2;
            int decks2 = 3;
            int decks1 = 4;
            int typeShip3 = 3;
            int typeShip2 = 2;
            Random rnd = new Random();
            int[,] mass = new int[10, 10];
            char[,] massShip = new char[11, 11];
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    mass[i, j] = 0;
                }
            }
            mass = ship4(mass);
            for (var i = 0; i < decks3; i++)
            {
                mass = ship3(mass, typeShip3);
            }
            for (var i = 0; i < decks2; i++)
            {
                mass = ship2(mass, typeShip2);
            }
            for (var i = 0; i < decks1; i++)
            {
                mass = ship1(mass);
            }
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (mass[i, j] == 0)
                    {
                        massShip[i, j] = 'O';
                    }
                    else
                    {
                        massShip[i, j] = 'X';
                    }
                }
            }
            for (int i = 0; i < massShip.GetLength(0); i++)
            {
                for (int j = 0; j < massShip.GetLength(1); j++)
                {
                    if (i == 0 & j == 0)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        if (i == 0)
                            Console.Write(BoxUp[j - 1] + " ");
                        else
                            if (j == 0)
                        {
                            if (i == 10)
                                Console.Write(Boxdown[i - 1] + " ");
                            else
                                Console.Write(Boxdown[i - 1] + "  ");

                        }
                        else
                        {
                            if (mass[i - 1, j - 1] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            Console.Write(massShip[i - 1, j - 1] + " ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                    }
                }
                Console.WriteLine();
            }
            #endregion
            int[,] ship4(int[,] SMass)
            {
                int iX = rnd.Next(0, 10);
                int iY = rnd.Next(0, 10);
                SMass[iX, iY] = 1;
                int ix = iX;
                int iy = iY;
                int k = 0;
                bool horizontal = false, vertical = false;
                if (rnd.Next(0, 2) == 0)
                    horizontal = true;
                else
                    vertical = true;
                if (horizontal == true)
                {
                    //проверка
                    if ((iy - 3) > 0)
                    {
                        //left
                        while (true)
                        {

                            if (k < 3)
                            {
                                SMass[iX, --iy] = 1;
                                k++;
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        //right
                        while (true)
                        {

                            if (k < 3)
                            {
                                SMass[iX, ++iy] = 1;
                                k++;
                            }
                            else
                                break;
                        }
                    }

                }
                if (vertical == true)
                {
                    //проверка
                    if ((ix - 3) > 0)
                    {
                        //up
                        while (true)
                        {

                            if (k < 3)
                            {
                                SMass[--ix, iY] = 1;
                                k++;
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        //down
                        while (true)
                        {

                            if (k < 3)
                            {
                                SMass[++ix, iY] = 1;
                                k++;
                            }
                            else
                                break;
                        }
                    }
                }
                return SMass;
            }
            int[,] ship3(int[,] SMass, int type)
            {
                int iX = rnd.Next(0, 10);
                int iY = rnd.Next(0, 10);                                                            
                int ix = iX;
                int iy = iY;
                int tmp = 0;
                bool left = true, right = true, up = true, down = true;
                bool chek = true;
                //проверка
                int k = 0;
                while (true)
                {
                    k = check(iX, iY, SMass);
                    if (k == 9)
                    {
                        //проверка right
                        right = Right(iX, iY, SMass, right, chek, type);
                        //проверка left
                        left = Left(iX, iY, SMass, left, chek, type);
                        //проверка up
                        up = Up(iX, iY, SMass, up, chek, type);
                        //проверка down
                        down = Down(iX, iY, SMass, down, chek, type);
                        #region 2                     
                        if (right == true | left == true | up == true | down == true)
                        {
                            while (chek == true)
                            {
                                SMass[iX, iY] = 1;
                                int z = rnd.Next(1, 5);
                                //left
                                while (left == true & z == 1)
                                {
                                    if (tmp < type - 1)
                                    {
                                        SMass[iX, --iy] = 1;
                                        tmp++;
                                    }
                                    else
                                    {
                                        chek = false;
                                        break;
                                    }
                                }
                                //right
                                while (right == true & z == 2)
                                {

                                    if (tmp < type - 1)
                                    {
                                        SMass[iX, ++iy] = 1;
                                        tmp++;
                                    }
                                    else
                                    {
                                        chek = false;
                                        break;
                                    }
                                }
                                //up
                                while (up == true & z == 3)
                                {

                                    if (tmp < type - 1)
                                    {
                                        SMass[--ix, iY] = 1;
                                        tmp++;

                                    }
                                    else
                                    {
                                        chek = false;
                                        break;
                                    }
                                }
                                //down
                                while (down == true & z == 4)
                                {

                                    if (tmp < type - 1)
                                    {
                                        SMass[++ix, iY] = 1;
                                        tmp++;
                                    }
                                    else
                                    {
                                        chek = false;
                                        break;
                                    }
                                }
                            }
                            if (chek == false)
                                break;
                        }
                        else
                        {
                            k = 0;
                            iX = rnd.Next(0, 10);
                            iY = rnd.Next(0, 10);
                            ix = iX;
                            iy = iY;
                        }
                        #endregion 
                    }
                    else
                    {
                        k = 0;
                        iX = rnd.Next(0, 10);
                        iY = rnd.Next(0, 10);
                        ix = iX;
                        iy = iY;
                    }

                }

                return SMass;
            }
            int[,] ship2(int[,] SMass, int type)
            {
                int iX = rnd.Next(0, 10);
                int iY = rnd.Next(0, 10);
                int ix = iX;
                int iy = iY;
                int tmp = 0;
                bool left = true, right = true, up = true, down = true;
                bool chek = true;
                //проверка
                int k = 0;
                while (true)
                {
                    k = check(iX, iY, SMass);
                    if (k == 9)
                    {
                        //проверка right
                        right = Right(iX, iY, SMass, right, chek, type);                        
                        //проверка left
                        left = Left(iX, iY, SMass, left, chek, type);                       
                        //проверка up
                        up = Up(iX, iY, SMass, up, chek, type);                       
                        //проверка down
                        down = Down(iX, iY, SMass, down, chek, type);                        
                        #region 2                                          
                        if (right == true | left == true | up == true | down == true)
                        {
                            while (chek == true)
                            {
                                SMass[iX, iY] = 1;
                                int z = rnd.Next(1, 5);
                                //left

                                while (left == true & z == 1)
                                {
                                    if (tmp < type-1)
                                    {
                                        SMass[iX, --iy] = 1;
                                        tmp++;
                                    }
                                    else
                                    {
                                        chek = false;
                                        break;
                                    }
                                }
                                //right
                                while (right == true & z == 2)
                                {

                                    if (tmp < type-1)
                                    {
                                        SMass[iX, ++iy] = 1;
                                        tmp++;
                                    }
                                    else
                                    {
                                        chek = false;
                                        break;
                                    }
                                }
                                //up
                                while (up == true & z == 3)
                                {

                                    if (tmp < type-1)
                                    {
                                        SMass[--ix, iY] = 1;
                                        tmp++;

                                    }
                                    else
                                    {
                                        chek = false;
                                        break;
                                    }
                                }
                                //down
                                while (down == true & z == 4)
                                {

                                    if (tmp < type-1)
                                    {
                                        SMass[++ix, iY] = 1;
                                        tmp++;
                                    }
                                    else
                                    {
                                        chek = false;
                                        break;
                                    }
                                }
                            }
                            if (chek == false)
                                break;
                        }
                        else
                        {
                            k = 0;
                            iX = rnd.Next(0, 10);
                            iY = rnd.Next(0, 10);
                            ix = iX;
                            iy = iY;
                        }
                        #endregion 
                    }
                    else
                    {
                        k = 0;
                        iX = rnd.Next(0, 10);
                        iY = rnd.Next(0, 10);
                        ix = iX;
                        iy = iY;
                    }
                }
                return SMass;
            }
            int[,] ship1(int[,] SMass)
            {
                int iX = rnd.Next(0, 10);
                int iB = rnd.Next(0, 10);
                int ix = iX;
                int iy = iB;
                int k = 0;
                while (true)
                {
                    k = check(iX, iB, SMass);
                    if (k == 9)
                    {
                        SMass[ix, iy] = 1;
                        return SMass;
                    }
                    else
                    {
                        k = 0;
                        iX = rnd.Next(0, 10);
                        iB = rnd.Next(0, 10);
                        ix = iX;
                        iy = iB;
                    }
                }

            }

        }
        #region Проверка округа
        static int check(int iX, int iY, int[,] SMass)
        {
            int k = 0;
            int ix = iX;
            int iy = iY;
            if (SMass[ix, iy] == 0)
            {
                for (int i = iX - 1; i <= iX + 1; i++)
                {
                    for (int j = iY - 1; j <= iY + 1; j++)
                    {
                        if (i > SMass.GetLength(0) - 1 || i < 0 || j > SMass.GetLength(1) - 1 || j < 0)
                            k++;
                        else
                        {
                            if (SMass[i, j] == 0 || SMass[iX, iY] == SMass[i, j])
                                k++;
                        }
                    }
                }
            }
            return k;
        }
        #endregion
        #region Проверка права
        static bool Right(int iX, int iY, int[,] SMass, bool right, bool chek, int type)
        {
            int iy = iY;
            int ix = iX;
            int tmp1 = 0;
            for (int i = iy; i < iy + type;)
            {
                i++;
                if (i <= 9)
                {
                    if (SMass[iX, i] == 0)
                    {
                        tmp1++;
                    }
                    if (iX - 1 >= 0)
                    {
                        if (SMass[iX - 1, i] != 0)
                        {
                            tmp1 = 0;
                            break;
                        }

                    }
                    if (iX + 1 <= 9 )
                    {
                        if (SMass[iX + 1, i] != 0)
                        {
                            tmp1 = 0;
                            break;
                        }

                    }
                }
                if (i > 9 & tmp1 == type - 1)
                {
                    tmp1++;
                }
            }
            if (tmp1 == type)
            {
                right = true;
                chek = true;
                tmp1 = 0;
                return right;
            }
            else
            {
                right = false;
                tmp1 = 0;
                return right;
            }
        }
        #endregion
        #region Проверка лево
        static bool Left(int iX, int iY, int[,] SMass, bool left, bool chek, int type)
        {
            int ix = iX;
            int iy = iY;
            int tmp = 0;
            for (int i = iy; i > iy - type;)
            {
                i--;
                if (i >= 0)
                {
                    if (SMass[iX, i] == 0)
                    {
                        tmp++;
                    }
                    if (iX - 1 >= 0)
                    {
                        if (SMass[iX - 1, i] != 0)
                        {
                            tmp = 0;
                            break;
                        }

                    }
                    if (iX + 1 <= 9)
                    {
                        if (SMass[iX + 1, i] != 0)
                        {
                            tmp = 0;
                            break;
                        }

                    }
                }
                if (i < 0 & tmp == type - 1)
                {
                    tmp++;
                }
            }
            if (tmp == type)
            {
                left = true;
                chek = true;
                return left;
            }
            else
            {
                left = false;
                return left;
            }
        }
        #endregion
        #region Проверка верха
        static bool Up(int iX, int iY, int[,] SMass, bool up, bool chek, int type)
        {
            int ix = iX;
            int iy = iY;
            int tmp = 0;
            for (int i = ix; i > ix - 3;)
            {
                i--;
                if (i >= 0)
                {
                    if (SMass[i, iY] == 0)
                    {
                        tmp++;
                    }
                    if (iY - 1 >= 0)
                    {
                        if (SMass[i, iY - 1] != 0)
                        {
                            tmp = 0;
                            break;
                        }

                    }
                    if (iY + 1 <= 9)
                    {
                        if (SMass[i, iY + 1] != 0)
                        {
                            tmp = 0;
                            break;
                        }

                    }
                }
                if (i <= 0 & tmp == 2)
                {
                    tmp++;
                }
            }
            if (tmp == 3)
            {
                up = true;
                chek = true;
                return up;
            }
            else
            {
                up = false;
                return up;
            }
        }
        #endregion
        #region Проверка низа
        static bool Down(int iX, int iY, int[,] SMass, bool down, bool chek, int type)
        {
            int ix = iX;
            int iy = iY;
            int tmp = 0;
            for (int i = ix; i < ix + type;)
            {
                i++;
                if (i <= 9)
                {
                    if (SMass[i, iY] == 0)
                    {
                        tmp++;
                    }
                    if (iY - 1 >= 0)
                    {
                        if (SMass[i, iY - 1] != 0)
                        {
                            tmp = 0;
                            break;
                        }

                    }
                    if (iY + 1 <= 9)
                    {
                        if (SMass[i, iY + 1] != 0)
                        {
                            tmp = 0;
                            break;
                        }

                    }
                }
                if (i > 9 & tmp == type-1)
                {
                    tmp++;
                }
            }
            if (tmp == type)
            {
                down = true;
                chek = true;
                return down;
            }
            else
            {
                down = false;
                return down;
            }
        }
        #endregion        
    }
}
