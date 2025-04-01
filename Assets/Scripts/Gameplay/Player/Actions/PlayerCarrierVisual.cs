using Kitchen.Gameplay.Items;
using UnityEngine;

namespace Kitchen.Gameplay.Player
{
	[RequireComponent(typeof(PlayerCarrier))]
	public class PlayerCarrierVisual : MonoBehaviour
	{
		[SerializeField] private Transform _carryPoint;

		private PlayerCarrier _playerCarrier;

		private void Start()
		{
			_playerCarrier = GetComponent<PlayerCarrier>();

			_playerCarrier.ItemChanged += HandleItemChanged;
		}

		private void HandleItemChanged(Item item)
		{
			if (item != null)
			{
				item.transform.SetParent(_carryPoint);
				item.transform.localPosition = Vector3.zero;
			}
		}
	}
}
