using Kitchen.Gameplay.Items;
using Kitchen.ScriptableObjects.Tableware;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class PlateStand : Counter
	{
		[SerializeField] private PlateSO _plate;

		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();

			if (carrier.GetItem() == null)
			{
				carrier.TryTake(Instantiate(_plate.ItemPrefab).GetComponent<Item>());
			}
		}
	}
}
