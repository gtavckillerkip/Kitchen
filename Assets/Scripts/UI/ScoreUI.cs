using Kitchen.Basic.Managers;
using Kitchen.Gameplay.Quests;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Kitchen.UI
{
	public class ScoreUI : MonoBehaviour
	{
		[SerializeField] private GameObject _scoreGameObject;

		[SerializeField] private TextMeshProUGUI _scoreText;
		[SerializeField] private TextMeshProUGUI _addScoreText;

		private WaitForSeconds _addScoreTextShowingTime;
		private Coroutine _addScoreTextShowingCoroutine;

		private void Start()
		{
			_scoreGameObject.SetActive(false);
			_addScoreText.gameObject.SetActive(false);

			_addScoreTextShowingTime = new(1);

			ScoreManager.Instance.ScoreUpdated += HandleScoreUpdated;
			QuestsManager.Instance.QuestRemoved += HandleQuestRemoved;
		}

		private void HandleScoreUpdated(float newScore)
		{
			if (_scoreGameObject.activeSelf == false)
			{
				_scoreGameObject.SetActive(true);
			}

			_scoreText.text = newScore.ToString();
		}

		private void HandleQuestRemoved(Quest quest)
		{
			if (_addScoreTextShowingCoroutine != null)
			{
				StopCoroutine(_addScoreTextShowingCoroutine);
			}

			_addScoreText.gameObject.SetActive(true);
			_addScoreText.text = $"+{quest.QuestSO.Reward}";
			_addScoreTextShowingCoroutine = StartCoroutine(ShowingAddScoreTextTimer());
		}

		private IEnumerator ShowingAddScoreTextTimer()
		{
			yield return _addScoreTextShowingTime;

			_addScoreText.gameObject.SetActive(false);
			_addScoreTextShowingCoroutine = null;
		}
	}
}
