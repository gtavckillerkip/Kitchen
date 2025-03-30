using Kitchen.ScriptableObjects.Common;
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

		private void HandleItemChanged(ItemSO newItem)
		{
			if (_itemPlacement.childCount > 0)
			{
				Destroy(_itemPlacement.GetChild(0).gameObject);
			}

			if (newItem != null && newItem.ItemPrefab != null)
			{
				Instantiate(newItem.ItemPrefab, _itemPlacement);
			}
		}
	}
}
