using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pulse.Unity;
using Bhaptics.SDK2;

public class PulseManager : MonoBehaviour
{
    private PulseEngineDriver pulseEngineDriver;

    private void Start()
    {
        // Attach PulseEngineDriver to this GameObject
        pulseEngineDriver = gameObject.AddComponent<PulseEngineDriver>();

        // No need to manually call Start() - Unity will handle that
    }
    /*
    private void Update()
    {
        // Fetch heart rate and apply feedback
        float heartRate = pulseEngineDriver.GetHeartRate();
        //Debug.Log("Current Heart Rate: " + heartRate); // Log heart rate for debugging
        ApplyHeartRateFeedback(heartRate);
    }

    public void ApplyHeartRateFeedback(float heartRate)
    {
        int intensity = CalculateHapticIntensity(heartRate);
        //Debug.Log("Calculated Haptic Intensity: " + intensity); // Log intensity for debugging
        ApplyHapticFeedback(intensity);
    }

    private int CalculateHapticIntensity(float heartRate)
    {
        // Add logic to map heart rate to haptic intensity
        // This is just an example; adjust it to your needs.
        return Mathf.Clamp(Mathf.RoundToInt(heartRate / 2), 0, 100);
    }

    private void ApplyHapticFeedback(int intensity)
    {
        // Use BhapticsLibrary.PlayMotors to apply feedback
        int[] MotorValueArray = new int[40];  // Assuming a 40-motor vest
        MotorValueArray[0] = intensity; // Vibrate only the specific motor at index 0

        BhapticsLibrary.PlayMotors(
            (int)PositionType.Vest, // Device type
            MotorValueArray,        // Haptic intensities
            500                     // Haptic duration (millisecond)
        );
        //Debug.Log("Haptic Feedback Applied: " + intensity); // Log feedback application for debugging
    }*/
}
