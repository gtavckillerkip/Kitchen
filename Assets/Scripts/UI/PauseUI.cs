using Kitchen.Basic.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Kitchen.UI
{
	public class PauseUI : MonoBehaviour
	{
		private const string MAIN_MENU_SCENE_NAME = "MainMenu";

		[SerializeField] private GameObject _pauseGameObject;
		[SerializeField] private GameObject _instructionsGameObject;

		[SerializeField] private Button _resumeButton;
		[SerializeField] private Button _mainMenuButton;
		[SerializeField] private Button _instructionsButton;
		[SerializeField] private Button _quitButton;

		private void Start()
		{
			_resumeButton.onClick.AddListener(HandleResumeButtonClicked);
			_mainMenuButton.onClick.AddListener(HandleMainMenuButtonClicked);
			_instructionsButton.onClick.AddListener(HandleInstructionsButtonClicked);
			_quitButton.onClick.AddListener(HandleQuitButtonClicked);

			PauseManager.Instance.GamePaused += HandleGamePaused;
			PauseManager.Instance.GameUnpaused += HandleGameUnpaused;
		}

		private void HandleResumeButtonClicked()
		{
			PauseManager.Instance.Unpause();
		}

		private void HandleMainMenuButtonClicked()
		{
			SceneManager.LoadScene(MAIN_MENU_SCENE_NAME);
		}

		private void HandleInstructionsButtonClicked()
		{
			_pauseGameObject.SetActive(false);
			_instructionsGameObject.SetActive(true);
		}

		private void HandleQuitButtonClicked()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}

		private void HandleGamePaused()
		{
			_pauseGameObject.SetActive(true);
		}

		private void HandleGameUnpaused()
		{
			if (_instructionsGameObject.activeSelf)
			{
				_instructionsGameObject.SetActive(false);
			}

			_pauseGameObject.SetActive(false);
		}
	}
}
