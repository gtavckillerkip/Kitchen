using Kitchen.ScriptableObjects.Common;
using UnityEngine;

namespace Kitchen.ScriptableObjects.Recipes
{
	[CreateAssetMenu(menuName = "Scriptable objects/Recipes/ConversionRecipe")]
	public class ConversionRecipeSO : ScriptableObject
	{
		[field: SerializeField] public ItemSO In { get; private set; }
		[field: SerializeField] public ItemSO Out { get; private set; }
	}
}
