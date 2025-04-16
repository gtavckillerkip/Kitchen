using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Kitchen.UI
{
	public class PauseUI : MonoBehaviour
	{
		private const string MAIN_MENU_SCENE_NAME = "MainMenu";

		[SerializeField] private Button _resumeButton;
		[SerializeField] private Button _mainMenuButton;
		[SerializeField] private Button _quitButton;

		private void Start()
		{
			_resumeButton.onClick.AddListener(HandleResumeButtonClicked);
			_mainMenuButton.onClick.AddListener(HandleMainMenuButtonClicked);
			_quitButton.onClick.AddListener(HandleQuitButtonClicked);
		}

		private void HandleResumeButtonClicked()
		{

		}

		private void HandleMainMenuButtonClicked()
		{
			SceneManager.LoadScene(MAIN_MENU_SCENE_NAME);
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
			_resumeButton.onClick.RemoveAllListeners();
			_mainMenuButton.onClick.RemoveAllListeners();
			_quitButton.onClick.RemoveAllListeners();
		}
	}
}
