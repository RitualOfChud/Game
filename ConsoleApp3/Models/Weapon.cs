using ConsoleApp3.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp3.Models.Enemy;

namespace ConsoleApp3.Models
{
    public abstract class Weapon
    {
        readonly Random random = new Random(Guid.NewGuid().GetHashCode());

        public enum WeaponType
        {
            Blunt,
            Sharp,
            Magical
        }

        public string Name { get; set; }
        public WeaponType Type { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }

        private readonly Dictionary<WeaponType, EnemyType> _advantageList = new Dictionary<WeaponType, EnemyType>()
        {
            { WeaponType.Blunt, EnemyType.Creature },
            { WeaponType.Sharp, EnemyType.Human },
            { WeaponType.Magical, EnemyType.Monster }
        };

        protected Weapon(string name, WeaponType type, double minDamage, double maxDamage)
        {
            Name = name;
            Type = type;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public double CalculateDamage(EnemyType enemyType)
        {
            double damageDone = random.NextDouble() * (MaxDamage - MinDamage) + MinDamage;

            if (_advantageList[Type] == enemyType)
            {
                ConsoleHelper.WriteColouredLine("Advantage Strike!", ConsoleColor.Cyan);
                damageDone += damageDone * 0.5;
            }

            return damageDone;
        }

        
    }
}
