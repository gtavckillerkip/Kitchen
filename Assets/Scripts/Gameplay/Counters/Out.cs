﻿using Kitchen.Gameplay.Items;
using UnityEngine;

namespace Kitchen.Gameplay.Counters
{
	public class Out : Counter
	{
		public override void Utilize(GameObject utilizer)
		{
			ICarrier carrier = utilizer.GetComponent<ICarrier>();

			if (carrier.GetItem() is Plate plate && plate.IsEmpty == false)
			{
				carrier.Drop();

				plate.Clear();
				Destroy(plate.gameObject);
			}
		}
	}
}
