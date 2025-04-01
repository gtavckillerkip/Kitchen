using Kitchen.ScriptableObjects.Recipes;
using Kitchen.ScriptableObjects.Tableware;
using System.Collections.Generic;
using System.Linq;

namespace Kitchen.Gameplay.Items
{
	public class Plate : Item
	{
		private readonly List<Item> _ingredients = new();
		private List<DishRecipeSO> _possibleRecipes = new();
		private bool _recipeComplete = false;

		private void Start()
		{
			foreach (var r in (ItemSO as PlateSO).RecipeBook.DishRecipes)
			{
				_possibleRecipes.Add(r);
			}
		}

		public bool TryAddIngredient(Item ingredient)
		{
			bool result = false;

			if (_recipeComplete == false && _ingredients.Any(i => i.ItemSO.Name == ingredient.ItemSO.Name) == false)
			{
				var newPossibleRecipes = new List<DishRecipeSO>();
				_possibleRecipes.ForEach(r =>
				{
					if (r.Ins.Any(i => i.Name == ingredient.ItemSO.Name))
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

			_ingredients.Clear();
			_possibleRecipes.Clear();
			_recipeComplete = false;
		}

		public bool IsEmpty => _ingredients.Count == 0;
	}
}
