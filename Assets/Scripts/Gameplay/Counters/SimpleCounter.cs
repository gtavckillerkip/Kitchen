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

			switch (CarriedItem)
			{
				case null:
					CarriedItem = carrier.Drop();
					break;

				case PlateSO plate:
					var item = carrier.Drop() as IngredientSO;
					if (plate.TryAddIngredient(item) == false)
					{
						carrier.TryTake(item);
					}
					break;

				case IngredientSO ingredient:
					if (carrier.TryTake(ingredient))
					{
						CarriedItem = null;
					}
					break;
			}
		}
	}
}
