using Kitchen.Gameplay.Items;
using System;

namespace Kitchen.Gameplay
{
	public interface ICarrier
	{
		event Action<Item> ItemChanged;

		bool TryTake(Item carrible);

		Item Drop();

		Item GetItem();
	}
}
