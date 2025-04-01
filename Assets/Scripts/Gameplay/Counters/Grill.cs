using Kitchen.Gameplay.Items;
using System;
using System.Collections;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	[RequireComponent(typeof(ConversionRecipeUser))]
	public class Grill : Counter
	{
		public enum GrillState
		{
			Idle,
			Frying,
			Overfrying
		}

		private ConversionRecipeUser _conversionRecipeUser;

		private Coroutine _fryingCoroutine;

		private GrillState _state;
		private float _fryingTick;
		private float _fryingTime;

		public event Action<GrillState> StateChanged;
		public event Action<float> TickOfFryingTimePassed;

		private void Start()
		{
			_conversionRecipeUser = GetComponent<ConversionRecipeUser>();
			_state = GrillState.Idle;
			_fryingTick = 1;
			_fryingTime = 3;
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
					_state = GrillState.Frying;
					StateChanged?.Invoke(_state);
				}
			}
			else
			{
				if (_state == GrillState.Frying || _state == GrillState.Overfrying)
				{
					StopCoroutine(_fryingCoroutine);
					_state = GrillState.Idle;
					StateChanged?.Invoke(_state);
				}

				if (carrier.TryTake(CarriedItem))
				{
					CarriedItem = null;
				}
			}
		}

		private IEnumerator Fry()
		{
			float passedTimeOfTick = 0;

			for (float passedTimeOfWholeFrying = 0; passedTimeOfWholeFrying < _fryingTime; passedTimeOfWholeFrying += Time.deltaTime)
			{
				passedTimeOfTick += Time.deltaTime;

				if (passedTimeOfTick > _fryingTick)
				{
					passedTimeOfTick = 0;
					TickOfFryingTimePassed?.Invoke(_fryingTick / _fryingTime);
				}

				yield return null;
			}

			var @out = _conversionRecipeUser.UseRecipe(CarriedItem.ItemSO);

			if (@out != null)
			{
				Destroy(CarriedItem);
				CarriedItem = Instantiate(@out.ItemPrefab).GetComponent<Item>();
			}

			if (_conversionRecipeUser.RecipePresent(@out))
			{
				_fryingCoroutine = StartCoroutine(Fry());
				_state = GrillState.Overfrying;
				StateChanged?.Invoke(_state);
			}
			else
			{
				_state = GrillState.Idle;
				StateChanged?.Invoke(_state);
			}
		}
	}
}
