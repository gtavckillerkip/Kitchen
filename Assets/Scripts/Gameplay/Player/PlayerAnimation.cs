using UnityEngine;

namespace Kitchen.Gameplay.Player
{
	[RequireComponent(typeof(Animator), typeof(PlayerMovement))]
	public class PlayerAnimation : MonoBehaviour
	{
		private const string IDLE_TO_MOVING_SWITCH_NAME = "IsMoving";

		private Animator _animator;
		private PlayerMovement _playerMovement;

		private void Start()
		{
			_animator = GetComponent<Animator>();
			_playerMovement = GetComponent<PlayerMovement>();

			_playerMovement.MovementBegun += HandleMovementBegun;
			_playerMovement.MovementStopped += HandleMovementStopped;
		}

		private void HandleMovementBegun()
		{
			_animator.SetBool(IDLE_TO_MOVING_SWITCH_NAME, true);
		}

		private void HandleMovementStopped()
		{
			_animator.SetBool(IDLE_TO_MOVING_SWITCH_NAME, false);
		}
	}
}
