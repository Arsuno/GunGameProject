using UnityEngine;

namespace _GunGameBattle.Source.Player.Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public int HealthValue;
        public float MovementSpeed;
    }
}