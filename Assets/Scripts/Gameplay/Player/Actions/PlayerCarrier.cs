using Kitchen.ScriptableObjects.Common;
using Kitchen.ScriptableObjects.Ingredients;
using Kitchen.ScriptableObjects.Tableware;
using System;
using UnityEngine;

namespace Kitchen.Gameplay.Player
{
	public class PlayerCarrier : MonoBehaviour, ICarrier
	{
		private ItemSO _carriedItem;

		public event Action<ItemSO> ItemTaken;
		public event Action<ItemSO> ItemDropped;

		public bool TryTake(ItemSO item)
		{
			bool result = false;

			if (_carriedItem == null)
			{
				_carriedItem = item;
				result = true;
				ItemTaken?.Invoke(_carriedItem);
			}
			else
			{
				if (_carriedItem is PlateSO)
				{
					result = (_carriedItem as PlateSO).TryAddIngredient(item as IngredientSO);
				}

				if (_carriedItem is IngredientSO && item is PlateSO)
				{
					result = (item as PlateSO).TryAddIngredient(_carriedItem as IngredientSO);

					if (result)
					{
						_carriedItem = item as PlateSO;
						ItemTaken?.Invoke(_carriedItem);
					}
				}
			}

			return result;
		}

		public ItemSO Drop()
		{
			var carriedItem = _carriedItem;

			_carriedItem = null;

			ItemDropped?.Invoke(carriedItem);

			return carriedItem;
		}

		public ItemSO GetItemSO() => _carriedItem;
	}
}
