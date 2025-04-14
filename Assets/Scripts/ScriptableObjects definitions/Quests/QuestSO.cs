using Kitchen.ScriptableObjects.Recipes;
using UnityEngine;

namespace Kitchen.ScriptableObjects.Quests
{
	[CreateAssetMenu(menuName = "Scriptable objects/Quests/Quest")]
	public class QuestSO : ScriptableObject
	{
		[field: SerializeField] public DishRecipeSO DishRecipeSO { get; private set; }
		[field: SerializeField] public float Reward { get; private set; }
	}
}
