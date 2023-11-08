using UnityEngine;

public class JumpState
    : IState
{
    private float _timer;
    private float _duration;
    private Transform _transform;

    private Vector3 _origin;
    private Vector3 _goal;

    public JumpState(Transform transform, float duration)
    {
        _transform = transform;
        _duration = duration;
    }
    
    public void OnEnter()
    {
        _origin = _transform.position;
        _goal = _transform.position + (Vector3.up * 20f);
        _timer = 0f;
    }

    public StateReturn OnUpdate()
    {
        _timer += Time.deltaTime;
        var T = _timer / _duration;

        _transform.position = Vector3.Lerp(_origin, _goal, T);

        if (T >= 1f)
            return StateReturn.Completed;
        
        return StateReturn.Running;
    }

    public void OnExit()
    {}
}