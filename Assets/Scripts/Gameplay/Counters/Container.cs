using Kitchen.Gameplay.Items;
using Kitchen.ScriptableObjects.Ingredients;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class Container : Counter
	{
		[SerializeField] private IngredientSO _takeableIngredient;

		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();

			if (carrier.GetItem() == null)
			{
				carrier.TryTake(Instantiate(_takeableIngredient.ItemPrefab).GetComponent<Item>());
			}
		}
	}
}
