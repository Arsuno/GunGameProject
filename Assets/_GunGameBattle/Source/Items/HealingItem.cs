using _GunGameBattle.Source.Items.Configs;

namespace _GunGameBattle.Source.Items
{
    public class HealingItem : Item
    {
        public int HealingAmount { get; private set; }

        protected override void InitializeSpecific(ItemConfig config)
        {
            HealingItemConfig healingItemConfig = (HealingItemConfig)config;
            
            HealingAmount = healingItemConfig.HealingAmount;
        }
    }
}