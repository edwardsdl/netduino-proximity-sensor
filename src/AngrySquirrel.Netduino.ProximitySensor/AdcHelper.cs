using Microsoft.SPOT.Hardware;

namespace AngrySquirrel.Netduino.ProximitySensor
{
    /// <summary>
    /// Represents a set of methods for converting between analog and digital voltages recorded from the Netduino's ADC (analog
    /// to digital converter)
    /// </summary>
    internal static class AdcHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Returns the digital voltage converted to an analog voltage
        /// </summary>
        /// <param name="digitalVoltage">
        /// A digital voltage
        /// </param>
        /// <returns>
        /// The digital voltage converted to an analog voltage
        /// </returns>
        public static double ToAnalogVoltage(int digitalVoltage)
        {
            // The Netduino Plus 2 has a 12 bit ADC whereas previous
            // versions had 10 bit ADCs. Because of this, the hardware
            // is checked and the appropriate maximum ADC value is used.
            var maxAdcValue = IsRunningOnNetduinoPlus2() ? 4095 : 1023;

            return 3.3d * digitalVoltage / maxAdcValue;
        }

        private static bool IsRunningOnNetduinoPlus2()
        {
            return SystemInfo.OEMString.IndexOf("Netduino Plus 2") >= 0;
        }

        #endregion
    }
}