using RMC.TankGunTrajectory.Model;
using RMC.TankGunTrajectory.View;
using UnityEngine;

namespace RMC.TankGunTrajectory
{
	//  Namespace Properties ------------------------------


	//  Class Attributes ----------------------------------


	/// <summary>
	/// Replace with comments...
	/// </summary>
	[ExecuteAlways]
	public class TankGunTrajectoryExample : MonoBehaviour
	{
		//  Events ----------------------------------------


		//  Properties ------------------------------------

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
