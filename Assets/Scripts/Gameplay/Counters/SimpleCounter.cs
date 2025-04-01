using Kitchen.ScriptableObjects.Ingredients;
using Kitchen.ScriptableObjects.Tableware;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class SimpleCounter : Counter
	{
		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();

			if (CarriedItem == null)
			{
				CarriedItem = carrier.Drop();
			}
			else
			{
				switch (CarriedItem.ItemSO)
				{
					case PlateSO plate:
						if (carrier.GetItemSO() == null)
						{
							carrier.TryTake(CarriedItem);
							CarriedItem = null;
							break;
						}

						var itemSO = carrier.GetItemSO();
						if (plate.TryAddIngredient(itemSO as IngredientSO) == false)
						{
							carrier.Drop();
						}
						break;

					case IngredientSO:
						if (carrier.TryTake(CarriedItem))
						{
							CarriedItem = null;
						}
						break;
				}	
			}
		}
	}
}
