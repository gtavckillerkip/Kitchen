using Kitchen.ScriptableObjects.Tableware;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class Out : Counter
	{
		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();

			var item = carrier.GetItemSO();

			if (item is PlateSO plate && plate.IsEmpty == false)
			{
				plate = carrier.Drop() as PlateSO;

				plate.Clear();
				Destroy(plate);
			}
		}
	}
}
