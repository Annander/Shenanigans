using UnityEngine;

public interface IAgent
{
    Vector3 Position { get; }
    Vector3 Heading { get; }
    Vector3 Velocity { get; set; }
    float Radius { get; }
    void Register();
}