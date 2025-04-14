using Kitchen.ScriptableObjects.Quests;

namespace Kitchen.Gameplay.Quests
{
	public class Quest
	{
		public Quest(QuestSO questSO)
		{
			QuestSO = questSO;
		}

		public QuestSO QuestSO { get; private set; }
	}
}
