using UnityEngine;

namespace RMC.TankGunTrajectory.View
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	[ExecuteAlways]
	public class Turret : MonoBehaviour
	{
		//  Events ----------------------------------------

		//  Properties ------------------------------------
		public TurretBarrelBottom TurretBarrelBottom
		{
			get { return _turretBarrelBottom; }
		}

		public TurretBarrelTop TurretBarrelTop
		{
			get { return _turretBarrelTop; }
		}

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
		/// GOAL: Aim the turret toward the target and set the barrel
		/// elevation angle DYNAMICALLY based on a hardcoded SPEED.
		/// 
		/// </summary>
		/// <param name="target"></param>
		public void AimAtTarget(Target target)
		{
			float elevationAngle = GetElevationAngleToTarget(target);

			// Aim directly at X , Z. Use calculated Y.
			Vector3 targetPosition = new Vector3(
				target.transform.position.x,
				elevationAngle,
				target.transform.position.z);

			transform.LookAt(targetPosition);
		}

		/// <summary>
		/// TODO: FIXME. This does not work.
		/// 
		/// Ideas: Maybe passed... Speed? Gravity?
		/// 
		/// <see cref="https://answers.unity.com/questions/1169659/automatic-cannon-aiming.html"/>
		/// 
		/// </summary>
		private float GetElevationAngleToTarget(Target target)
		{
			// find the cannon->target vector:
			var dir = target.transform.position - transform.position;

			// create a horizontal version of it:
			var dirH = new Vector3(dir.x, 0, dir.z);

			// measure the unsigned angle between them:
			var ang = Vector3.Angle(dir, dirH);

			// add the signal (negative is below the cannon):
			return ang;
		}
	}
}
