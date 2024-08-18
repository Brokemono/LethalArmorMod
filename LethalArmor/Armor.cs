using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalArmor
{
    public class Armor
    {
        public int Durability { get; private set; }
        public bool IsEquipped { get; private set; }

        public Armor(int initialDurability)
        {
            Durability = initialDurability;
            IsEquipped = true; // Assuming armor is equipped when created
        }

        public void TakeDamage()
        {
            if (Durability > 0)
            {
                Durability--;
            }
            if (Durability <= 0)
            {
                BreakArmor();
            }
        }

        private void BreakArmor()
        {
            IsEquipped = false;
            // Additional logic for when the armor breaks
        }
    }
}
