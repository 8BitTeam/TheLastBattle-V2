using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ScriptsCommon
{
    public class Mana
    {
        public static int MANA_MAX = 100;

        private float manaAmount = 0;
        private float manaRegenAmount = 10;

        public Mana(float manaRegenAmount)
        {
            this.manaRegenAmount = manaRegenAmount;
        }

        public Mana()
        {

        }

        public float GetMana()
        {
            return manaAmount;
        }

        public void Update()
        {
            if (manaAmount < MANA_MAX)
                manaAmount += manaRegenAmount * Time.deltaTime;
        }

        public bool TrySpendMana(int amount)
        {
            if (manaAmount >= amount)
            {
                manaAmount -= amount;
                return true;
            }
            return false;
        }

        public float GetManaNormalized()
        {
            return manaAmount / MANA_MAX;
        }

        public void GainMana(float? amount)
        {
            if (amount == null)
            {
                amount = manaRegenAmount;
            }
            if (manaAmount < MANA_MAX)
            {
                manaAmount += (float) amount;
                if(manaAmount > MANA_MAX)
                {
                    manaAmount = MANA_MAX;
                }
            }
        }
    }
}
