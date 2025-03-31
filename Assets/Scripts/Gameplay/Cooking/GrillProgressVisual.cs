using Kitchen.Gameplay.Counters;
using UnityEngine;
using UnityEngine.UI;

namespace Kitchen.Gameplay.Cooking
{
	[RequireComponent(typeof(Grill))]
	public class GrillProgressVisual : MonoBehaviour
	{
		[SerializeField] private Image _back;
		[SerializeField] private Image _frontNormal;
		[SerializeField] private Image _frontCaution;

		private Grill _grill;
		private Image _currentFront;

		private void Start()
		{
			_grill = GetComponent<Grill>();

			_back.gameObject.SetActive(false);

			_frontNormal.gameObject.SetActive(false);
			_frontNormal.fillAmount = 0;

			_frontCaution.gameObject.SetActive(false);
			_frontCaution.fillAmount = 0;

			_currentFront = null;

			_grill.StateChanged += HandleStateChanged;
			_grill.TickOfFryingTimePassed += HandleTickOfFryingPassed;

		}

		private void HandleStateChanged(Grill.GrillState newState)
		{
			_back.gameObject.SetActive(newState != Grill.GrillState.Idle);
			_frontNormal.gameObject.SetActive(newState == Grill.GrillState.Frying);
			_frontCaution.gameObject.SetActive(newState == Grill.GrillState.Overfrying);

			_currentFront = newState switch
			{
				Grill.GrillState.Frying => _frontNormal,
				Grill.GrillState.Overfrying => _frontCaution,
				_ => null
			};

			if (_currentFront != null)
			{
				_currentFront.fillAmount = 0;
			}
		}

		private void HandleTickOfFryingPassed(float fraction)
		{
			_currentFront.fillAmount += fraction;
		}
	}
}
