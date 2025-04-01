using Kitchen.Gameplay.Items;
using System;
using UnityEngine;

namespace Kitchen.Gameplay.Player
{
	public class PlayerCarrier : MonoBehaviour, ICarrier
	{
		private Item _carriedItem;

		public event Action<Item> ItemChanged;

		public bool TryTake(Item item)
		{
			bool result = false;

			if (_carriedItem == null)
			{
				_carriedItem = item;
				result = true;
				ItemChanged?.Invoke(_carriedItem);
			}
			else
			{
				if (_carriedItem is Plate)
				{
					result = (_carriedItem as Plate).TryAddIngredient(item);
				}

				if (_carriedItem is not Plate && item is Plate)
				{
					result = (item as Plate).TryAddIngredient(_carriedItem);

					if (result)
					{
						_carriedItem = item;
						ItemChanged?.Invoke(_carriedItem);
					}
				}
			}

			return result;
		}

		public Item Drop()
		{
			var carriedItem = _carriedItem;

			_carriedItem = null;

			ItemChanged?.Invoke(_carriedItem);

			return carriedItem;
		}

		public Item GetItem() => _carriedItem;
	}
}
