using _GunGameBattle.Source.Items;

namespace _GunGameBattle.Source.Player.Attack.Strategies
{
    public interface IAttackStrategyFactory
    {
        IWeaponAttackStrategy Create(Item item);
    }
}