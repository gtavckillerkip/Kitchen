using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Kitchen.UI
{
	public class MainMenuUI : MonoBehaviour
	{
		private const string GAMEPLAY_SCENE_NAME = "Gameplay";

		[SerializeField] private Button _playButton;
		[SerializeField] private Button _quitButton;

		private void Start()
		{
			_playButton.onClick.AddListener(HandlePlayButtonClicked);
			_quitButton.onClick.AddListener(HandleQuitButtonClicked);
		}

		private void HandlePlayButtonClicked()
		{
			SceneManager.LoadScene(GAMEPLAY_SCENE_NAME);
		}

		private void HandleQuitButtonClicked()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}

		private void OnDestroy()
		{
			_playButton.onClick.RemoveAllListeners();
			_quitButton.onClick.RemoveAllListeners();
		}
	}
}
