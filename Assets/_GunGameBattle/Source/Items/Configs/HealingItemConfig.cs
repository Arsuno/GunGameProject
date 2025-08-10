using UnityEngine;

namespace _GunGameBattle.Source.Items.Configs
{
    [CreateAssetMenu(menuName = "Configs/HealingItemConfig", fileName = "HealingItemConfig")]
    public class HealingItemConfig : ItemConfig
    {
        public int HealingAmount;
    }
}