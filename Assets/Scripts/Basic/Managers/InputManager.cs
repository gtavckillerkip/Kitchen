using Kitchen.Basic.Patterns;
using System;
using UnityEngine;

namespace Kitchen.Basic.Managers
{
	public class InputManager : SingletonMB<InputManager>
	{
		private bool _isForwardButtonPressed;
		private bool _isBackwardButtonPressed;
		private bool _isLeftButtonPressed;
		private bool _isRightButtonPressed;

		public event Action ForwardButtonDown;
		public event Action BackwardButtonDown;
		public event Action LeftButtonDown;
		public event Action RightButtonDown;

		public event Action ForwardButtonUp;
		public event Action BackwardButtonUp;
		public event Action LeftButtonUp;
		public event Action RightButtonUp;

		public event Action UtilizeButtonUp;
		public event Action VariouslyUtilizeButtonUp;

		public event Action PauseButtonUp;

		private void Start()
		{
			_isForwardButtonPressed = false;
			_isBackwardButtonPressed = false;
			_isLeftButtonPressed = false;
			_isRightButtonPressed = false;

			enabled = false;

			GameplayStartManager.Instance.GameplayStartDelayPassed += () => enabled = true;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				_isForwardButtonPressed = true;
				ForwardButtonDown?.Invoke();
			}

			if (Input.GetKeyDown(KeyCode.S))
			{
				_isBackwardButtonPressed = true;
				BackwardButtonDown?.Invoke();
			}

			if (Input.GetKeyDown(KeyCode.A))
			{
				_isLeftButtonPressed = true;
				LeftButtonDown?.Invoke();
			}

			if (Input.GetKeyDown(KeyCode.D))
			{
				_isRightButtonPressed= true;
				RightButtonDown?.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.W) && _isForwardButtonPressed)
			{
				ForwardButtonUp?.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.S) && _isBackwardButtonPressed)
			{
				BackwardButtonUp?.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.A) && _isLeftButtonPressed)
			{
				LeftButtonUp?.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.D) && _isRightButtonPressed)
			{
				RightButtonUp?.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.E))
			{
				if (Input.GetKey(KeyCode.LeftShift))
				{
					VariouslyUtilizeButtonUp?.Invoke();
				}
				else
				{
					UtilizeButtonUp?.Invoke();
				}
			}

			if (Input.GetKeyUp(KeyCode.Escape))
			{
				PauseButtonUp?.Invoke();
			}
		}
	}
}
