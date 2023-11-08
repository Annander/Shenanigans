using UnityEngine;

public class Obstacle : MonoBehaviour, 
    IAgent
{
    [SerializeField] private float radius;

    private void Awake()
    {
        Register();
    }

    public Vector3 Position
    {
        get => transform.position;
    }
    
    public Vector3 Heading { get; }
    public Vector3 Velocity { get; set; }

    public float Radius => radius;

    public void Register()
    {
        AgentManager.Instance.RegisterAgent(this);
    }
}