using Kitchen.Basic.Patterns;
using System;
using UnityEngine;

namespace Kitchen.Basic.Managers
{
	public class InputManager : SingletonMB<InputManager>
	{
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

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				ForwardButtonDown?.Invoke();
			}

			if (Input.GetKeyDown(KeyCode.S))
			{
				BackwardButtonDown?.Invoke();
			}

			if (Input.GetKeyDown(KeyCode.A))
			{
				LeftButtonDown?.Invoke();
			}

			if (Input.GetKeyDown(KeyCode.D))
			{
				RightButtonDown?.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.W))
			{
				ForwardButtonUp?.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.S))
			{
				BackwardButtonUp?.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.A))
			{
				LeftButtonUp?.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.D))
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
		}
	}
}
