using RMC.TankGunTrajectory.View;

namespace RMC.TankGunTrajectory.Model
{
	public interface ITrajectoryAlgorithm
	{
		public void ShootAtTarget(Turret turret, Target target, Bullet bullet, float bulletSpeed);
		public void AimAtTarget(Turret turret, Target target, float bulletSpeed);
	}
}