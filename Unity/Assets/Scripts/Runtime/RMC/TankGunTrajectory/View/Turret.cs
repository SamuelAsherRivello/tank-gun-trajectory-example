using System;
using UnityEngine;

namespace RMC.TankGunTrajectory.View
{
	//  Namespace Properties ------------------------------


	//  Class Attributes ----------------------------------


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
			get { 
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
			Debug.DrawRay(	_turretBarrelBottom.transform.position,
							TurretBarrelAngle, Color.blue, 0.25f); 
		}

		//  Methods ---------------------------------------

		//  Event Handlers --------------------------------
	}
}
