using Kitchen.Basic.Patterns;
using System;
using System.Collections;
using UnityEngine;

namespace Kitchen.Basic.Managers
{
	public class GameplayStartManager : SingletonMB<GameplayStartManager>
	{
		[SerializeField] private int _gameplayDelay = 3;

		private int _timeLeftSecs;

		public event Action GameplayStartDelayPassed;
		public event Action<int> TimeLeftSecsChanged;

		private int TimeLeftSecs
		{
			get => _timeLeftSecs;
			set
			{
				_timeLeftSecs = value;
				TimeLeftSecsChanged?.Invoke(value);
			}
		}

		private void Start()
		{
			StartCoroutine(CountdownDelay());
		}

		private IEnumerator CountdownDelay()
		{
			TimeLeftSecs = _gameplayDelay;
			float timeLeft = _gameplayDelay;
			float oneSec = 1f;

			while (timeLeft > 0)
			{
				timeLeft -= Time.deltaTime;
				oneSec -= Time.deltaTime;

				if (oneSec <= 0)
				{
					oneSec = 1f;
					if (TimeLeftSecs > 1)
					{
						TimeLeftSecs -= 1;
					}
				}

				yield return null;
			}

			GameplayStartDelayPassed?.Invoke();
		}
	}
}
