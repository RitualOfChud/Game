using ConsoleApp3.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp3.Models.Enemy;

namespace ConsoleApp3.Models
{
    public static class EnemyGenerator
    {
        private static readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        private static Dictionary<EnemyType, int> _enemyChances = new Dictionary<EnemyType, int>()
        {
            {EnemyType.Monster, 20 },
            {EnemyType.Creature, 30 },
            {EnemyType.Human, 50 },
        };

        public static Enemy GenerateEnemy()
        {
            int rng = _random.Next(0, 100);

            if ((rng -= _enemyChances[EnemyType.Monster]) < 0)
                return EnemyRepo.GetEnemyOfType(EnemyType.Monster);

            else if ((rng -= _enemyChances[EnemyType.Creature]) < 0)
                return EnemyRepo.GetEnemyOfType(EnemyType.Creature);

            else
                return EnemyRepo.GetEnemyOfType(EnemyType.Human);
        }

    }
}
