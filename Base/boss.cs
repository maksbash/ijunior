//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        const int IdKuridash = 1;
//        const int IdFixtra = 2;
//        const int IdMultiupа = 3;
//        const int IdHideryaki = 4;

//        Random random = new Random();

//        int lifeLowerBound = 800;
//        int lifeUpperBound = 1200;
//        int bossDamageLowerBound = 80;
//        int bossDamageUpperBound = 150;

//        float bossLife = random.Next(lifeLowerBound, lifeUpperBound + 1);
//        float userLife = random.Next(lifeLowerBound, lifeLowerBound + 1);

//        int spellKuridashDamage = 100;
//        string spellKuridashName = "Куридаш";
//        string spellKuridashDescription = $"Заклинание {spellKuridashName} " +
//            $"напускает на врага курицу, которая отнимает " +
//            $"{spellKuridashDamage} жизни у врага";

//        int spellFixtraDamage = 150;
//        string spellFixtrahName = "Фикстра";
//        string spellFixtrahDescription = $"Заклинание {spellFixtrahName} " +
//            $"грохает врага фикстрой по макушке " +
//            $"и отнимает {spellFixtraDamage} жизни у варага";

//        float spellMultiupаUpperDamage = 1.5f;
//        int spellMultiupаDamage = 30;
//        string spellMultiupаName = "Мультиапа";
//        string spellMultiupаDescription = $"Заклинание {spellMultiupаName} увеличивает урон " +
//            $"в {spellMultiupаUpperDamage} раз если вызвано после " +
//            $"{spellKuridashName} или {spellFixtrahName}. " +
//            $"Или отнимает {spellMultiupаDamage} жизни";

//        int spellHideryakiDamage = 0;
//        string spellHideryakiName = "Хидеряки";
//        string spellHideryakiDescription = $"Заклинание {spellHideryakiName} " +
//            $"прячет игрока на дереве, защищает от урона босса " +
//            $"и восстанавливает предыдущий урон";

//        int lowerIdSpell = 1;
//        int upperIdSpell = 4;

//        int currentSpell = 0;
//        int previewSpell = 0;

//        float currentUserDamage = 0;
//        float previewUserDamage = 0;
//        float userRecover;

//        int currentBossDamage = 0;
//        int previewBossDamage = 0;

//        Console.WriteLine("Здоровье босса перед началом поединка - " + bossLife);
//        Console.WriteLine("Здоровье пользователя перед началом поединка - " + userLife);

//        while (bossLife > 0 && userLife > 0)
//        {
//            previewSpell = currentSpell;
//            previewUserDamage = currentUserDamage;
//            previewBossDamage = currentBossDamage;
//            userRecover = 0;
//            currentBossDamage = random.Next(bossDamageLowerBound, bossDamageUpperBound + 1);
//            currentSpell = random.Next(lowerIdSpell, upperIdSpell + 1);

//            string currentDescription = "";

//            switch (currentSpell)
//            {
//                case IdKuridash:
//                    currentDescription = spellKuridashDescription;
//                    currentUserDamage = spellKuridashDamage;
//                    break;

//                case IdFixtra:
//                    currentDescription = spellFixtrahDescription;
//                    currentUserDamage = spellFixtraDamage;
//                    break;

//                case IdMultiupа:
//                    currentDescription = spellMultiupаDescription;

//                    if (previewSpell == IdKuridash || previewSpell == IdFixtra)
//                    {
//                        currentUserDamage = previewUserDamage * spellMultiupаUpperDamage;
//                    }
//                    else
//                    {
//                        currentUserDamage = spellMultiupаDamage;
//                    }

//                    break;

//                case IdHideryaki:
//                    currentDescription = spellHideryakiDescription;
//                    currentUserDamage = spellHideryakiDamage;
//                    userRecover = previewBossDamage;
//                    currentBossDamage -= currentBossDamage;
//                    break;
//            }

//            bossLife -= currentUserDamage;
//            userLife += userRecover;
//            userLife -= currentBossDamage;

//            Console.Write($"Итог заклинания {currentDescription}.\n\t");
//            Console.Write($"Босс потерял {currentUserDamage} жизни\n\t");

//            if (userRecover > 0)
//            {
//                Console.Write($"Пользователь восстановил {userRecover} жизни\n\t");
//            }

//            if (currentBossDamage > 0)
//            {
//                Console.Write($"Пользователь потерял {userRecover} жизни\n\t");
//            }

//            Console.Write($"Остаток жизни пользователя - {userLife}\n\t");
//            Console.Write($"Остаток жизни босса - {bossLife}\n\t");
//        }

//        string winDescription;

//        if (userLife < 0 && bossLife < 0)
//        {
//            winDescription = "Ничья!";
//        }
//        else if (userLife < 0)
//        {
//            winDescription = "Победил БОСС!";
//        }
//        else
//        {
//            winDescription = "Победил пользователь!";
//        }

//        Console.WriteLine(winDescription);

//        Console.ReadKey();
//    }
//}