using Kitchen.ScriptableObjects.Common;

namespace Kitchen.Gameplay
{
	public interface ICarrier
	{
		bool TryTake(ItemSO carrible);

		ItemSO Drop();

		ItemSO GetItemSO();
	}
}
