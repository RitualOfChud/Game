using ConsoleApp3.Helper;
using ConsoleApp3.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class Player
    {

        public string Name { get; set; } = "Damien";
        public Weapon Weapon { get; set; } = WeaponRepo.GetRandomSword();
        public double HP { get; set; } = 100;
        public double Armour { get; set; } = 1;
        public bool IsAlive { get; set; } = true;

        public Player() {}

        public void Attack(Enemy enemy)
            => enemy.TakeDamage(Weapon.CalculateDamage(enemy.Type));

        public void TakeDamage(double damage)
        {
            double damageDone = Math.Round(Math.Max(0, damage - Armour), 2);

            HP -= damageDone;

            IsAlive = HP > 0;

            ConsoleHelper.WriteBlueLine($"{Name} took {damageDone} damage (HP: {Math.Round(Math.Max(0, HP), 2)})");
        }
    }

}
