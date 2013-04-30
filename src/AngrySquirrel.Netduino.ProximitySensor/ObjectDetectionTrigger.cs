namespace AngrySquirrel.Netduino.ProximitySensor
{
    /// <summary>
    /// Represents a delegate for triggering the <see cref="ProximitySensor.ObjectDetected" /> event
    /// </summary>
    /// <param name="maximumReadableDistance">
    /// The maximum readable distance of the proximity sensor
    /// </param>
    /// <param name="distance">
    /// The distance an object lies from the proximity sensor
    /// </param>
    /// <returns>
    /// A value indicating whether the <see cref="ProximitySensor.ObjectDetected" /> event should be triggered
    /// </returns>
    public delegate bool ObjectDetectionTrigger(Distance maximumReadableDistance, Distance distance);
}