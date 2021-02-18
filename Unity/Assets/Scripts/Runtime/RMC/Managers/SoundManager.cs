using RMC.DesignPatterns;
using System.Collections.Generic;
using UnityEngine;

namespace RMC.Projects.Managers
{
	/// <summary>
	/// Maintain a list of AudioSources and play the next 
	/// AudioClip on the first available AudioSource.
	/// </summary>
	public class SoundManager : SingletonMonobehavior<SoundManager>
	{
		[SerializeField]
		private List<AudioClip> _audioClips = new List<AudioClip>();

		[SerializeField]
		private List<AudioSource> _audioSources = new List<AudioSource>();

		/// <summary>
		/// Play the AudioClip by name.
		/// </summary>
		public void PlayAudioClip(string audioClipName)
		{
			foreach (AudioClip audioClip in _audioClips)
			{
				if (audioClip.name == audioClipName)
				{
					PlayAudioClip(audioClip);
					return;
				}
			}
		}

		/// <summary>
		/// Play the AudioClip by reference.
		/// If all sources are occupied, nothing will play.
		/// </summary>
		public void PlayAudioClip(AudioClip audioClip)
		{
			foreach (AudioSource audioSource in _audioSources)
			{
				if (!audioSource.isPlaying)
				{
					audioSource.clip = audioClip;
					audioSource.Play();
					//Debug.Log("PlayAudioClip() name: " + audioSource.clip.name);
					return;
				}
			}
		}
	}
}