using Kitchen.Basic.Patterns;
using Kitchen.Gameplay.Quests;
using System;

namespace Kitchen.Basic.Managers
{
	public class ScoreManager : SingletonMB<ScoreManager>
	{
		private float _currentScore;

		public event Action<float> ScoreUpdated;

		private void Start()
		{
			_currentScore = 0;

			QuestsManager.Instance.QuestRemoved += HandleQuestRemoved;
		}

		private void HandleQuestRemoved(Quest quest)
		{
			_currentScore += quest.QuestSO.Reward;
			ScoreUpdated?.Invoke(_currentScore);
		}
	}
}
