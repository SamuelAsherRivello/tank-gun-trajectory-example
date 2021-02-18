using UnityEngine;

namespace RMC.TankGunTrajectory.Model
{
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
		public KeyCode KeyCodeFireBullet
		{
			get { return _keyCodeFireBullet; }
		}

		public float BulletSpeed
		{
			get { return _bulletSpeed; }
		}


		//  Fields ----------------------------------------

		[Header("Input")]
		[SerializeField]
		private KeyCode _keyCodeFireBullet = KeyCode.Space;

		[Header("Gameplay")]
		[SerializeField]
		private float _bulletSpeed = 250;

		//  Unity Methods ---------------------------------
	}
}
