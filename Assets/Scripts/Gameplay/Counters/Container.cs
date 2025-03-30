using Kitchen.ScriptableObjects.Ingredients;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class Container : Counter
	{
		[SerializeField] private IngredientSO _takeableIngredient;

		private void Start()
		{
			CarriedItem = Instantiate(_takeableIngredient);
		}

		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();

			carrier.TryTake(Instantiate(_takeableIngredient));
		}
	}
}
