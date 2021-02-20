using RMC.TankGunTrajectory.Model;
using UnityEngine;

namespace RMC.TankGunTrajectory.View
{
	/// <summary>
	/// Handles all high-level tank-related concerns.
	/// 
	/// Wraps <see cref="Turret"/> concerns too.
	/// 
	/// </summary>
	public class Tank : MonoBehaviour
	{
		//  Fields ----------------------------------------

		[Header ("Children")]
		[SerializeField]
		private Turret _turret = null;

		[SerializeField]
		private Rigidbody _rigidbody = null;

		[Header("Prefabs")]
		[SerializeField]
		private Bullet _bulletPrefab = null;

		
		[Header("Configuration")]
		[SerializeField]
		private ConfigurationData _configurationData = null;

		private float _horizontalInput = 0;
		private float _verticalInput = 0;

		//  Unity Methods ---------------------------------

		/// <summary>
		/// Take input smoothly on Update
		/// </summary>
		protected void Update()
		{
			_horizontalInput = Input.GetAxis("Horizontal1");
			_verticalInput = Input.GetAxis("Vertical1");
		}

		/// <summary>
		/// Move via Phyiscs smoothly on FixedUpdate
		/// </summary>
		protected void FixedUpdate()
		{
			// Move ---
			// Create a vector in the direction the tank is facing with a 
			// magnitude based on the input, speed and the time between frames.
			Vector3 movement = transform.forward * _verticalInput * Time.deltaTime *
				_configurationData.TankMoveSpeed;

			_rigidbody.MovePosition(_rigidbody.position + movement);

			// Turn ---
			// Determine the number of degrees to be turned based on the input,
			// speed and time between frames.
			float turn = _horizontalInput * Time.deltaTime *
				_configurationData.TankTurnSpeed;
			Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
			_rigidbody.MoveRotation(_rigidbody.rotation * turnRotation);
		}

		//  Methods ---------------------------------------
		public void AimAtTarget(Target target)
		{
			_turret.AimAtTarget(	_configurationData.TrajectoryAlgorithm, 
									target, _configurationData.BulletSpeed);
		}

		public void ShootAtTarget(Target target)
		{
			// Create bullet
			Bullet bullet = Instantiate<Bullet>(_bulletPrefab);
			bullet.Initialize(_configurationData);

			_turret.ShootAtTarget(	_configurationData.TrajectoryAlgorithm, 
									target, bullet, _configurationData.BulletSpeed);
		}

		//  Event Handlers --------------------------------
	}
}
