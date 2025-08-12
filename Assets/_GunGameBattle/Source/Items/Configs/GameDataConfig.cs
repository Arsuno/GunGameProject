using UnityEngine;

namespace _GunGameBattle.Source.Items.Configs
{
    [CreateAssetMenu(fileName = "GameDataConfig", menuName = "Configs/GameDataConfig")]
    public class GameDataConfig : ScriptableObject
    {
        [Header("Other Configs")]
        public ItemsData Items;
    }
}