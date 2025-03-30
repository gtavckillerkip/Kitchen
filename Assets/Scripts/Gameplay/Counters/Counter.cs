using Kitchen.ScriptableObjects.Common;
using System;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public abstract class Counter : MonoBehaviour, IUtilizable
	{
		private ItemSO _carriedItem;

		public event Action<ItemSO> ItemChanged;

		public abstract void Utilize(GameObject utilizer);

		protected ItemSO CarriedItem
		{
			get => _carriedItem;
			set
			{
				_carriedItem = value;
				ItemChanged?.Invoke(value);
			}
		}
	}
}
