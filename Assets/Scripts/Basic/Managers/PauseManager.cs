using Kitchen.Basic.Patterns;
using System;
using UnityEngine;

namespace Kitchen.Basic.Managers
{
	public class PauseManager : SingletonMB<PauseManager>
	{
		private bool _isGamePaused;

		public event Action GamePaused;
		public event Action GameUnpaused;

		private void Start()
		{
			_isGamePaused = false;

			InputManager.Instance.PauseButtonUp += HandlePauseButtonPressed;
		}

		private void HandlePauseButtonPressed()
		{
			if (_isGamePaused)
			{
				Unpause();
			}
			else
			{
				Pause();
			}
		}

		public void Pause()
		{
			Time.timeScale = 0;
			_isGamePaused = true;
			GamePaused?.Invoke();
		}

		public void Unpause()
		{
			Time.timeScale = 1;
			_isGamePaused = false;
			GameUnpaused?.Invoke();
		}
	}
}
