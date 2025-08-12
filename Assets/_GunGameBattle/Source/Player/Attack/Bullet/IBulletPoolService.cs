using _GunGameBattle.Source.Optimization;

namespace _GunGameBattle.Source.Player.Attack.Bullet
{
    public interface IBulletPoolService
    {
        ObjectPool<Bullet> GetPool(Bullet prefab, int capacity);
        void ClearAll(); // по желанию
    }
}