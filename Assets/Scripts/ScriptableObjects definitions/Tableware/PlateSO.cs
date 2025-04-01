using Kitchen.ScriptableObjects.Common;
using Kitchen.ScriptableObjects.Recipes;
using UnityEngine;

namespace Kitchen.ScriptableObjects.Tableware
{
	[CreateAssetMenu(menuName = "Scriptable objects/Tableware/Plate")]
	public class PlateSO : ItemSO
	{
		[field: SerializeField] public RecipeBook RecipeBook { get; private set; }
	}
}
