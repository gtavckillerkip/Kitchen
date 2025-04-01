using Kitchen.Gameplay.Items;
using Kitchen.ScriptableObjects.Recipes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kitchen.Gameplay.Cooking
{
	[RequireComponent(typeof(Plate))]
	public class PlateVisual : MonoBehaviour
	{
		private Plate _plate;
		private DishRecipeSO _possibleRecipe;
		private List<Item> _ingredients = new();

		private void Start()
		{
			_plate = GetComponent<Plate>();

			_plate.IngredientAdded += HandleIngredientAdded;
			_plate.Cleared += HandleCleared;
		}

		private void HandleIngredientAdded(Item ingredient)
		{
			var possibleRecipe = _plate.PossibleRecipes.First();

			if (possibleRecipe != _possibleRecipe)
			{
				foreach (var i in _ingredients)
				{
					SetupIngredientTransform(i, possibleRecipe);
				}

				_possibleRecipe = possibleRecipe;
			}

			ingredient.transform.SetParent(transform);
			SetupIngredientTransform(ingredient, possibleRecipe);
			_ingredients.Add(ingredient);
		}

		private void SetupIngredientTransform(Item ingredient, DishRecipeSO possibleRecipe)
		{
			var ip = possibleRecipe.IngredientsPositioner.IngredientsPositions.First(ip => ip.IngredientSO.Name == ingredient.ItemSO.Name);
			ingredient.transform.localPosition = ip.Position;
			ingredient.transform.localEulerAngles = ip.Rotation;
		}

		private void HandleCleared()
		{
			foreach (var i in _ingredients)
			{
				Destroy(i.gameObject);
			}

			_ingredients.Clear();
		}
	}
}
