namespace AngrySquirrel.Netduino.ProximitySensor
{
    /// <summary>
    /// Represents a delegate for handling the <see cref="ProximitySensor.ObjectDetected" /> event
    /// </summary>
    /// <param name="sender">
    /// The sender of the <see cref="ProximitySensor.ObjectDetected" /> event
    /// </param>
    /// <param name="objectDetectedEventArgs">
    /// The event arguments containing distance information about the detected object
    /// </param>
    public delegate void ObjectDetectedEventHandler(object sender, ObjectDetectedEventArgs objectDetectedEventArgs);
}