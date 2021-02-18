using RMC.Projects.Managers;
using UnityEngine;

namespace RMC.TankGunTrajectory.View
{
	/// <summary>
	/// Handles aiming at <see cref="Target"/>.
	/// 
	/// NOTE: Contains the trigonometric math functions.
	/// 
	/// </summary>
	[ExecuteAlways]
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

		/// <summary>
		/// Aim the turret toward the target and set the barrel
		/// elevation angle DYNAMICALLY based on a hardcoded SPEED.
		/// </summary>
		public void AimAtTarget(Target target, float bulletSpeed)
		{
			// Update Aim: considering only X & Z axes (easy)
			Vector3 targetPosition = new Vector3(
				target.transform.position.x,
				0.0f,
				target.transform.position.z);
			transform.LookAt(targetPosition);

			// Math #1 of 2 - Compute elevation angle
			// Assume a bullet speed and assuming that target is at the 
			// exact same height as the turret.
			// <see cref="https://answers.unity.com/questions/1169659/automatic-cannon-aiming.html"/>
			var direction = target.transform.position - transform.position;
			var targetDistance = direction.magnitude;
			var elevationAngle = Mathf.Rad2Deg * Mathf.Atan((targetDistance * Mathf.Abs(Physics.gravity.y)) / (2.0f * bulletSpeed * bulletSpeed));

			// Update Aim: Y Axis
			Vector3 transformEuler = transform.eulerAngles;
			transformEuler.x = -elevationAngle;
			transform.eulerAngles = transformEuler;
		}

		public void ShootAtTarget(Bullet bullet, float bulletSpeed)
		{
			// Position bullet
			Vector3 bulletPosition = _turretBarrelBottom.transform.position;
			bullet.transform.position = bulletPosition;

			// Math #2 of 2 - Set initial velocity
			Vector3 bulletAngle = TurretBarrelAngle;
			bullet.RigidBody.velocity = bulletAngle.normalized * bulletSpeed;

			// Play Audio
			SoundManager.Instance.PlayAudioClip(GameConstants.Sound.ShotFiring);
		}
	}
}
