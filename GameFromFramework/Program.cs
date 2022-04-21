using System;
using System.Security.Cryptography;
using GameFrameWork.Creatures.Classes;
using GameFrameWork.Creatures.General;
using GameFrameWork.GameLoop.Combat;
using GameFrameWork.Items;
using GameFrameWork.World;

namespace GameFromFramework
{
    class Program
    {
        public static WeaponsManager wman = new WeaponsManager();
        public static ConsumableManager cman = new ConsumableManager();
        public static World WorldClass = new World();
        public static CharacterAndPosition Warrior1Pos;
        public static CharacterAndPosition Warrior2Pos;
        public static CharacterAndPosition Mage1Pos;
        public static CharacterAndPosition MyrmidonPos;
        static void Main(string[] args)
        {
            Warrior1Pos = new CharacterAndPosition(new Warrior(), 1, 1, false);
            Warrior2Pos = new CharacterAndPosition(new Warrior(), 13, 0, false);
            Mage1Pos = new CharacterAndPosition(new Mage(), 7, 7, true);
            MyrmidonPos = new CharacterAndPosition(new Swordmaster(), 19, 19, true);


            Warrior1Pos.GA.AddInventoryItem(wman.Find(0));
            Warrior2Pos.GA.AddInventoryItem(wman.Find(0));
            Mage1Pos.GA.AddInventoryItem(wman.Find(3));
            Mage1Pos.GA.AddInventoryItem(cman.Find(0));


            CustomWeaponExperiment();

            TextCombatExperiment();
            


            //WorldMapExperiment();

        }
        static void CustomWeaponExperiment() 
        {
            SwordCreator SCreate = new SwordCreator();
            wman.Add(SCreate.CreateWeapon(name: "Excalibur", description: "A holy sword.", damage: 55, durability: 55, accuracy: 150, critical: 20));
            MyrmidonPos.GA.AddInventoryItem(wman.Find(6));
            Console.WriteLine(MyrmidonPos.GA.EquippedWeapon);
        }
        static void WorldMapExperiment() 
        {
            WorldClass.MaxX = 30;
            WorldClass.MaxY = 20;

            WorldClass.AddCharacter(Warrior1Pos);
            WorldClass.AddCharacter(Warrior2Pos);
            WorldClass.AddCharacter(Mage1Pos);
            WorldClass.AddCharacter(MyrmidonPos);

            GameRunner();
        }
        static void TextCombatExperiment()
        {
            MyrmidonPos.GA.AddInventoryItem(wman.Find(5));

            Console.WriteLine("Swordmaster's equipped weapon durability at start of combat " + MyrmidonPos.GA.EquippedWeapon.Durability);

            CombatManager.DoCombat(MyrmidonPos.GA, Mage1Pos.GA, 1);

            Console.WriteLine("Swordmaster's equipped weapon durability at end of first combat " + MyrmidonPos.GA.EquippedWeapon.Durability);
            
            //Myrmidon.EquippedWeapon.Durability = 0;
            
            CombatManager.DoCombat(Warrior1Pos.GA, MyrmidonPos.GA, 1);

            Console.WriteLine("Swordmaster's equipped weapon durability at end of second combat " + MyrmidonPos.GA.EquippedWeapon.Durability);
        }
        public static void GameRunner() 
        {
            WorldClass.PrintGameworld();

            WorldClass.MoveCursor(Console.ReadKey(true).KeyChar);

            GameRunner();
        }
    }
}
