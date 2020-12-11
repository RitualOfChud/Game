using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models.SubClasses
{
    public class Sword : Weapon
    {

        public Sword(string name, double min, double max) : base(name, WeaponType.Sharp, min, max) { }

    }
}
