using Kitchen.Basic.Managers;
using System;
using UnityEngine;

namespace Kitchen.Gameplay.Player
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : MonoBehaviour
	{
		private enum MovementState
		{
			Idle,
			Moving,
		}

		[SerializeField] private float _moveForce = 10;
		[SerializeField] private float _rotationSpeed = 100;
		[SerializeField] private Transform _collisionRaycastPoint;
		[SerializeField] private float _collisionRaycastLength = 0.75f;

		private Vector3 _movementDirection;
		private Rigidbody _rigidbody;
		private InputManager _inputManager;
		private (int Z, int X) _directionsFromInput;

		private MovementState _state;

		public event Action MovementBegun;
		public event Action MovementStopped;

		private void Start()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_inputManager = InputManager.Instance;
			_directionsFromInput = (0, 0);

			_state = MovementState.Idle;

			_inputManager.ForwardButtonDown += () => _directionsFromInput.Z++;
			_inputManager.BackwardButtonDown += () => _directionsFromInput.Z--;
			_inputManager.LeftButtonDown += () => _directionsFromInput.X--;
			_inputManager.RightButtonDown += () => _directionsFromInput.X++;

			_inputManager.ForwardButtonUp += () => _directionsFromInput.Z--;
			_inputManager.BackwardButtonUp += () => _directionsFromInput.Z++;
			_inputManager.LeftButtonUp += () => _directionsFromInput.X++;
			_inputManager.RightButtonUp += () => _directionsFromInput.X--;
		}

		private void Update()
		{
			if (_directionsFromInput.Z != 0 &&
				!Physics.Raycast(new Ray(_collisionRaycastPoint.position, new Vector3(0, 0, _directionsFromInput.Z)), _collisionRaycastLength))
			{
				_movementDirection.z = _directionsFromInput.Z;
			}
			else
			{
				_movementDirection.z = 0;
			}

			if (_directionsFromInput.X != 0 &&
				!Physics.Raycast(new Ray(_collisionRaycastPoint.position, new Vector3(_directionsFromInput.X, 0, 0)), _collisionRaycastLength))
			{
				_movementDirection.x = _directionsFromInput.X;
			}
			else
			{
				_movementDirection.x = 0;
			}

			if (_directionsFromInput != (0, 0))
			{
				transform.rotation = Quaternion.RotateTowards(
					transform.rotation,
					Quaternion.LookRotation(new(_directionsFromInput.X, 0, _directionsFromInput.Z)),
					_rotationSpeed * Time.deltaTime);
			}

			if (_movementDirection != Vector3.zero)
			{
				_rigidbody.linearVelocity = _movementDirection.normalized * _moveForce;

				if (_state == MovementState.Idle)
				{
					_state = MovementState.Moving;
					MovementBegun?.Invoke();
				}
			}
			else
			{
				if (_state == MovementState.Moving)
				{
					_state = MovementState.Idle;
					MovementStopped?.Invoke();
				}
			}
		}
	}
}
