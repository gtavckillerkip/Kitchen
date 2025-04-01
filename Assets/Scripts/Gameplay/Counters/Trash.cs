using Kitchen.Gameplay.Items;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class Trash : Counter
	{
		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();
			
			var item = carrier.GetItem();
			if (item is Plate plate && plate.IsEmpty == false)
			{
				plate.Clear();
			}
			else if (item != null)
			{
				Destroy(item.gameObject);
			}
		}
	}
}
