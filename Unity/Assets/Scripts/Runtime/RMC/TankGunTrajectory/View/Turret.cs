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

			// Compute angle part that resembles the height difference between the tank (more specifically TurretBottom, which is where the bullet spawns) and the target
			var direction = target.transform.position - _turretBarrelBottom.transform.position;
			var flatDirection = new Vector3(direction.x, 0.0f, direction.z);
			var diffAngle = Vector3.Angle(direction, flatDirection);
			if (direction.y > 0.0f)
				diffAngle *= -1.0f;

			// Math #1 of 2 - Compute elevation angle
			// Assume a bullet speed and a height difference (given by diffAngle)
			var targetDistance = direction.magnitude;
			var elevationAngle = Mathf.Rad2Deg * Mathf.Atan((targetDistance * Mathf.Cos(diffAngle * Mathf.Deg2Rad) * Mathf.Abs(Physics.gravity.y)) / (2.0f * bulletSpeed * bulletSpeed));

            elevationAngle -= diffAngle;

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
