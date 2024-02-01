//The selected code is part of a Unity script that handles audio based on the time of day. It uses the time variable to determine the current time of day, and the dayLengthInSeconds variable to convert the time into an angle that represents the position of the sun in the sky.

//The UpdateAudio function uses the angle parameter to determine which audio clip should be played based on the current time of day. It checks if the current angle is less than 90 degrees, which means it's morning, and if the current audio clip is not the morning sound effect. If both conditions are true, the morning sound effect is played.

//The code continues to check for other time slots (day, evening, and night) and plays the appropriate sound effect if the current audio clip is not the correct one.

//Overall, the selected code is responsible for switching between different audio clips based on the time of day, and it does so by checking the current angle and the current audio clip.
using UnityEngine;

public class TimeOfDayAudio : MonoBehaviour
{
	public AudioClip morningSounds;
	public AudioClip daySounds;
	public AudioClip eveningSounds;
	public AudioClip nightSounds;
	
	private AudioSource audioSource;
	private float time;
	private float dayLengthInSeconds; // Ensure this variable is defined and initialized
	
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	void Update()
	{
		// Assuming 'time' is updated from the TimeOfDaySystem
		float timeOfDayAngle = (time / dayLengthInSeconds) * 360f;
		UpdateAudio(timeOfDayAngle);
	}
	
	void UpdateAudio(float angle)
	{
		if (angle < 90 && audioSource.clip != morningSounds)
		{
			audioSource.clip = morningSounds;
			audioSource.Play();
		}
		else if (angle < 180 && audioSource.clip != daySounds)
		{
			audioSource.clip = daySounds;
			audioSource.Play();
		}
		else if (angle < 270 && audioSource.clip != eveningSounds)
		{
			audioSource.clip = eveningSounds;
			audioSource.Play();
		}
		else if (audioSource.clip != nightSounds)
		{
			audioSource.clip = nightSounds;
			audioSource.Play();
		}
	}
}
