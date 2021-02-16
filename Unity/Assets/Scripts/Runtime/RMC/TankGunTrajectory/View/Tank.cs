using RMC.TankGunTrajectory.Model;
using System;
using UnityEngine;

namespace RMC.TankGunTrajectory.View
{
	//  Namespace Properties ------------------------------


	//  Class Attributes ----------------------------------


	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class Tank : MonoBehaviour
	{
		//  Events ----------------------------------------


		//  Properties ------------------------------------


		//  Fields ----------------------------------------

		[Header ("Children")]
		[SerializeField]
		private Turret _turret = null;

		[Header("Prefabs")]
		[SerializeField]
		private Bullet _bulletPrefab = null;

		[Header("Configuration")]
		[SerializeField]
		private ConfigurationData _configurationData = null;

		//  Unity Methods ---------------------------------

		//  Methods ---------------------------------------
		public void AimAtTarget(Target target)
		{
			// Aim at X , Z. Keep existing Y.
			Vector3 targetPosition = new Vector3(
				target.transform.position.x,
				_turret.transform.position.y,
				target.transform.position.z);

			_turret.transform.LookAt(targetPosition);
		}

		public void ShootAtTarget(Target target)
		{
			// Set position
			Bullet bullet = Instantiate<Bullet>(_bulletPrefab);
			bullet.transform.position = _turret.TurretBarrelBottom.transform.position;

			// Set movement
			Vector3 bulletAngle = _turret.TurretBarrelAngle;
			float bulletSpeed = _configurationData.BulletSpeed;
			
			bullet.Shoot(bulletAngle, bulletSpeed, _configurationData.BulletLifetime);
		}

		//  Event Handlers --------------------------------
	}
}
