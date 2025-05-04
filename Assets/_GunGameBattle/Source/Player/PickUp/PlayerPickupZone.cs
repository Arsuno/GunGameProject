using System.Collections.Generic;
using _GunGameBattle.Source.Items;
using UnityEngine;

namespace _GunGameBattle.Source.Player.PickUp
{
    public class PlayerPickupZone : MonoBehaviour
    {
        public readonly Dictionary<Collider2D, IPickUpAble> Items = new();

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IPickUpAble item))
                Items[col] = item;
        }

        public void OnTriggerExit2D(Collider2D col)
        {
            if (Items.ContainsKey(col))
                Items.Remove(col);
        }

        public IPickUpAble GetNearestItem()
        {
            Collider2D nearest = null;
            var shortestDistance = float.MaxValue;

            foreach (var col in Items.Keys)
            {
                var distance = Vector2.Distance(transform.position, col.transform.position);

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearest = col;
                }
            }

            return Items[nearest];
        }
    }
}