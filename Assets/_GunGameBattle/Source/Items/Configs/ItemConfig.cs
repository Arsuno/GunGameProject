using UnityEngine;

namespace _GunGameBattle.Source.Items.Configs
{
    [CreateAssetMenu(fileName = "New ItemConfig", menuName = "ItemConfig")]
    public class ItemConfig : ScriptableObject
    {
        public int Id;
        public Sprite Sprite;
    }
}