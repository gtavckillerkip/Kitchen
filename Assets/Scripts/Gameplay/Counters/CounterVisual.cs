using Kitchen.Gameplay.Items;
using Kitchen.ScriptableObjects.Ingredients;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Kitchen.Gameplay.Counters
{
	public class CounterVisual : MonoBehaviour
	{
		[SerializeField] private Transform _itemPlacement;
		[SerializeField] private Image[] _carryingItemImages = new Image[6];

		private Counter _counter;

		private Plate _carriedPlate;

		private void Start()
		{
			_counter = GetComponent<Counter>();

			DeactivateCarryingItemsImages();

			_counter.ItemChanged += HandleItemChanged;
		}

		private void HandleItemChanged(Item newItem)
		{
			if (newItem != null)
			{
				newItem.transform.SetParent(_itemPlacement);
				newItem.transform.localPosition = Vector3.zero;

				if (newItem is Plate plate)
				{
					if (!plate.IsEmpty)
					{
						for (int i = 0; i < plate.Ingredients.Count(); i++)
						{
							_carryingItemImages[i].gameObject.SetActive(true);
							_carryingItemImages[i].sprite = (plate.Ingredients.ElementAt(i).ItemSO as IngredientSO).Sprite;
						}
					}

					_carriedPlate = plate;
					_carriedPlate.IngredientAdded += HandleIngredientAddedOnPlate;
				}
				else
				{
					_carryingItemImages[0].gameObject.SetActive(true);
					_carryingItemImages[0].sprite = (newItem.ItemSO as IngredientSO).Sprite;
				}
			}
			else
			{
				if (_carriedPlate != null)
				{
					_carriedPlate.IngredientAdded -= HandleIngredientAddedOnPlate;
					_carriedPlate = null;
				}

				DeactivateCarryingItemsImages();
			}
		}

		private void DeactivateCarryingItemsImages()
		{
			for (int i = 0; i < _carryingItemImages.Length; i++)
			{
				_carryingItemImages[i].gameObject.SetActive(false);
			}
		}

		private void HandleIngredientAddedOnPlate(Item item)
		{
			int index = _carriedPlate.Ingredients.Count() - 1;

			_carryingItemImages[index].gameObject.SetActive(true);
			_carryingItemImages[index].sprite = (item.ItemSO as IngredientSO).Sprite;
		}
	}
}
