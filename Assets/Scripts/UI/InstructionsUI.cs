using UnityEngine;
using UnityEngine.UI;

namespace Kitchen.UI
{
	public class InstructionsUI : MonoBehaviour
	{
		[SerializeField] private GameObject _instructionsGameObject;

		[SerializeField] private Button _backButton;
		[SerializeField] private GameObject _previousWindowGameObject;

		private void Start()
		{
			_instructionsGameObject.SetActive(false);

			_backButton.onClick.AddListener(HandleBackButtonClicked);
		}

		private void HandleBackButtonClicked()
		{
			_instructionsGameObject.SetActive(false);
			_previousWindowGameObject.SetActive(true);
		}
	}
}
