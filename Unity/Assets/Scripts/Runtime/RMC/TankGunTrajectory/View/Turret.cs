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
		/// GOAL: Aim the turret toward the target and set the barrel
		/// elevation angle DYNAMICALLY based on a hardcoded SPEED.
		/// 
		/// </summary>
		/// <param name="target"></param>
		public void AimAtTarget(Target target, float bulletSpeed)
		{
			float elevationAngle = GetElevationAngleToTarget(target, bulletSpeed);

			// Aim directly at X , Z. Use calculated Y.
			Vector3 targetPosition = new Vector3(
				target.transform.position.x,
				0.0f,
				target.transform.position.z);

			transform.LookAt(targetPosition);

			// FIXME: This only works when TurrentTop and TurrentBottom are at the same height in Prefab. This means they are not aligned with their 3D model.
			Vector3 transformEuler = transform.eulerAngles;
			transformEuler.x = -elevationAngle;
			transform.eulerAngles = transformEuler;
		}

		/// <summary>
		/// 
		/// Compute elevation angle to hit a target with given bullet speed and assuming that target is at the exact same height as the turret.
		/// 
		/// <see cref="https://answers.unity.com/questions/1169659/automatic-cannon-aiming.html"/>
		/// 
		/// </summary>
		private float GetElevationAngleToTarget(Target target, float bulletSpeed)
		{
			var direction = target.transform.position - transform.position;
			var targetDistance = direction.magnitude;
			var angle = Mathf.Rad2Deg * Mathf.Atan((targetDistance * Mathf.Abs(Physics.gravity.y)) / (2.0f * bulletSpeed * bulletSpeed));

			return angle;
		}
	}
}
