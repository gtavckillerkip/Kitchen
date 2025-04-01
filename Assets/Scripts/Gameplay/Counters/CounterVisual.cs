using Kitchen.Gameplay.Items;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class CounterVisual : MonoBehaviour
	{
		[SerializeField] private Transform _itemPlacement;

		private Counter _counter;

		private void Start()
		{
			_counter = GetComponent<Counter>();

			_counter.ItemChanged += HandleItemChanged;
		}

		private void HandleItemChanged(Item newItem)
		{
			if (newItem != null)
			{
				newItem.transform.SetParent(_itemPlacement);
				newItem.transform.localPosition = Vector3.zero;
			}
		}
	}
}
