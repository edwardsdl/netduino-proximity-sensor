using System;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace AngrySquirrel.Netduino.ProximitySensor
{
    /// <summary>
    /// Represents a Sharp GP2Y0A21YK proximity sensor
    /// </summary>
    public class ProximitySensor
    {
        #region Fields

        /// <summary>
        /// Gets the maximum readable distance of the proximity sensor
        /// </summary>
        public readonly Distance MaximumReadableDistance;

        private readonly ProximitySensorType proximitySensorType;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProximitySensor"/> class
        /// </summary>
        /// <param name="proximitySensorType">
        /// </param>
        /// <param name="analogInput">
        /// The analog input to which the proximity sensor is attached
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the given <see cref="AnalogInput"/> is null
        /// </exception>
        /// <remarks>
        /// This sensor is only provides valid results for objects farther than 3" away or objects closer than
        /// <see cref="MaximumReadableDistance"/> from the sensor. Passing a trigger which attempts to obtain
        /// distances outside of this range will result in a large number of false positives.
        /// </remarks>
        public ProximitySensor(ProximitySensorType proximitySensorType, AnalogInput analogInput)
        {
            if (analogInput == null)
            {
                throw new ArgumentNullException("analogInput");
            }

            this.proximitySensorType = proximitySensorType;

            MaximumReadableDistance = GetMaximumReadableDistance(analogInput);

            new Thread(() =>
                {
                    while (true)
                    {
                        if (IsEnabled && ObjectDetectionTrigger != null)
                        {
                            var distance = new Distance(analogInput.ReadRaw(), proximitySensorType);

                            if (ObjectDetectionTrigger(MaximumReadableDistance, distance))
                            {
                                if (ObjectDetected != null)
                                {
                                    ObjectDetected(this, new ObjectDetectedEventArgs(distance, DateTime.UtcNow));
                                }
                            }
                        }

                        Thread.Sleep(10);
                    }
                }).Start();
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Occurs when the conditions given by the ProximityEventTrigger have been satisfied
        /// </summary>
        public event ObjectDetectedEventHandler ObjectDetected;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the proximity sensor is enabled
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the delegate for triggering the <see cref="ProximitySensor.ObjectDetected" /> event
        /// </summary>
        public ObjectDetectionTrigger ObjectDetectionTrigger { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Determines the maximum distance the proximity sensor can detect an object
        /// </summary>
        /// <param name="analogInput">
        /// The analog input to which the proximity sensor is attached
        /// </param>
        /// <returns>
        /// The maximum distance the proximity sensor can detect an object
        /// </returns>
        private Distance GetMaximumReadableDistance(AnalogInput analogInput)
        {
            var calibrationStartTime = DateTime.Now;
            var peakDigitalVoltage = 0;
            while (DateTime.Now <= calibrationStartTime.AddSeconds(3))
            {
                var digitalVoltage = analogInput.ReadRaw();
                peakDigitalVoltage = digitalVoltage > peakDigitalVoltage
                    ? digitalVoltage
                    : peakDigitalVoltage;
            }

            return new Distance(peakDigitalVoltage, proximitySensorType);
        }

        #endregion
    }
}