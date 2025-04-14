using Kitchen.ScriptableObjects.Common;
using UnityEngine;

namespace Kitchen.ScriptableObjects.Ingredients
{
	[CreateAssetMenu(menuName = "Scriptable objects/Ingredients/Ingredient")]
	public class IngredientSO : ItemSO
	{
		[field: SerializeField] public Sprite Sprite { get; private set; }
	}
}
