using UnityEngine;

namespace _GunGameBattle.Source.Items.Configs
{
    [CreateAssetMenu(fileName = "GameDataConfig", menuName = "Configs/GameDataConfig")]
    public class GameDataConfig : ScriptableObject
    {
        [Header("Player Properties")]
        public int InventoryCapacity;
        
        [Header("Other Configs")]
        public ItemsData Items;
    }
}