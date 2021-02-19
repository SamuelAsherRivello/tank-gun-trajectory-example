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
		private Camera _camera = null;

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
			// Hold Mouse To Move Target
			if (Input.GetMouseButton((int)_configurationData.MouseButtonToAim))
			{
				const float offset = 0.1f;
				RaycastHit hit;
				Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit))
				{
					_target.transform.position = hit.point - (ray.direction * offset);
				}
			}

			// Aim At Target 
			_tank.AimAtTarget(_target);

			// Shoot At Target
			if (Input.GetMouseButtonDown((int)_configurationData.MouseButtonToFire))
			{
				_tank.ShootBullet();
			}
		}

		//  Methods ---------------------------------------

		//  Event Handlers --------------------------------
	}
}
