using Kitchen.Basic.Managers;
using UnityEngine;

namespace Kitchen.Gameplay.Player
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _moveForce = 10;
		[SerializeField] private float _rotationSpeed = 100;

		private Vector3 _inputVector;
		private Rigidbody _rigidbody;
		private InputManager _inputManager;

		private void Start()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_inputManager = InputManager.Instance;

			_inputManager.ForwardButtonDown += () => _inputVector += Vector3.forward;
			_inputManager.BackwardButtonDown += () => _inputVector += Vector3.back;
			_inputManager.LeftButtonDown += () => _inputVector += Vector3.left;
			_inputManager.RightButtonDown += () => _inputVector += Vector3.right;

			_inputManager.ForwardButtonUp += () => _inputVector -= Vector3.forward;
			_inputManager.BackwardButtonUp += () => _inputVector -= Vector3.back;
			_inputManager.LeftButtonUp += () => _inputVector -= Vector3.left;
			_inputManager.RightButtonUp += () => _inputVector -= Vector3.right;
		}

		private void Update()
		{
			if (_inputVector != Vector3.zero)
			{
				_rigidbody.linearVelocity = _inputVector.normalized * _moveForce;

				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_inputVector), _rotationSpeed * Time.deltaTime);
			}
		}
	}
}
