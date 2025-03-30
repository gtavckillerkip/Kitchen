using System.Collections;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	[RequireComponent(typeof(ConversionRecipeUser))]
	public class Grill : Counter
	{
		private enum GrillState
		{
			Idle,
			Frying
		}

		private ConversionRecipeUser _conversionRecipeUser;

		private Coroutine _fryingCoroutine;
		private WaitForSeconds _fryingTimer;

		private GrillState _state;

		private void Start()
		{
			_conversionRecipeUser = GetComponent<ConversionRecipeUser>();
			_fryingTimer = new(5);
			_state = GrillState.Idle;
		}

		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();

			if (CarriedItem == null)
			{
				if (_conversionRecipeUser.RecipePresent(carrier.GetItemSO()))
				{
					CarriedItem = carrier.Drop();

					_fryingCoroutine = StartCoroutine(Fry());
				}
			}
			else
			{
				if (_state == GrillState.Frying)
				{
					StopCoroutine(_fryingCoroutine);
					_state = GrillState.Idle;
				}

				if (carrier.TryTake(CarriedItem))
				{
					CarriedItem = null;
				}
			}
		}

		private IEnumerator Fry()
		{
			_state = GrillState.Frying;

			yield return _fryingTimer;

			var @out = _conversionRecipeUser.UseRecipe(CarriedItem);

			if (@out != null)
			{
				Destroy(CarriedItem);
				CarriedItem = @out;
			}

			if (_conversionRecipeUser.RecipePresent(@out))
			{
				_fryingCoroutine = StartCoroutine(Fry());
			}
			else
			{
				_state = GrillState.Idle;
			}
		}
	}
}
