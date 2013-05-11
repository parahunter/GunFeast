using UnityEngine;
using System.Collections;

public static class AudioExtensionMethod 
{

	public static void PlayWithRandomPitch(this AudioSource source, float min, float max)
	{
		source.pitch = Random.Range(min, max);
		source.Play();
	}
	
	
}
