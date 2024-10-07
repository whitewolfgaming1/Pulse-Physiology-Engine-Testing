using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bhaptics.SDK2;

namespace Pulse.Unity
{
    public class PulseDataHapticsRenderer : PulseDataConsumer
    {
        public float yMin = 0f;                 // Data minimum value
        public float yMax = 100f;               // Data maximum value
        public float vibrationDuration = 500f;  // Each vibration lasts 500ms
        public int[] motorArray = new int[40];  // Array for motor intensities

        double previousTime = 0f;    // Used to determine dt and shift the line

        // Called when application or editor opens
        void Awake()
        {
            // Initialize the motor array (40 motors on the vest)
            for (int i = 0; i < motorArray.Length; i++)
            {
                motorArray[i] = 0;
            }
        }

        // Called when the component is being enabled
        void OnEnable()
        {
            
        }

        // Called when the component is being disabled
        void OnDisable()
        {
            BhapticsLibrary.StopAll();
        }

        // MARK: PulseDataConsumer methods

        // Consume pulse data
        override internal void UpdateFromPulse(DoubleList times, DoubleList values)
        {
            for (int i = 0; i < times.Count; ++i)
            {
                // Trigger haptic feedback based on heart rate data points
                ProcessPulseData(times.Get(i), values.Get(i));
            }
        }
        //

        // Process pulse data and trigger haptic feedback
        void ProcessPulseData(double time, double value)
        {
            // Calculate delta time to control the frequency of vibrations
            double deltaTime = time - previousTime;
            previousTime = time;

            // Map the heart rate value to motor intensity
            float normalizedValue = Mathf.Clamp((float)(value - yMin) / (yMax - yMin), 0f, 1f);
            int intensity = Mathf.RoundToInt(normalizedValue * 100);  // Map to 0-100 intensity

            /*int[] motorArray = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };*/

            for (int i = 0; i < motorArray.Length; i++)
            {
                motorArray[i] = intensity;  // Uniform intensity for all motors in this example
            }

            // Trigger the haptic feedback
            BhapticsLibrary.PlayMotors(
                (int)PositionType.Vest,  // Using the vest
                motorArray,              // Motor intensity array
                (int)vibrationDuration   // Duration in milliseconds   //250
            );
        }
    }
}

/* extra comments
 * - have to change data field every time (make permanent?)
 * - intensity too high?
 * - make just 1 motor
 */
