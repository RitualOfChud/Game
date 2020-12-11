using ConsoleApp3.Helper;
using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Player damien = new Player();

            DescribePlayer(damien);

            Play(damien);
        }

        public static void DescribePlayer(Player player)
        {
            StringBuilder description = new StringBuilder();
            description.AppendLine($"Welcome, {player.Name}!");
            description.AppendLine();
            description.AppendLine($"Stats & Items:");
            description.AppendLine($"\tHP: {player.HP}");
            description.AppendLine($"\tArmour: {player.Armour}");
            description.AppendLine($"\tWeapon Type: {player.Weapon.Type}");
            description.AppendLine($"\tWeapon Name: {player.Weapon.Name}");
            description.AppendLine($"\tAverage Weapon Damage: {(player.Weapon.MinDamage + player.Weapon.MaxDamage) / 2}");

            Console.WriteLine(description);
        }

        public static void Play(Player player)
        {
            int fightNum = 1;
            bool runAway = false;
            Enemy enemy = EnemyGenerator.GenerateEnemy();

            while(player.IsAlive && !runAway)
            {
                Console.WriteLine($"You met a {enemy.Name} (HP: {enemy.HitPoints}).");
                Console.WriteLine($"Your remaining HP: {player.HP}");
                Console.WriteLine();

                Console.Write("Fight? (y/n)\n>> ");
                
                if(Console.ReadLine().ToLower() == "n")
                {
                    runAway = true;
                    ConsoleHelper.WriteRedLine("\nYou ran away!");
                    break;
                }

                ConsoleHelper.WriteYellowBackgroundLine($"\nFight #{fightNum++}");

                if (Fight(player, enemy))
                {
                    enemy = EnemyGenerator.GenerateEnemy();
                }
            }
        }

        public static bool Fight(Player player, Enemy enemy)
        {
            while(enemy.IsAlive)
            {
                Console.WriteLine();
                if (!player.IsAlive)
                {
                    ConsoleHelper.WriteRedLine("\nYOU DIED!\n\n");
                    return false;
                }

                player.Attack(enemy);

                if (enemy.IsAlive)
                    enemy.Attack(player);
            }

            ConsoleHelper.WriteColouredLine($"\n{enemy.Name} defeated!\n", ConsoleColor.Yellow);

            return true;
        }

    }
}
