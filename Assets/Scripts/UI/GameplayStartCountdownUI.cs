using Kitchen.Basic.Managers;
using TMPro;
using UnityEngine;

namespace Kitchen.UI
{
	public class GameplayStartCountdownUI : MonoBehaviour
	{
		[SerializeField] private GameObject _gameplayStartCountdownGameObject;

		[SerializeField] private TextMeshProUGUI _text;

		private void Start()
		{
			_gameplayStartCountdownGameObject.SetActive(true);

			GameplayStartManager.Instance.GameplayStartDelayPassed += HandleGameplayStartDelayPassed;
			GameplayStartManager.Instance.TimeLeftSecsChanged += HandleTimeLeftSecsChanged;
		}

		private void HandleGameplayStartDelayPassed()
		{
			_gameplayStartCountdownGameObject.SetActive(false);
		}

		private void HandleTimeLeftSecsChanged(int newSecs)
		{
			_text.text = newSecs.ToString();
		}
	}
}
