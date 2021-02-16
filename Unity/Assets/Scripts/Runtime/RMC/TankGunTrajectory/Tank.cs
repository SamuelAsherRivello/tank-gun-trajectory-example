using System;
using UnityEngine;

namespace RMC.TankGunTrajectory
{
	//  Namespace Properties ------------------------------


	//  Class Attributes ----------------------------------


	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class Tank : MonoBehaviour
	{
		//  Events ----------------------------------------


		//  Properties ------------------------------------


		//  Fields ----------------------------------------
		[SerializeField]
		private Turret _turret = null;


		//  Unity Methods ---------------------------------
		protected void Start()
		{

		}


		protected void Update()
		{

		}


		//  Methods ---------------------------------------
		public void AimAtTarget(Target target)
		{
			_turret.transform.LookAt(target.transform);
		}


		//  Event Handlers --------------------------------
		public void Target_OnCompleted(string message)
		{

		}
	}
}
