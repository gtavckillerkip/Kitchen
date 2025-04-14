using Kitchen.ScriptableObjects.Recipes;
using Kitchen.ScriptableObjects.Tableware;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kitchen.Gameplay.Items
{
	public class Plate : Item
	{
		private readonly List<Item> _ingredients = new();
		private List<DishRecipeSO> _possibleRecipes = new();

		public event Action<Item> IngredientAdded;
		public event Action Cleared;

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

			if (_ingredients.Any(i => i.ItemSO == ingredient.ItemSO) == false)
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

					IngredientAdded?.Invoke(ingredient);
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

			Cleared?.Invoke();
		}

		public bool IsEmpty => _ingredients.Count == 0;

		public IEnumerable<DishRecipeSO> PossibleRecipes => _possibleRecipes;

		public IEnumerable<Item> Ingredients => _ingredients;

		public (bool IsComplete, DishRecipeSO DishRecipeSO) GetCompleteDishRecipeSO()
		{
			var recipe = _possibleRecipes.FirstOrDefault(r => r.Ins.All(@in => _ingredients.Exists(i => i.ItemSO == @in)));

			return (recipe != null, recipe);
		}
	}
}
