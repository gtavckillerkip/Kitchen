using Kitchen.ScriptableObjects.Common;
using Kitchen.ScriptableObjects.Recipes;
using System.Linq;
using UnityEngine;

namespace Kitchen.Gameplay
{
	public class ConversionRecipeUser : MonoBehaviour
	{
		[SerializeField] private ConversionRecipeSO[] _recipes;

		public ItemSO UseRecipe(ItemSO @in)
		{
			return _recipes.FirstOrDefault(r => r.In.Name == @in.Name) is ConversionRecipeSO recipe ? Instantiate(recipe.Out) : null;
		}

		public bool RecipePresent(ItemSO @in) => _recipes.Any(r => r.In.Name == @in.Name);
	}
}
