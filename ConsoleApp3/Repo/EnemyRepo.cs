using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp3.Models.Enemy;

namespace ConsoleApp3.Repo
{
    public static class EnemyRepo
    {
        public static Enemy GetEnemyOfType(EnemyType type)
        {
            List<Enemy> EnemyList = new List<Enemy>()
            {
                new Enemy("Thief", EnemyType.Human, 20, 0, 2, 5),
                new Enemy("Wolf", EnemyType.Creature, 25, 0, 1, 3),
                new Enemy("Orc", EnemyType.Monster, 40, 5, 0, 10)

            };

            return EnemyList.First(x => x.Type == type);
        }

    }
}
