using Kitchen.Gameplay.Items;
using Kitchen.ScriptableObjects.Common;
using Kitchen.ScriptableObjects.Ingredients;
using Kitchen.ScriptableObjects.Tableware;
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
				if (_carriedItem.ItemSO is PlateSO)
				{
					result = (_carriedItem.ItemSO as PlateSO).TryAddIngredient(item.ItemSO as IngredientSO);
				}

				if (_carriedItem.ItemSO is IngredientSO && item.ItemSO is PlateSO)
				{
					result = (item.ItemSO as PlateSO).TryAddIngredient(_carriedItem.ItemSO as IngredientSO);

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

		public ItemSO GetItemSO() => _carriedItem.ItemSO;
	}
}
