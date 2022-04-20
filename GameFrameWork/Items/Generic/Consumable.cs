namespace GameFrameWork.Items.Templates
{
    public class Consumable : GenericItem
    {
        private int _healingAmount;

        public Consumable(string name, string description, int healing, int durability)
        {
            Name = name;
            Description = description;
            _healingAmount = healing;
            MaxDurability = durability;
            Durability = durability;
        }

        public int Consume()
        {
            Durability -= 1;
            return _healingAmount;
        }
    }
}
