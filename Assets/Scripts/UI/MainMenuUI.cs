using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Kitchen.UI
{
	public class MainMenuUI : MonoBehaviour
	{
		private const string GAMEPLAY_SCENE_NAME = "Gameplay";

		[SerializeField] private GameObject _mainMenuGameObject;
		[SerializeField] private GameObject _instructionsGameObject;

		[SerializeField] private Button _playButton;
		[SerializeField] private Button _instructionsButton;
		[SerializeField] private Button _quitButton;

		private void Start()
		{
			_mainMenuGameObject.SetActive(true);

			_playButton.onClick.AddListener(HandlePlayButtonClicked);
			_instructionsButton.onClick.AddListener(HandleInstructionsButtonClicked);
			_quitButton.onClick.AddListener(HandleQuitButtonClicked);
		}

		private void HandlePlayButtonClicked()
		{
			SceneManager.LoadScene(GAMEPLAY_SCENE_NAME);
		}

		private void HandleInstructionsButtonClicked()
		{
			_mainMenuGameObject.SetActive(false);
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
	}
}
