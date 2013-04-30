using System;

namespace AngrySquirrel.Netduino.ProximitySensor
{
    /// <summary>
    /// Represents event arguments containing distance information about a proximity event
    /// </summary>
    public class ObjectDetectedEventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectDetectedEventArgs"/> class
        /// </summary>
        /// <param name="distance">
        /// The distance an object lies from the proximity sensor
        /// </param>
        /// <param name="dateTime">
        /// The date and time of the event
        /// </param>
        public ObjectDetectedEventArgs(Distance distance, DateTime dateTime)
        {
            Distance = distance;
            DateTime = dateTime;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the date and time of the event
        /// </summary>
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// Gets the distance an object lies from the proximity sensor
        /// </summary>
        public Distance Distance { get; private set; }

        #endregion
    }
}