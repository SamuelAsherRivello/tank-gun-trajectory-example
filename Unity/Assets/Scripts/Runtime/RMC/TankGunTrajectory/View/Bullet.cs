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
		public Rigidbody Rigidbody { get { return _rigidbody; } }

		//  Fields ----------------------------------------
		[SerializeField]
		private Rigidbody _rigidbody;

		[SerializeField]
		private ParticleSystem _particleSystem = null;

		private bool _isInitialized = false;
		private ConfigurationData _configurationData = null;
		private Coroutine _destroyAfterDelayCoroutine = null;
		private bool _hasExplosionStarted = false;

		//  Initializer Methods ---------------------------
		public void Initialize(ConfigurationData configurationData)
		{
			_isInitialized = true;
			_configurationData = configurationData;
		}

		//  Unity Methods ---------------------------------
		protected void Start()
		{
			if (!_isInitialized)
			{
				return;
			}

			// Best Practice: Destroy after x seconds
			// to reduce Scene Hierarcy's clutter
			_destroyAfterDelayCoroutine =
				StartCoroutine(DestroyAfterDelay(_configurationData.BulletLifetime));
		}

		protected void OnDestroy()
		{
			if (!_isInitialized)
			{
				return;
			}

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
			if (!_isInitialized)
			{
				return;
			}

			if (!_hasExplosionStarted)
			{
				_hasExplosionStarted = true;
				SoundManager.Instance.PlayAudioClip(GameConstants.Sound.ShellExplosion);
				_particleSystem.Play();
			}
		}


		private IEnumerator DestroyAfterDelay(float delay)
		{
			if (!_isInitialized)
			{
				yield return null;
			}

			yield return new WaitForSeconds(delay);
			Destroy(gameObject);
		}

		//  Event Handlers --------------------------------
		protected void OnTriggerEnter(Collider collider)
		{
			if (!_isInitialized)
			{
				return;
			}

			if (collider.gameObject.CompareTag(GameConstants.Tags.PhysicsGround))
			{
				ExplodeSafe();
			}
		}
	}
}