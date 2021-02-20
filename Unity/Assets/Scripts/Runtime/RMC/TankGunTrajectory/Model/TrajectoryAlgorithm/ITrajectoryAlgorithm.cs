using RMC.TankGunTrajectory.View;

namespace RMC.TankGunTrajectory.Model
{
	/// <summary>
	/// While not strictly required for this game demo, 
	/// the math has been moved to its own <see cref="ScriptableObject"/>
	/// so that (eventually) the project can contain more than one math 
	/// approach and users can drag and drop the <see cref="ScriptableAsset"/>
	/// to the <see cref="ConfigurationData"/>. 
	/// </summary>
	public interface ITrajectoryAlgorithm
	{
		public void ShootAtTarget(Turret turret, Target target, Bullet bullet, float bulletSpeed);
		public void AimAtTarget(Turret turret, Target target, float bulletSpeed);
	}
}