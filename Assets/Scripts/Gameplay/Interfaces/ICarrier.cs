using Kitchen.Gameplay.Items;
using Kitchen.ScriptableObjects.Common;
using System;

namespace Kitchen.Gameplay
{
	public interface ICarrier
	{
		event Action<Item> ItemChanged;

		bool TryTake(Item carrible);

		Item Drop();

		ItemSO GetItemSO();
	}
}
