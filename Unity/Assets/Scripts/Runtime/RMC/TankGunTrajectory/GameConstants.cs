namespace RMC.TankGunTrajectory
{
	/// <summary>
	/// Store commonly-used values
	/// </summary>
	public static class GameConstants
	{
		//  Fields ----------------------------------------

		// Best Practice: Group constants in classes for nice organization
		public static SoundManagerConstants Sound = new SoundManagerConstants();
		public static TagConstants Tags = new TagConstants();
		public static float BulletLifetime = 3;
	}

	public class SoundManagerConstants
	{
		//  Fields ----------------------------------------
		public string BackgroundMusic = "BackgroundMusic";
		public string EngineDriving = "EngineDriving";
		public string EngineIdle = "EngineIdle";
		public string ShellExplosion = "ShellExplosion";
		public string ShotFiring = "ShotFiring";
		public string TankExplosion = "TankExplosion";
	}

	public class TagConstants
	{
		//  Fields ----------------------------------------
		public string PhysicsGround = "PhysicsGround";
	}
}
