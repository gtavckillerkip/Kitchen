using Kitchen.Gameplay.Items;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class SimpleCounter : Counter
	{
		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();

			switch (CarriedItem)
			{
				case null:
					CarriedItem = carrier.Drop();
					break;

				case Plate plate:
					if (carrier.GetItem() == null)
					{
						carrier.TryTake(CarriedItem);
						CarriedItem = null;
						break;
					}

					var item = carrier.GetItem();
					if (plate.TryAddIngredient(item))
					{
						carrier.Drop();
					}
					break;

				case not Plate:
					if (carrier.TryTake(CarriedItem))
					{
						CarriedItem = null;
					}
					break;
			}
		}
	}
}
