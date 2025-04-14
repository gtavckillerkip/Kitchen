using Kitchen.Basic.Managers;
using Kitchen.Gameplay.Quests;
using UnityEngine;

namespace Kitchen.UI
{
	public class QuestsUI : MonoBehaviour
	{
		private void Start()
		{
			QuestsManager.Instance.QuestAdded += HandleQuestAdded;
			QuestsManager.Instance.QuestRemoved += HandleQuestRemoved;
		}

		private void HandleQuestAdded(Quest quest)
		{

		}

		private void HandleQuestRemoved(Quest quest)
		{

		}
	}
}
