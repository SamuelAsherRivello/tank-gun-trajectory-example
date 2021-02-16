using RMC.TankGunTrajectory.Model;
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
			_turret.AimAtTarget(target);
		}

		public void ShootBullet()
		{
			// Set position
			Bullet bullet = Instantiate<Bullet>(_bulletPrefab);
			
			// Set movement
			Vector3 bulletPosition = _turret.TurretBarrelBottom.transform.position;
			Vector3 bulletAngle = _turret.TurretBarrelAngle;
			float bulletSpeed = _configurationData.BulletSpeed;
			float bulletLifetime = _configurationData.BulletLifetime;

			bullet.Shoot(bulletPosition, bulletAngle, bulletSpeed, bulletLifetime);
		}

		//  Event Handlers --------------------------------
	}
}
