using Kitchen.ScriptableObjects.Ingredients;
using System;
using UnityEngine;

namespace Kitchen.ScriptableObjects.Recipes
{
	[CreateAssetMenu(menuName = "Scriptable objects/Recipes/DishIngredientsPositioner")]
	public class DishIngredientsPositioner : ScriptableObject
	{
		[Serializable]
		public struct IngredientPosition
		{
			[field: SerializeField] public IngredientSO IngredientSO { get; private set; }
			[field: SerializeField] public Vector3 Position { get; private set; }
			[field: SerializeField] public Vector3 Rotation { get; private set; }
		}

		[field: SerializeField] public IngredientPosition[] IngredientsPositions { get; private set; }
	}
}
