using UnityEngine;

public class Mover : MonoBehaviour
{
    // Finite State Machine
    private StateMachine fsm = new();

    private JumpState _jumpState;

    private void Awake()
    {
        var state = GetComponent<IState>();

        _jumpState = new JumpState(transform, 5f);
        
        fsm.PushState(state);
        fsm.PushState(_jumpState);
    }

    private void Update()
    {
        fsm.Update();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.Label(transform.position, fsm.CurrentState());
    }    
#endif
}