using AngrySquirrel.Netduino.ProximitySensor;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Example
{
    /// <summary>
    /// Represents an example project showing how to use the <see cref="ProximitySensor" /> library
    /// </summary>
    public class Program
    {
        #region Public Methods and Operators

        /// <summary>
        /// Program entry point
        /// </summary>
        public static void Main()
        {
            var proximitySensorInput = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);

            var proximitySensor = new ProximitySensor(ProximitySensorType.GP2Y0A21YK, proximitySensorInput)
                {
                    IsEnabled = true, 
                    ObjectDetectionTrigger = (maximumReadableDistance, distance) => distance < maximumReadableDistance, 
                };
            proximitySensor.ObjectDetected += OnObjectDetected;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the <see cref="ProximitySensor.ObjectDetected"/>
        /// </summary>
        /// <param name="sender">
        /// The sender of the <see cref="ProximitySensor.ObjectDetected"/> event
        /// </param>
        /// <param name="objectDetectedEventArgs">
        /// The event arguments containing distance information about a detected object
        /// </param>
        private static void OnObjectDetected(object sender, ObjectDetectedEventArgs objectDetectedEventArgs)
        {
            Debug.Print("The current distance is " + objectDetectedEventArgs.Distance.ToInches() + "in.");
        }

        #endregion
    }
}