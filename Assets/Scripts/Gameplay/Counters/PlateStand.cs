using Kitchen.ScriptableObjects.Tableware;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class PlateStand : Counter
	{
		[SerializeField] private PlateSO _plate;

		private void Start()
		{
			CarriedItem = Instantiate(_plate);
		}

		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();

			carrier.TryTake(Instantiate(_plate));
		}
	}
}
