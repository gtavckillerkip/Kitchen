using UnityEngine;

namespace Kitchen.ScriptableObjects.Recipes
{
	[CreateAssetMenu(menuName = "Scriptable objects/Recipes/RecipeBook")]
	public class RecipeBook : ScriptableObject
	{
		[field: SerializeField] public DishRecipeSO[] DishRecipes { get; private set; }
	}
}
