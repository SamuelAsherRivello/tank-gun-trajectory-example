using RMC.TankGunTrajectory.Model;
using System;
using System.Collections;
using UnityEngine;

namespace RMC.TankGunTrajectory.View
{
	//  Namespace Properties ------------------------------


	//  Class Attributes ----------------------------------


	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class Bullet : MonoBehaviour
	{
		//  Events ----------------------------------------


		//  Properties ------------------------------------


		//  Fields ----------------------------------------
		[SerializeField]
		private Rigidbody _rigidBody;

		private Coroutine _destroyAfterDelayCoroutine = null;

		//  Unity Methods ---------------------------------
		protected void OnDestroy()
		{
			 if (_destroyAfterDelayCoroutine != null)
			 {
				StopCoroutine(_destroyAfterDelayCoroutine);
			 }
		}

		//  Methods ---------------------------------------
		public void Shoot(Vector3 bulletAngle, float bulletSpeed, float bulletLifetime)
		{
			// Rotate bullet
			transform.transform.eulerAngles = bulletAngle;

			// Move bullet
			Vector3 force = bulletAngle * bulletSpeed;
			_rigidBody.AddForce(force, ForceMode.Force);

			// Destroy after time
			_destroyAfterDelayCoroutine = 
				StartCoroutine(DestroyAfterDelay(bulletLifetime));
		}

		private IEnumerator DestroyAfterDelay (float delay)
		{
			yield return new WaitForSeconds(delay);

			Destroy(gameObject);
		}

		//  Event Handlers --------------------------------
	}
}
