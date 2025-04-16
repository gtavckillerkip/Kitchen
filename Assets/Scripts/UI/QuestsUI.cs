using Kitchen.Basic.Managers;
using Kitchen.Gameplay.Quests;
using UnityEngine;

namespace Kitchen.UI
{
	public class QuestsUI : MonoBehaviour
	{
		[SerializeField] private GameObject _questsGameObject;

		[SerializeField] private QuestUI[] _questsUIs = new QuestUI[4];

		private int _lastActiveQuestIndex = -1;

		private void Start()
		{
			_questsGameObject.SetActive(true);

			DeactivateAllQuestsUIs();

			QuestsManager.Instance.QuestAdded += HandleQuestAdded;
			QuestsManager.Instance.QuestRemoved += HandleQuestRemoved;
			PauseManager.Instance.GamePaused += HandleGamePaused;
			PauseManager.Instance.GameUnpaused += HandleGameUnpaused;
		}

		private void HandleQuestAdded(Quest quest)
		{
			_lastActiveQuestIndex++;

			_questsUIs[_lastActiveQuestIndex].Setup(quest);
			_questsUIs[_lastActiveQuestIndex].gameObject.SetActive(true);
		}

		private void HandleQuestRemoved(Quest quest)
		{
			for (int i = 0; i < _questsUIs.Length; i++)
			{
				if (_questsUIs[i].RefferedQuest == quest)
				{
					var deactivatedQuestUI = _questsUIs[i];

					_questsUIs[i].gameObject.SetActive(false);
					_questsUIs[i].Unsetup();

					for (int j = i + 1; j < _questsUIs.Length; j++)
					{
						_questsUIs[j - 1] = _questsUIs[j];
					}

					_questsUIs[^1] = deactivatedQuestUI;
					deactivatedQuestUI.transform.SetAsLastSibling();
					_lastActiveQuestIndex--;
				}
			}
		}

		private void DeactivateAllQuestsUIs()
		{
			for (int i = 0; i < _questsUIs.Length; i++)
			{
				_questsUIs[i].gameObject.SetActive(false);
			}
		}

		private void HandleGamePaused()
		{
			_questsGameObject.SetActive(false);
		}

		private void HandleGameUnpaused()
		{
			_questsGameObject.SetActive(true);
		}
	}
}
