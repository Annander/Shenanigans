using UnityEngine;

public class Rotator : MonoBehaviour, 
    IState
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private FloatVariable baseSpeed;

    public void OnEnter()
    {
        Debug.Log("Rotator state started!");
    }

    public StateReturn OnUpdate()
    {
        transform.Rotate(
            Vector3.up, 
            (baseSpeed.Value * rotationSpeed) * Time.deltaTime
        );

        return StateReturn.Running;
    }

    public void OnExit()
    {
        Debug.Log("Rotator state ended!");
    }
}