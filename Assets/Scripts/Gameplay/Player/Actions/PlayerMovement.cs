using Kitchen.Basic.Managers;
using UnityEngine;

namespace Kitchen.Gameplay.Player
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _moveForce = 10;
		[SerializeField] private float _rotationSpeed = 100;
		[SerializeField] private Transform _collisionRaycastPoint;

		private Vector3 _movementDirection;
		private Rigidbody _rigidbody;
		private InputManager _inputManager;
		private (int Z, int X) _directionsFromInput;
		private float _collisionRaycastLength;

		private void Start()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_inputManager = InputManager.Instance;
			_directionsFromInput = (0, 0);
			_collisionRaycastLength = 0.5f;

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
			if (_directionsFromInput.Z != 0)
			{
				var zRay = new Ray(_collisionRaycastPoint.position, new Vector3(0, 0, _directionsFromInput.Z));

				if (!Physics.Raycast(zRay, _collisionRaycastLength))
				{
					_movementDirection.z = _directionsFromInput.Z;
				}
				else
				{
					_movementDirection.z = 0;
				}
			}
			else
			{
				_movementDirection.z = 0;
			}

			if (_directionsFromInput.X != 0)
			{
				var xRay = new Ray(_collisionRaycastPoint.position, new Vector3(_directionsFromInput.X, 0, 0));

				if (!Physics.Raycast(xRay, _collisionRaycastLength))
				{
					_movementDirection.x = _directionsFromInput.X;
				}
				else
				{
					_movementDirection.x = 0;
				}
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
			}
		}
	}
}
