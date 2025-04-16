using Kitchen.Basic.Patterns;
using Kitchen.Gameplay.Quests;
using Kitchen.ScriptableObjects.Quests;
using Kitchen.ScriptableObjects.Recipes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kitchen.Basic.Managers
{
	public class QuestsManager : SingletonMB<QuestsManager>
	{
		[SerializeField] private QuestSO[] _questsAvailable;

		private readonly List<Quest> _currentQuests = new();
		private int _maxQuestsAmount;

		private WaitForSeconds _secsBetweenQuestsAddings;
		private Coroutine _questsAddingCoroutine;

		public Action<Quest> QuestAdded;
		public Action<Quest> QuestRemoved;

		private void Start()
		{
			_maxQuestsAmount = 4;
			_secsBetweenQuestsAddings = new(3);

			QuestRemoved += HandleQuestRemoved;

			enabled = false;

			GameplayStartManager.Instance.GameplayStartDelayPassed += () =>
			{
				enabled = true;
				_questsAddingCoroutine = StartCoroutine(AddQuests());
			};
		}

		private IEnumerator AddQuests()
		{
			if (_questsAvailable.Length == 0)
			{
				yield break;
			}

			while (_currentQuests.Count < _maxQuestsAmount)
			{
				yield return _secsBetweenQuestsAddings;

				var questSO = _questsAvailable[UnityEngine.Random.Range(0, _questsAvailable.Length)];
				var quest = new Quest(questSO);

				_currentQuests.Add(quest);
				QuestAdded?.Invoke(quest);
			}

			_questsAddingCoroutine = null;
		}

		public bool TryPassQuest(DishRecipeSO dishRecipeSO)
		{
			var quest = _currentQuests.FirstOrDefault(q => q.QuestSO.DishRecipeSO == dishRecipeSO);

			if (quest == null)
			{
				return false;
			}

			_currentQuests.Remove(quest);
			QuestRemoved?.Invoke(quest);

			return true;
		}

		private void HandleQuestRemoved(Quest quest)
		{
			if (_questsAddingCoroutine != null)
			{
				return;
			}

			_questsAddingCoroutine = StartCoroutine(AddQuests());
		}
	}
}
