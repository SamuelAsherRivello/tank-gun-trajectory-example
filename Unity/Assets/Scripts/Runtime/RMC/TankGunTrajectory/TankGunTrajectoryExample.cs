using RMC.TankGunTrajectory.Model;
using RMC.TankGunTrajectory.View;
using UnityEngine;

namespace RMC.TankGunTrajectory
{
	//  Class Attributes ----------------------------------
	// This is a developer #protip to iterate faster on the aiming
	// code development without needing to hit 'Play'.
	//
	//	NOTE: Hitting 'Play' is indeed required for shooting.
	//
	[ExecuteAlways]

	/// <summary>
	/// Main entry-point to the project. Start reading here...
	/// </summary>
	public class TankGunTrajectoryExample : MonoBehaviour
	{
		//  Fields ----------------------------------------

		[Header ("Scene GameObjects")]
		[SerializeField]
		private Tank _tank = null;

		[SerializeField]
		private Target _target = null;

		[Header("Configuration")]
		[SerializeField]
		private ConfigurationData _configurationData = null;

		//  Unity Methods ---------------------------------

		protected void Update()
		{
			_tank.AimAtTarget(_target);

			if (Input.GetKeyDown (_configurationData.KeyCodeFireBullet))
			{
				_tank.ShootBullet();
			}
		}
		//  Methods ---------------------------------------

		//  Event Handlers --------------------------------
	}
}
