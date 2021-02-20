using RMC.Projects.Managers;
using RMC.TankGunTrajectory.Model;
using UnityEngine;

namespace RMC.TankGunTrajectory.View
{
	/// <summary>
	/// Handles aiming at <see cref="Target"/>.
	/// 
	/// NOTE: Contains the trigonometric math functions.
	/// 
	/// </summary>
	public class Turret : MonoBehaviour
	{
		//  Events ----------------------------------------

		//  Properties ------------------------------------
		public TurretBarrelBottom TurretBarrelBottom { get { return _turretBarrelBottom; }}
		public TurretBarrelTop TurretBarrelTop {get { return _turretBarrelTop; } }
		public Vector3 TurretBarrelAngle
		{
			get
			{
				return _turretBarrelTop.transform.position -
						_turretBarrelBottom.transform.position;
			}
		}


		//  Fields ----------------------------------------
		[SerializeField]
		private TurretBarrelBottom _turretBarrelBottom = null;

		[SerializeField]
		private TurretBarrelTop _turretBarrelTop = null;

		//  Unity Methods ---------------------------------
		protected void Update()
		{
			Debug.DrawRay(_turretBarrelBottom.transform.position,
							TurretBarrelAngle, Color.blue, 0.25f);
		}

		//  Methods ---------------------------------------
		public void AimAtTarget(ITrajectoryAlgorithm trajectoryAlgorithm, Target target, float bulletSpeed)
		{
			// Do math
			trajectoryAlgorithm.AimAtTarget(this, target, bulletSpeed);
		}

		public void ShootAtTarget(ITrajectoryAlgorithm trajectoryAlgorithm, Target target, Bullet bullet, float bulletSpeed)
		{
			// Play Audio
			SoundManager.Instance.PlayAudioClip(GameConstants.Sound.ShotFiring);

			// Do math
			trajectoryAlgorithm.ShootAtTarget(this, target, bullet, bulletSpeed);
		}
	}
}
