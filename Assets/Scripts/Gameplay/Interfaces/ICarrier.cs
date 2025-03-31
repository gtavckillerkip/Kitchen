using Kitchen.ScriptableObjects.Common;
using System;

namespace Kitchen.Gameplay
{
	public interface ICarrier
	{
		event Action<ItemSO> ItemTaken;

		event Action<ItemSO> ItemDropped;

		bool TryTake(ItemSO carrible);

		ItemSO Drop();

		ItemSO GetItemSO();
	}
}
