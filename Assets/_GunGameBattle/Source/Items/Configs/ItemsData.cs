using System.Collections.Generic;
using UnityEngine;

namespace _GunGameBattle.Source.Items.Configs
{
    [CreateAssetMenu(fileName = "New ItemsData", menuName = "ItemsData")]
    public class ItemsData : ScriptableObject
    {
        public List<ItemConfig> ItemsConfigs;
    }
}