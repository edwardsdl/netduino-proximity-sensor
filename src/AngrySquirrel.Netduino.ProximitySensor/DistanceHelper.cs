using System;

namespace AngrySquirrel.Netduino.ProximitySensor
{
    /// <summary>
    /// Represents a set of methods for calculating distance based on the analog voltage output from a Sharp GP2Y0A21YK
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
        /// <returns>
        /// The distance an object lies from the proximity sensor measured in centimeters
        /// </returns>
        public static double ToCentimeters(double analogVoltage)
        {
            return 41.543 * Math.Pow(analogVoltage + 0.30221, -1.5281);
        }

        /// <summary>
        /// Converts an analog voltage output from a proximity sensor to a distance in inches
        /// </summary>
        /// <param name="analogVoltage">
        /// An analog voltage output from a proximity sensor
        /// </param>
        /// <returns>
        /// The distance an object lies from the proximity sensor measured in inches
        /// </returns>
        public static double ToInches(double analogVoltage)
        {
            return ToCentimeters(analogVoltage) / 2.54;
        }

        #endregion
    }
}