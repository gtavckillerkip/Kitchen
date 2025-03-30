using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	[RequireComponent(typeof(ConversionRecipeUser))]
	public class Slicer : Counter, IVariouslyUtilizable
	{
		private ConversionRecipeUser _conversionRecipeUser;

		private void Start()
		{
			_conversionRecipeUser = GetComponent<ConversionRecipeUser>();
		}

		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();

			if (CarriedItem == null)
			{
				if (_conversionRecipeUser.RecipePresent(carrier.GetItemSO()))
				{
					CarriedItem = carrier.Drop();
				}
			}
			else
			{
				if (carrier.TryTake(CarriedItem))
				{
					CarriedItem = null;
				}
			}
		}

		public void UtilizeVariously(GameObject gameObject)
		{
			if (CarriedItem != null)
			{
				var @out = _conversionRecipeUser.UseRecipe(CarriedItem);

				Destroy(CarriedItem);
				CarriedItem = @out;
			}
		}
	}
}
