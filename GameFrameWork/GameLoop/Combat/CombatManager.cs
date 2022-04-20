using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Creatures.General;

namespace GameFrameWork.GameLoop.Combat
{
    public static class CombatManager
    {
        private static Random rnd = new Random();

        public static List<string> CombatLog = new List<string>();
        /// <summary>
        /// Initiates combat between two characters, where the first character is the engaging party.
        /// </summary>
        /// <param name="attacker">A class that is engaging the combat.</param>
        /// <param name="defender">A class that is defending against the attack.</param>
        /// <param name="range">Distance between both parties.</param>
        public static void DoCombat(GeneralAttributes attacker, GeneralAttributes defender, int range)
        {
            Tracing.TraceRunner();
            //CombatLog = new List<string>();
            DamageRound(attacker, defender, range);
            DamageRound(defender, attacker, range);
            //if either fighter has a speed stat of 5 or more over the opponent, they get another shot!
            int speedbattle = attacker.Speed - defender.Speed;
            if (speedbattle >= 5)
            {
                DamageRound(attacker, defender, range);
            }
            else if (speedbattle <= -5)
            {
                DamageRound(defender, attacker, range);
            }
        }
        public static int AttackerDamage(GeneralAttributes attacker, GeneralAttributes defender, int weapontriangle)
        {
            int atkdmggive;
                //is the damage physical == 1 or magical == 2? important for checking magic vs strength, as being buff while holding a book shouldn't alter the effect of your spell.
                if (attacker.EquippedWeapon.DamageType == 1)
                {
                    atkdmggive = attacker.EquippedWeapon.Damage + attacker.Strength;
                }
                else if (attacker.EquippedWeapon.DamageType == 2)
                {
                    atkdmggive = attacker.EquippedWeapon.Damage + attacker.Magic;
                }
                else
                {
                    atkdmggive = attacker.EquippedWeapon.Damage;
                }
                atkdmggive += weapontriangle;

                int finaldamage;
                //defence for defending against physical attacks, resistance for defending against magical attacks.
                if (attacker.EquippedWeapon.DamageType == 1)
                {
                    finaldamage = atkdmggive - defender.Defence;
                }
                else if (attacker.EquippedWeapon.DamageType == 2)
                {
                    finaldamage = atkdmggive - defender.Resistance;
                }
                else
                {
                    finaldamage = atkdmggive;
                }

            return finaldamage;
        }
        public static int AttackerCrit(GeneralAttributes attacker, GeneralAttributes defender)
        {
            int critRate = (attacker.Skill / 2 + attacker.EquippedWeapon.Critical) - defender.Luck;
            return critRate;
        }
        public static int AttackerHit(GeneralAttributes attacker, GeneralAttributes defender, int weapontriangle)
        {
            //calculate the chance of the attack hitting.
            int hitrate = Convert.ToInt32((attacker.Skill * 2) + (attacker.Luck * 0.5) + attacker.EquippedWeapon.Accuracy + weapontriangle);
            //calculate the chance of the opponent dodging.
            int dodgerate = Convert.ToInt32((defender.Speed * 2) + defender.Luck);
            int finalrate = hitrate - dodgerate;
            return finalrate;
        }

        private static void DamageRound(GeneralAttributes attacker, GeneralAttributes defender, int range)
        {
            //combat only occurs when these:
            //defender and attacker have more health than 0.
            //attacker has a weapon equipped.
            //attacker's equipped weapon's range corresponds to the range between attacker and defender.
            //if attacker's weapon has more than 0 durability.
            if (attacker.EquippedWeapon != null && attacker.CurrentHealth > 0 && defender.CurrentHealth > 0 &&
                attacker.EquippedWeapon.RangeMin <= range && range <= attacker.EquippedWeapon.RangeMax &&
                attacker.EquippedWeapon.Durability > 0)
            {
                //weapon triangle adds 1 damage and 15 hit if your weapon is effective against the opponents, but subtracts the same numbers if your weapon is ineffective.
                List<int> weapontriangle;
                if (defender.EquippedWeapon == null)
                {
                    weapontriangle = new List<int>(){0,0};
                }
                else
                {
                    weapontriangle = attacker.EquippedWeapon.WeaponTriangle(defender.EquippedWeapon.WeaponType);
                }
                int finalrate = AttackerHit(attacker, defender, weapontriangle[1]);
                int rn1 = rnd.Next(0, 100);
                int rn2 = rnd.Next(0, 100);
                //with 2 rn to stabilize rng a little.
                int rnfinal = (rn1 + rn2) / 2;
                //we check whether the attack hits or not
                if (rnfinal <= finalrate)
                {
                    Tracing.TraceOutput($"{attacker.Name} hits {defender.Name}!", TraceEventType.Information);
                    //CombatLog.Add($"{attacker.Name} hits {defender.Name}!");
                    int finaldamage = AttackerDamage(attacker, defender, weapontriangle[0]);
                    //Critical hit calculations:
                    int critRate = AttackerCrit(attacker, defender);
                    //Yes, there is indeed just 1 rn for critical rate, but 2 for hit rate. Blame early 2000s game developers.
                    int crtrn = rnd.Next(0, 100);
                    if (crtrn <= critRate)
                    {
                        finaldamage *= 3;
                        Tracing.TraceOutput("It's a critical hit!", TraceEventType.Verbose);
                        //CombatLog.Add("It's a critical hit!");
                    }
                    //take health away from defender.
                    defender.CurrentHealth -= finaldamage;
                    //FINALLY lose 1 durability for a successful hit.
                    attacker.EquippedWeapon.Durability -= 1;
                    Tracing.TraceOutput($"{attacker.Name}'s attack hits {defender.Name} for {finaldamage} points of damage!", TraceEventType.Verbose);
                    //CombatLog.Add($"{attacker.Name}'s attack hits {defender.Name} for {finaldamage} points of damage!");
                    if (defender.CurrentHealth > 0)
                    {
                        Tracing.TraceOutput($"{defender.Name} is left with {defender.CurrentHealth} hitpoints!", TraceEventType.Verbose);
                    }
                    else
                    {
                        Tracing.TraceOutput($"{defender.Name} is out cold!", TraceEventType.Verbose);
                        //CombatLog.Add($"{defender.Name} is out cold!");
                    }
                    
                    return;
                }
                //if the attack doesn't hit, nothing happens obviously.
                Tracing.TraceOutput($"{defender.Name} dodges the attack!", TraceEventType.Verbose);
                //CombatLog.Add($"{defender.Name} dodges the attack!");
            }
        }
    }
}
