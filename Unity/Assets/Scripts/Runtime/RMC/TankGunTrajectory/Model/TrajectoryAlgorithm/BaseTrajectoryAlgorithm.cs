using RMC.TankGunTrajectory.View;
using UnityEngine;

namespace RMC.TankGunTrajectory.Model
{
	/// <summary>
	/// Defines parent. Each subclass contains one approach to all runtime math.
	/// </summary>
	public abstract class BaseTrajectoryAlgorithm : ScriptableObject, ITrajectoryAlgorithm
	{
		//  Other Methods ---------------------------------
		public abstract void ShootAtTarget(Turret turret, Target target, Bullet bullet, float bulletSpeed);
		public abstract void AimAtTarget(Turret turret, Target target, float bulletSpeed);
	}
}
