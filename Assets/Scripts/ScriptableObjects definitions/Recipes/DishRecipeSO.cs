using Kitchen.ScriptableObjects.Ingredients;
using UnityEngine;

namespace Kitchen.ScriptableObjects.Recipes
{
	[CreateAssetMenu(menuName = "Scriptable objects/Recipes/DishRecipe")]
	public class DishRecipeSO : ScriptableObject
	{
		[field: SerializeField] public IngredientSO[] Ins { get; private set; }
		[field: SerializeField] public DishSO Out { get; private set; }
	}
}
