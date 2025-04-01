using Kitchen.ScriptableObjects.Tableware;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class Trash : Counter
	{
		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();
			
			var drop = carrier.Drop();

			if (drop.ItemSO is PlateSO plate && plate.IsEmpty == false)
			{
				plate.Clear();
			}
			else
			{
				Destroy(drop);
			}
		}
	}
}
