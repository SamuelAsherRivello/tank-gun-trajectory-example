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

		[SerializeField]
		private ParticleSystem _particleSystem = null;

		private Coroutine _destroyAfterDelayCoroutine = null;

		//  Unity Methods ---------------------------------
		protected void Update()
		{
			_rigidBody.MoveRotation(
				Quaternion.Euler(transform.TransformDirection (Vector3.up)));

			_rigidBody.angularVelocity = new Vector3(0, 0, 0);

			// Play explosion when bullet is near the ground
			if (transform.position.y < 0.1f)
			{
				if (!_particleSystem.isPlaying)
				{
					_particleSystem.Play();
				}
			}
		}

		protected void OnDestroy()
		{
			if (_destroyAfterDelayCoroutine != null)
			{
				StopCoroutine(_destroyAfterDelayCoroutine);
			}
		}

		//  Methods ---------------------------------------
		public void Shoot(Vector3 bulletPosition, Vector3 bulletAngle,
							float bulletSpeed, float bulletLifetime)
		{
			// Debug drawing bullet
			Vector3 startPosition = bulletPosition;
			Vector3 endPosition = bulletPosition + bulletAngle * 3;

			Debug.DrawLine(startPosition,
					endPosition, Color.red, 4f);

			// Position bullet
			transform.position = startPosition;

			// Shoot with given velocity
			_rigidBody.velocity = bulletAngle.normalized * bulletSpeed;

			// Destroy after time
			_destroyAfterDelayCoroutine =
				StartCoroutine(DestroyAfterDelay(bulletLifetime));
		}

		private IEnumerator DestroyAfterDelay(float delay)
		{
			yield return new WaitForSeconds(delay);
			Destroy(gameObject);
		}

		//  Event Handlers --------------------------------
	}
}