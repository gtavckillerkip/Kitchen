using Kitchen.Gameplay.Items;
using System;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public abstract class Counter : MonoBehaviour, IUtilizable
	{
		private Item _carriedItem;

		public event Action<Item> ItemChanged;

		public abstract void Utilize(GameObject utilizer);

		protected Item CarriedItem
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
