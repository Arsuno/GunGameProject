using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Player.Inventory;
using _GunGameBattle.Source.TEST;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Player.Shooting
{
    public class PlayerAttackController : MonoBehaviour
    {
        private PlayerEquipment _playerEquipment;
        private PlayerInputControls _playerInputControls;
        
        private bool _canShoot;
        private Weapon _currentWeapon;
        private ObjectPool<Bullet> _bulletPool;

        [Inject]
        private void Initialize(PlayerEquipment playerEquipment, PlayerInputControls playerInputControls)
        {
            _playerEquipment = playerEquipment;
            _playerInputControls = playerInputControls;
            
            OnInitialized();
        }

        private void Update()
        {
            if (!_canShoot)
                return;

            if (_playerInputControls.GamePlay.Shoot.WasPressedThisFrame())
            {
                if (_currentWeapon.TryShoot())
                {
                    var targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                    
                    var bullet = _bulletPool.Get();
                    bullet.gameObject.transform.position = _currentWeapon.FirePoint.position;
                    
                    var direction = (targetPos - _currentWeapon.FirePoint.position).normalized;
                    
                    bullet.HitTarget += OnBulletHitTarget;
                    bullet.Initialize(_currentWeapon.Damage, direction, _currentWeapon.BulletSpeed);
                }
            }
            
            if (_playerInputControls.GamePlay.Reload.WasPressedThisFrame())
                _currentWeapon.Reload();
        }

        private void OnDestroy() => 
            _playerEquipment.ItemEquipped -= OnItemEquipped;

        private void OnInitialized() => 
            _playerEquipment.ItemEquipped += OnItemEquipped;

        private void OnBulletHitTarget(Bullet bullet) => 
            _bulletPool.Release(bullet);

        private void OnItemEquipped(Item item)
        {   
            if (item is Weapon)
            {
                ClearPreviousPool();
                
                _currentWeapon = (Weapon)item;
                _canShoot = true;

                _bulletPool = new ObjectPool<Bullet>(_currentWeapon.AmmoCapacity * 20, _currentWeapon.BulletPrefab); //TODO Улучшить
            }
        }

        private void ClearPreviousPool()
        {
            if (_bulletPool != null && _bulletPool.Objects.Count > 0)
            {
                foreach (var bullet in _bulletPool.Objects)
                    Destroy(bullet);    
            }
        }
    }
}