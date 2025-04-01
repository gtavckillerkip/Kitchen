using Kitchen.Gameplay.Items;
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
				var carrierItem = carrier.GetItem();
				if (carrierItem != null && _conversionRecipeUser.RecipePresent(carrierItem.ItemSO))
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
				var @out = _conversionRecipeUser.UseRecipe(CarriedItem.ItemSO);

				Destroy(CarriedItem.gameObject);
				CarriedItem = Instantiate(@out.ItemPrefab).GetComponent<Item>();
			}
		}
	}
}
