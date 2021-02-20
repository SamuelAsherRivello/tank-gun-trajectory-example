using RMC.TankGunTrajectory.View;
using UnityEngine;

namespace RMC.TankGunTrajectory.Model
{
	//  Class Fields --------------------------------------

	//  Class Attributes ----------------------------------
	[CreateAssetMenu (
		fileName = "TrajectoryAlgorithm01",
		menuName = "TankGunTrajectory/TrajectoryAlgorithm01",
		order = 0)]
	public class TrajectoryAlgorithm01 : BaseTrajectoryAlgorithm
	{
		//  Properties ------------------------------------

		//  Fields ----------------------------------------

		//  Other Methods ---------------------------------

		/// <summary>
		/// Aim the turret toward the target and set the barrel
		/// elevation angle DYNAMICALLY based on a hardcoded SPEED.
		/// </summary>
		public override void AimAtTarget(Turret turret, Target target, float bulletSpeed)
		{
			// Update Aim: considering only X & Z axes (easy)
			Vector3 targetPosition = new Vector3(
				target.transform.position.x,
				0.0f,
				target.transform.position.z);
			turret.transform.LookAt(targetPosition);

			// Compute angle part that resembles the height difference between the tank (more specifically TurretBottom, which is where the bullet spawns) and the target
			var direction = target.transform.position - turret.TurretBarrelBottom.transform.position;
			var flatDirection = new Vector3(direction.x, 0.0f, direction.z);
			var diffAngle = Vector3.Angle(direction, flatDirection);
			if (direction.y > 0.0f)
			{
				diffAngle *= -1.0f;
			}

			// //////////////////////////////////////////////
			// Math #1 of 2 - Compute elevation angle
			// Assume a bullet speed and a height difference (given by diffAngle)
			// //////////////////////////////////////////////
			var targetDistance = direction.magnitude;
			var elevationAngle = Mathf.Rad2Deg * Mathf.Atan((targetDistance * Mathf.Cos(diffAngle * Mathf.Deg2Rad) * Mathf.Abs(Physics.gravity.y)) / (2.0f * bulletSpeed * bulletSpeed));
			elevationAngle -= diffAngle;

			// Update Aim: Y Axis
			Vector3 transformEuler = turret.transform.eulerAngles;
			transformEuler.x = -elevationAngle;
			turret.transform.eulerAngles = transformEuler;
		}

		public override void ShootAtTarget(Turret turret, Target target, Bullet bullet, float bulletSpeed)
		{
			// Position bullet
			Vector3 bulletPosition = turret.TurretBarrelBottom.transform.position;
			bullet.transform.position = bulletPosition;

			// //////////////////////////////////////////////
			// Math #2 of 2 - Set initial velocity
			// //////////////////////////////////////////////
			bullet.Rigidbody.velocity = turret.TurretBarrelAngle.normalized * bulletSpeed;

			// Rotate bullet
			bullet.transform.LookAt(target.transform);
		}
	}
}
