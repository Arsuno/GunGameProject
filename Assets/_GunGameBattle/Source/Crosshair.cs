using UnityEngine;

namespace _GunGameBattle.Source
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
            _rectTransform.position = Input.mousePosition;
        }
    }
}