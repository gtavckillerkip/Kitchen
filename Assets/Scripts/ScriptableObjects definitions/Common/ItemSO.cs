using UnityEngine;

namespace Kitchen.ScriptableObjects.Common
{
	public abstract class ItemSO : ScriptableObject
	{
		[field: SerializeField] public string Name { get; protected set; } = "undefined name";

		[field: SerializeField] public GameObject ItemPrefab { get; protected set; }
	}
}
