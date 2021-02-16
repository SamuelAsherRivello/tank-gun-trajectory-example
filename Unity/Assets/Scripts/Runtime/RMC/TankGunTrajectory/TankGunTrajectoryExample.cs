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
		[SerializeField]
		private Tank _tank = null;

		[SerializeField]
		private Target _target = null;

		//  Unity Methods ---------------------------------

		protected void Update()
		{
			_tank.AimAtTarget(_target);
		}

		//  Methods ---------------------------------------

		//  Event Handlers --------------------------------
	}
}
