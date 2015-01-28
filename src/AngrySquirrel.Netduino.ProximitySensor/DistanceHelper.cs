using System;

namespace AngrySquirrel.Netduino.ProximitySensor
{
    /// <summary>
    /// Represents a set of methods for calculating distance based on the analog voltage output from a Sharp
    /// proximity sensor
    /// </summary>
    internal static class DistanceHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts an analog voltage output from a proximity sensor to a distance in centimeters
        /// </summary>
        /// <param name="analogVoltage">
        /// An analog voltage output from a proximity sensor
        /// </param>
        /// <param name="proximitySensorType">
        /// The type of Sharp proximity sensor being used
        /// </param>
        /// <returns>
        /// The distance an object lies from the proximity sensor measured in centimeters
        /// </returns>
        public static double ToCentimeters(double analogVoltage, ProximitySensorType proximitySensorType)
        {
            double distance = 0;

            switch (proximitySensorType)
            {
                case ProximitySensorType.GP2Y0A21YK:
                    distance = 41.543 * Math.Pow(analogVoltage + 0.30221, -1.5281);;
                    break;
                case ProximitySensorType.GP2Y0A02YK0F:
                    distance = 61.681 * Math.Pow(analogVoltage, -1.133);
                    break;
            }

            return distance;
        }

        /// <summary>
        /// Converts an analog voltage output from a proximity sensor to a distance in inches
        /// </summary>
        /// <param name="analogVoltage">
        /// An analog voltage output from a proximity sensor
        /// </param>
        /// <param name="proximitySensorType">
        /// The type of Sharp proximity sensor being used
        /// </param>
        /// <returns>
        /// The distance an object lies from the proximity sensor measured in inches
        /// </returns>
        public static double ToInches(double analogVoltage, ProximitySensorType proximitySensorType)
        {
            return ToCentimeters(analogVoltage, proximitySensorType) / 2.54;
        }

        #endregion
    }
}