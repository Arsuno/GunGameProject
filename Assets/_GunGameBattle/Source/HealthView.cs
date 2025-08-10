using UnityEngine;

namespace _GunGameBattle.Source
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private RectTransform _healthBarFillObject;

        private void OnEnable() => 
            _health.ValueChanged += OnHealthValueChanged;

        private void OnDisable() => 
            _health.ValueChanged -= OnHealthValueChanged;

        private void OnHealthValueChanged()
        {
            float scaleFactor = Mathf.Clamp01(_health.CurrentValue / _health.MaxValue);
    
            _healthBarFillObject.localScale = new Vector3(
                scaleFactor,
                _healthBarFillObject.localScale.y,
                _healthBarFillObject.localScale.z
            );
        }
    }
}