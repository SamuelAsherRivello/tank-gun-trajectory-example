using UnityEngine;

namespace RMC.TankGunTrajectory.Model
{
	//  Class Fields --------------------------------------
	public enum MouseButton
	{
		Null = -1,
		Left = 0,
		Right = 1
	}

	//  Class Attributes ----------------------------------
	[CreateAssetMenu (
		fileName = "ConfigurationData",
		menuName = "TankGunTrajectory/ConfigurationData",
		order = 0)]

	/// <summary>
	/// Store commonly used values -- Editable at runtime and edit-time.
	/// </summary>
	public class ConfigurationData : ScriptableObject
	{
		//  Properties ------------------------------------
		public MouseButton MouseButtonToFire
		{
			get { return _mouseButtonToFire; }
		}

		public MouseButton MouseButtonToAim
		{
			get { return _mouseButtonToAim; }
		}

		public float BulletSpeed
		{
			get { return _bulletSpeed; }
		}

		public float BulletLifetime
		{
			get { return _bulletLifetime; }
		}

		public float TankTurnSpeed
		{
			get { return _tankTurnSpeed; }
		}

		public float TankMoveSpeed
		{
			get { return _tankMoveSpeed; }
		}

		public ITrajectoryAlgorithm TrajectoryAlgorithm
		{
			get { return _trajectoryAlgorithm; }
		}
		

		//  Fields ----------------------------------------

		[Header("Input")]
		[SerializeField]
		private MouseButton _mouseButtonToFire = MouseButton.Left;

		[SerializeField]
		private MouseButton _mouseButtonToAim = MouseButton.Right;

		[Header("Gameplay")]

		[SerializeField]
		[Range(100, 120)]
		private float _tankTurnSpeed = 100;

		[SerializeField]
		[Range(10, 20)]
		private float _tankMoveSpeed = 10;

		[SerializeField]
		[Range(20, 30)]
		private float _bulletSpeed = 20;

		[SerializeField]
		[Range (2,5)]
		private float _bulletLifetime = 2;

		[Header("Mathematics")]
		[SerializeField]
		private BaseTrajectoryAlgorithm _trajectoryAlgorithm = null;


		//  Unity Methods ---------------------------------
	}
}
