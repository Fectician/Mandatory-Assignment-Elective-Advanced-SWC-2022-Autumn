using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Items.Templates;
using GameFrameWork.World.WorldObjects;
using Microsoft.VisualBasic;

namespace GameFrameWork.Creatures.General
{
    /// <summary>
    /// GeneralAttributes, the abstract class, is the standard inheritable class that defines logic for the different classes.
    /// Essentially, all the playable "characters" inherit all the functionality from this class.
    /// </summary>
    public abstract class GeneralAttributes
    {
        public string Name;
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Movement;
        public int Strength;
        public int Speed;
        public int Skill;
        public int Magic;
        public int Luck;
        public int Defence;
        public int Resistance;

        public Weapon EquippedWeapon;
        public List<GenericItem> InventoryList = new List<GenericItem>();

        public GeneralAttributes(int health = 1, int movement = 1, int strength = 0, int speed = 0, int skill = 0, int magic = 0, int luck = 0, int defence = 0, int resistance = 0, string name = "DUMMY")
        {
            MaxHealth = health;
            CurrentHealth = health;
            Movement = movement;
            Strength = strength;
            Speed = speed;
            Skill = skill;
            Magic = magic;
            Luck = luck;
            Defence = defence;
            Resistance = resistance;
            Name = name;
        }

        public void AddInventoryItem(GenericItem item)
        {
            if (InventoryList.Count >= 5) return;
            GenericItem newItem = item.ShallowCopy();
            InventoryList.Add(newItem);
            if (EquippedWeapon != null) return;
            if (newItem.GetType().IsSubclassOf(typeof(Weapon)))
            {
                EquippedWeapon = (Weapon)newItem;
            }
        }

        public void LootTile(TreasureChest obj)
        {
            if (obj.Lootable == true) AddInventoryItem(obj.Open());
        }

        public object DiscardInventoryItem(GenericItem item)
        {
            InventoryList.Remove(item);
            return item;
        }

        public void Consume(Consumable consumable)
        {
            if (CurrentHealth >= MaxHealth) return;
            CurrentHealth += consumable.Consume();
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }
        public override string ToString()
        {
            return $"Name {Name}\n Health {CurrentHealth}/{MaxHealth}\n Strength: {Strength} Skill: {Skill}\n Speed: {Speed} Luck: {Luck}\n Defence: {Defence} Resistance: {Resistance}\n Movement: {Movement}";
        }
    }
}
