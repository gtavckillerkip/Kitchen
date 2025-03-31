using Kitchen.ScriptableObjects.Common;
using Kitchen.ScriptableObjects.Ingredients;
using Kitchen.ScriptableObjects.Recipes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kitchen.ScriptableObjects.Tableware
{
	[CreateAssetMenu(menuName = "Scriptable objects/Tableware/Plate")]
	public class PlateSO : ItemSO
	{
		[SerializeField] private RecipeBook _recipeBook;

		private readonly List<IngredientSO> _ingredients = new();
		private List<DishRecipeSO> _possibleRecipes = new();
		private bool _recipeComplete = false;

		private void OnEnable()
		{
			foreach (var r in _recipeBook.DishRecipes)
			{
				_possibleRecipes.Add(r);
			}
		}

		public bool TryAddIngredient(IngredientSO ingredient)
		{
			bool result = false;

			if (_recipeComplete == false && _ingredients.Any(i => i.Name == ingredient.Name) == false)
			{
				var newPossibleRecipes = new List<DishRecipeSO>();
				_possibleRecipes.ForEach(r =>
				{
					if (r.Ins.Any(i => i.Name == ingredient.Name))
					{
						newPossibleRecipes.Add(r);
					}
				});

				if (newPossibleRecipes.Count > 0)
				{
					_ingredients.Add(ingredient);
					result = true;
					_possibleRecipes = newPossibleRecipes;

					if (_possibleRecipes.Count == 1)
					{
						_recipeComplete = true;
					}
				}
			}

			return result;
		}

		public void Clear()
		{
			foreach (var i in _ingredients)
			{
				Destroy(i);
			}

			_possibleRecipes.Clear();
			_recipeComplete = false;
		}

		public bool IsEmpty => _ingredients.Count == 0;
	}
}
