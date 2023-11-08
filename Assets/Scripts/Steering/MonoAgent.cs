using UnityEngine;

public class MonoAgent : MonoBehaviour,
    IAgent
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        Register();
    }

    private void Update()
    {
        if (target)
        {
            var toTarget = target.position - Position;
            var movement = toTarget.normalized * moveSpeed;
            Velocity = movement;
            
            Position += Velocity * Time.deltaTime;
            _transform.forward = Heading;
        }
    }

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    public Vector3 Heading
    {
        get => Velocity.normalized;
    }

    public Vector3 Velocity
    { get; set; }

    public float Radius { get; }

    public void Register()
    {
        AgentManager.Instance.RegisterAgent(this);
    }

    private void OnDrawGizmos()
    {
        if(!Application.isPlaying)
            return;
        
        var allObstacles = AgentManager.Instance.GetAgentsOfType<Obstacle>();

        foreach (var obstacle in allObstacles)
        {
            Gizmos.DrawSphere(obstacle.Position, obstacle.Radius);
        }
    }
}