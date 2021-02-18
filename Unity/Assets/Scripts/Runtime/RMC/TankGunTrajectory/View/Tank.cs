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
			_turret.AimAtTarget(target, this._configurationData.BulletSpeed);
		}

		public void ShootBullet()
		{
			// Set position
			Bullet bullet = Instantiate<Bullet>(_bulletPrefab);
			
			// Set movement
			Vector3 bulletPosition = _turret.TurretBarrelBottom.transform.position;
			Vector3 bulletAngle = _turret.TurretBarrelAngle;
			float bulletSpeed = _configurationData.BulletSpeed;

			bullet.Shoot(bulletPosition, bulletAngle, bulletSpeed);
		}

		//  Event Handlers --------------------------------
	}
}
