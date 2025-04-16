using Kitchen.Gameplay.Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kitchen.UI
{
	public class QuestUI : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _titleText;
		[SerializeField] private TextMeshProUGUI _rewardText;
		[SerializeField] private Image[] _ingredientsImages = new Image[4];

		public Quest RefferedQuest { get; private set; }

		public void Setup(Quest quest)
		{
			DeactivateIngredientsImages();

			RefferedQuest = quest;

			_titleText.text = quest.QuestSO.DishRecipeSO.Out.Name;
			_rewardText.text = quest.QuestSO.Reward.ToString();

			for (int i = 0; i < quest.QuestSO.DishRecipeSO.Ins.Length; i++)
			{
				_ingredientsImages[i].gameObject.SetActive(true);
				_ingredientsImages[i].sprite = quest.QuestSO.DishRecipeSO.Ins[i].Sprite;
			}
		}

		public void Unsetup()
		{
			RefferedQuest = null;
		}

		private void DeactivateIngredientsImages()
		{
			for (int i = 0; i < _ingredientsImages.Length; i++)
			{
				_ingredientsImages[i].gameObject.SetActive(false);
			}
		}
	}
}
