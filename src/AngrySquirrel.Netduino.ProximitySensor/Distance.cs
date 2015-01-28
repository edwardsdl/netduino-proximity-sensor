using System;

namespace AngrySquirrel.Netduino.ProximitySensor
{
    /// <summary>
    /// Represents a distance an object lies from the Sharp GP2Y0A21YK proximity sensor
    /// </summary>
    public class Distance : IComparable
    {
        #region Fields

        private readonly double analogVoltage;

        private readonly int digitalVoltage;

        private readonly ProximitySensorType proximitySensorType;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Distance"/> class
        /// </summary>
        /// <param name="digitalVoltage">
        /// The digital output voltage from the proximity sensor
        /// </param>
        /// <param name="proximitySensorType">
        /// The type of Sharp proximity sensor being used
        /// </param>
        internal Distance(int digitalVoltage, ProximitySensorType proximitySensorType)
        {
            analogVoltage = AdcHelper.ToAnalogVoltage(digitalVoltage);
            this.digitalVoltage = digitalVoltage;
            this.proximitySensorType = proximitySensorType;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the first <see cref="Distance" /> is equal to the second <see cref="Distance" />
        /// </summary>
        /// <param name="firstDistance">
        /// The first distance
        /// </param>
        /// <param name="secondDistance">
        /// The second distance
        /// </param>
        /// <returns>
        /// A value indicating whether the first <see cref="Distance" /> is equal to the second <see cref="Distance" />
        /// </returns>
        public static bool operator ==(Distance firstDistance, Distance secondDistance)
        {
            // This is cast to an object because otherwise this function will be invoked again causing
            // an infinite loop.
            if ((object)firstDistance == null)
            {
                return false;
            }

            if ((object)secondDistance == null)
            {
                return false;
            }

            return firstDistance.CompareTo(secondDistance) == 0;
        }

        /// <summary>
        /// Determines whether the first <see cref="Distance" /> is greater than the second <see cref="Distance" />
        /// </summary>
        /// <param name="firstDistance">
        /// The first distance
        /// </param>
        /// <param name="secondDistance">
        /// The second distance
        /// </param>
        /// <returns>
        /// A value indicating whether the first <see cref="Distance" /> is greater than the second <see cref="Distance" />
        /// </returns>
        public static bool operator >(Distance firstDistance, Distance secondDistance)
        {
            return firstDistance.CompareTo(secondDistance) > 0;
        }

        /// <summary>
        /// Determines whether the first <see cref="Distance" /> is less than or equal to the second <see cref="Distance" />
        /// </summary>
        /// <param name="firstDistance">
        /// The first distance
        /// </param>
        /// <param name="secondDistance">
        /// The second distance
        /// </param>
        /// <returns>
        /// A value indicating whether the first <see cref="Distance" /> is less than or equal to the second
        ///     <see cref="Distance" />
        /// </returns>
        public static bool operator >=(Distance firstDistance, Distance secondDistance)
        {
            return firstDistance.CompareTo(secondDistance) >= 0;
        }

        /// <summary>
        /// Determines whether the first <see cref="Distance" /> is not equal to the second <see cref="Distance" />
        /// </summary>
        /// <param name="firstDistance">
        /// The first distance
        /// </param>
        /// <param name="secondDistance">
        /// The second distance
        /// </param>
        /// <returns>
        /// A value indicating whether the first <see cref="Distance" /> is not equal to the second <see cref="Distance" />
        /// </returns>
        public static bool operator !=(Distance firstDistance, Distance secondDistance)
        {
            if (firstDistance == null)
            {
                return false;
            }

            return firstDistance.CompareTo(secondDistance) != 0;
        }

        /// <summary>
        /// Determines whether the first <see cref="Distance" /> is less than the second <see cref="Distance" />
        /// </summary>
        /// <param name="firstDistance">
        /// The first distance
        /// </param>
        /// <param name="secondDistance">
        /// The second distance
        /// </param>
        /// <returns>
        /// A value indicating whether the first <see cref="Distance" /> is less than the second <see cref="Distance" />
        /// </returns>
        public static bool operator <(Distance firstDistance, Distance secondDistance)
        {
            return firstDistance.CompareTo(secondDistance) < 0;
        }

        /// <summary>
        /// Determines whether the first <see cref="Distance" /> is greater than or equal to the second <see cref="Distance" />
        /// </summary>
        /// <param name="firstDistance">
        /// The first distance
        /// </param>
        /// <param name="secondDistance">
        /// The second distance
        /// </param>
        /// <returns>
        /// A value indicating whether the first <see cref="Distance" /> is greater than or equal to the second <see cref="Distance" />
        /// </returns>
        public static bool operator <=(Distance firstDistance, Distance secondDistance)
        {
            return firstDistance.CompareTo(secondDistance) <= 0;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the
        /// current instance precedes, follows, or occurs in the same position in the sort order as the other object
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance
        /// </param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared
        /// </returns>
        public int CompareTo(object obj)
        {
            var distance = obj as Distance;
            if (distance == null)
            {
                throw new ArgumentException("The given object is not of type Distance");
            }

            var difference = digitalVoltage - distance.digitalVoltage;

            return difference == 0
                ? 0
                : -(difference / Math.Abs(difference));
        }

        /// <summary>
        /// Determines whether the specified <see cref="Object"/> is equal to the current <see cref="Object"/>
        /// </summary>
        /// <param name="obj">
        /// The <see cref="Object"/> to compare with the current <see cref="Object"/>
        /// </param>
        /// <returns>
        /// <value>
        /// true
        ///     </value>
        /// if the specified <see cref="Object"/> is equal to the current <see cref="Object"/>; otherwise,
        ///     <value>
        /// false
        ///     </value>
        /// </returns>
        public override bool Equals(object obj)
        {
            return this == obj as Distance;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Distance"/> is equal to the current <see cref="Distance"/>
        /// </summary>
        /// <param name="distance">
        /// The <see cref="Distance"/> to compare with the current <see cref="Distance"/>
        /// </param>
        /// <returns>
        /// <value>
        /// true
        ///     </value>
        /// if the specified <see cref="Distance"/> is equal to the current <see cref="Distance"/>; otherwise,
        ///     <value>
        /// false
        ///     </value>
        /// </returns>
        public bool Equals(Distance distance)
        {
            return Equals(distance as object);
        }

        /// <summary>
        /// Serves as a hash function for a particular type
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="Distance" />
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (int)analogVoltage ^ digitalVoltage;
            }
        }

        /// <summary>
        /// Returns the distance in centimeters
        /// </summary>
        /// <returns>
        /// The distance in centimeters
        /// </returns>
        public double ToCentimeters()
        {
            return DistanceHelper.ToCentimeters(analogVoltage, proximitySensorType);
        }

        /// <summary>
        /// Returns the distance in inches
        /// </summary>
        /// <returns>
        /// The distance in inches
        /// </returns>
        public double ToInches()
        {
            return DistanceHelper.ToInches(analogVoltage, proximitySensorType);
        }

        #endregion
    }
}