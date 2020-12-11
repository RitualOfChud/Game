using ConsoleApp3.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public partial class Enemy
    {

        public string Name { get; set; }
        public EnemyType Type { get; set; }
        public double HitPoints { get; set; }
        public double ManaPoints { get; set; }
        public double Armour { get; set; }
        public double Damage { get; set; }
        public bool IsAlive { get; set; } = true;

        public Enemy(string name, EnemyType type, double hp, double mp, double armour, double damage)
        {
            Name = name;
            Type = type;
            HitPoints = hp;
            ManaPoints = mp;
            Armour = armour;
            Damage = damage;
        }

        public void Attack(Player player)
        {
            player.TakeDamage(Damage);
        }

        public void TakeDamage(double damage)
        {
            double damageDone = Math.Round(Math.Max(1, damage - Armour), 2);
            
            HitPoints -= damageDone;

            IsAlive = HitPoints > 0;

            ConsoleHelper.WriteGreenLine($"{Name} took {damageDone} damage (HP: {Math.Round(Math.Max(0, HitPoints), 2)})");
        }
    }

}
