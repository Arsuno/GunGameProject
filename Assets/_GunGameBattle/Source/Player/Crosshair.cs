using UnityEngine;

namespace _GunGameBattle.Source.Player
{
    public class Crosshair : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        private void Awake()
        {
            Cursor.visible = false;
        }

        private void Update()
        {
            _rectTransform.position = UnityEngine.Input.mousePosition;
        }
    }
}