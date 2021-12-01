// Консольная игра "Угадай число"
// Комп загадал число в некотором диапазоне, например от 1 до 100. Далее он предлагает игроку угадать это число. Игрок вводит некоторое число и комп "отвечает":

// правильное ли это число или
// Загаданное число больше чем введенное
// загаданное число меньше чем введенное. После этого игрок делает следующую догадку. У Игрока есть некоторое количество попыток.
// Если игрок потратил все свои попытки, то игра заканчивается. Если игрок угадал число, но попытки еще остались, игра также заканчивается.

// Определить условия. (какой диапазон для загадывания чисел - мы его задаем, формируем рандомно или запрашиваем у пользователя?; определиться с количеством попыток - высчитать необходимое количество попыток, либо запросить у участника)
// Загадать число в указанном диапазоне.
// Начало игры - описываем правила.
// Запрашиваем у пользователя число. Пользователь вводит некоторое число (добавить проверку нештатных ситуаций). Определяем как оно соотносится с нашим загаданным и даем следующие инструкции игроку. Если пользователь не угадал, то у него сгорает 1 попытка.
// Игра продолжается пока есть попытки или пока пользователь не угадал число.

// int requestNumber() - метод запросит у игрока число, сделает все необходимые преобразования и вернет нам это число. 
// int createNumber(int leftBound, int rightBound) - загадает число в указанном диапазоне и вернет его нам. bool MakeMove(int SecretNumber, int CountOfAttempts) - метод, в котором запрограммирован 1 игровой ход, в результате метод возвращает либо true, либо false. true если пользователь угадал число и игру надо остановить, false, если пользователь не угадал.
// int SecretNumber = createNumber(1, 100); int PlayersNumber = requestNumber();
void DescribeRules()
{
    System.Console.WriteLine("Проверь свое везение:3");
    System.Threading.Thread.Sleep(1000);
    System.Console.WriteLine("Нужно угадать число в заданном диапазоне в зависимости от сложности - уровень выбирать тебе!");
}

int RequestLevel()
{
    System.Console.WriteLine("Введи 1 чтобы задать число от 1 до 10, на уровне 2 - числа от 1 до 100, 3 уровень - от 1 до 1000");
    System.Threading.Thread.Sleep(3000);
    System.Console.WriteLine("Какой уровень выберещь? Введи число от 1 до 3");
    int lives = Convert.ToInt32(System.Console.ReadLine());
    int rightBound = 0;
    if (lives == 1) rightBound = 10;
    if (lives == 2) rightBound = 100;
    if (lives == 3) rightBound = 1000;
    return rightBound;
}

int RequestLives()
{
    System.Console.WriteLine("Со скольки попыток угадаешь?");
    int lives = Convert.ToInt32(System.Console.ReadLine());
    return lives - 1;
}

int RequestNumber()
{
    System.Console.WriteLine("Попробуй угадать число");
    return Convert.ToInt32(System.Console.ReadLine());
}

//System.Console.WriteLine(playerNumber);

int СreateNumber(int rightBound)
{
    return new Random().Next(0, rightBound + 1);
}


bool IsItRealNumber(int secretNumber, int playerNumber)
{
    return secretNumber == playerNumber;
}

int PlayGame(bool arg, int count, int secretNumber, int playerNumber)
{
    int successCount = 0;
    while (count >= 0)
    {
        if (arg == true)
        {
            System.Threading.Thread.Sleep(3000);
            System.Console.WriteLine("Ответ верный, ты везунчик!");
            break;
        }
        if (arg == false)
        {
            if (secretNumber > playerNumber)
            {
                System.Console.WriteLine($"Загаданное число больше {playerNumber}");
                System.Threading.Thread.Sleep(1000);
                System.Console.WriteLine($"Осталось {count} попыток");

            }
            if (secretNumber < playerNumber)
            {
                System.Console.WriteLine($"Секретное число меньше {playerNumber}");
                System.Threading.Thread.Sleep(1000);
                System.Console.WriteLine($"Осталось {count} попыток");
            }
            if (secretNumber == playerNumber)
            {
                successCount++;//для кейса, когда число угадывается в последний ход
                System.Console.WriteLine("Ответ верный, победа!");
                break;
            }
            count--;
            playerNumber = RequestNumber();
            IsItRealNumber(secretNumber, playerNumber);
        }
    }
    if ((count == 0) && (successCount == 0)) System.Console.WriteLine("Попытки закончились, игра окончена:(");
    return count;
}

//программа
DescribeRules();
System.Threading.Thread.Sleep(2000);
int rightBound = RequestLevel();
System.Threading.Thread.Sleep(2000);
int count = RequestLives();
int secretNumber = СreateNumber(rightBound);
// System.Console.WriteLine($"комп загадал {secretNumber}");
int playerNumber = RequestNumber();
//int secretNumber = СreateNumber(1, 2);
PlayGame(IsItRealNumber(secretNumber, playerNumber), count, secretNumber, playerNumber);