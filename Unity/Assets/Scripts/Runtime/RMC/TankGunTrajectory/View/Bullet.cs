using RMC.Projects.Managers;
using RMC.TankGunTrajectory.Model;
using System.Collections;
using UnityEngine;

namespace RMC.TankGunTrajectory.View
{
	/// <summary>
	/// Bullet flight, collision, and destruction
	/// </summary>
	public class Bullet : MonoBehaviour
	{
		//  Properties ----------------------------------------
		public Rigidbody RigidBody { get { return _rigidBody; } }

		//  Fields ----------------------------------------
		[SerializeField]
		private Rigidbody _rigidBody;

		[SerializeField]
		private ParticleSystem _particleSystem = null;

		[Header("Configuration")]
		[SerializeField]
		private ConfigurationData _configurationData = null;

		private Coroutine _destroyAfterDelayCoroutine = null;
		private bool _hasExplosionStarted = false;


		//  Unity Methods ---------------------------------
		protected void Start()
		{
			// Best Practice: Destroy after x seconds
			// to reduce Scene Hierarcy's clutter
			_destroyAfterDelayCoroutine =
				StartCoroutine(DestroyAfterDelay(_configurationData.BulletLifetime));
		}

		protected void Update()
		{
			_rigidBody.MoveRotation(
				Quaternion.Euler(transform.TransformDirection (Vector3.up)));

			_rigidBody.angularVelocity = new Vector3(0, 0, 0);
		}

		protected void OnDestroy()
		{
			// Best Practice: If the scene ends, before the coroutine 
			// finishes, clean up nicely here.
			if (_destroyAfterDelayCoroutine != null)
			{
				StopCoroutine(_destroyAfterDelayCoroutine);
			}
		}

		//  Methods ---------------------------------------

		private void ExplodeSafe()
		{
			if (!_hasExplosionStarted)
			{
				_hasExplosionStarted = true;
				SoundManager.Instance.PlayAudioClip(GameConstants.Sound.ShellExplosion);
				_particleSystem.Play();
			}
		}


		private IEnumerator DestroyAfterDelay(float delay)
		{
			yield return new WaitForSeconds(delay);
			Destroy(gameObject);
		}

		//  Event Handlers --------------------------------
		protected void OnTriggerEnter(Collider collider)
		{
			if (collider.gameObject.CompareTag(GameConstants.Tags.PhysicsGround))
			{
				ExplodeSafe();
			}
		}
	}
}