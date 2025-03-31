using Kitchen.ScriptableObjects.Common;
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

			_playerCarrier.ItemTaken += HandleItemTaken;
			_playerCarrier.ItemDropped += HandleItemDropped;
		}

		private void HandleItemTaken(ItemSO item)
		{
			if (item != null && item.ItemPrefab != null)
			{
				Instantiate(item.ItemPrefab, _carryPoint);
			}
		}

		private void HandleItemDropped(ItemSO item)
		{
			if (_carryPoint.childCount > 0)
			{
				Destroy(_carryPoint.GetChild(0).gameObject);
			}
		}
	}
}
