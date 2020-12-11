using ConsoleApp3.Models.SubClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Repo
{
    public static class WeaponRepo
    {
        private static readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        private static List<Sword> SwordList = new List<Sword>()
        {
            new Sword("Simple Sword", 3, 4),
            new Sword("Long Sword", 7, 8),
            new Sword("Sabre", 4, 9)
        };

        public static Sword GetRandomSword() => SwordList[_random.Next(0, SwordList.Count - 1)];

    }
}
