using Kitchen.Basic.Patterns;
using System;
using System.Collections;
using UnityEngine;

namespace Kitchen.Basic.Managers
{
	public class GameplayStartManager : SingletonMB<GameplayStartManager>
	{
		[SerializeField] private int _gameplayDelay = 3;

		public event Action GameplayStartDelayPassed;

		private void Start()
		{
			StartCoroutine(CountdownDelay());
		}

		private IEnumerator CountdownDelay()
		{
			float timeLeft = _gameplayDelay;

			while (timeLeft > 0)
			{
				timeLeft -= Time.deltaTime;
				yield return null;
			}

			GameplayStartDelayPassed?.Invoke();
		}
	}
}
