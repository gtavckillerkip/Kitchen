using Kitchen.ScriptableObjects.Common;
using UnityEngine;

namespace Kitchen.Gameplay.Items
{
	public class Item : MonoBehaviour
	{
		[field: SerializeField] public ItemSO ItemSO { get; private set; }
	}
}
