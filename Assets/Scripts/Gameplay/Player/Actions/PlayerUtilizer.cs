using Kitchen.Basic.Managers;
using UnityEngine;

namespace Kitchen.Gameplay.Player
{
	public class PlayerUtilizer : MonoBehaviour, IUtilizer
	{
		private enum UtilizeType
		{
			Normal,
			Various
		}

		[SerializeField] private Transform _utilizeCastPoint;
		[SerializeField] private float _maxCastDistance = 1f;

		private InputManager _inputManager;

		private void Start()
		{
			_inputManager = InputManager.Instance;

			_inputManager.UtilizeButtonUp += () => Utilize(UtilizeType.Normal);
			_inputManager.VariouslyUtilizeButtonUp += () => Utilize(UtilizeType.Various);
		}

		private void Utilize(UtilizeType utilizeType)
		{
			var ray = new Ray(_utilizeCastPoint.position, _utilizeCastPoint.rotation * _utilizeCastPoint.forward);

			if (Physics.Raycast(ray, out var hit, _maxCastDistance))
			{
				switch (utilizeType)
				{
					case UtilizeType.Normal:
						if (hit.collider.GetComponent<IUtilizable>() is IUtilizable utilizable)
						{
							utilizable.Utilize(gameObject);
						}
						break;

					case UtilizeType.Various:
						if (hit.collider.GetComponent<IVariouslyUtilizable>() is IVariouslyUtilizable variouslyUtilizable)
						{
							variouslyUtilizable.UtilizeVariously(gameObject);
						}
						break;
				}
			}
		}
	}
}
