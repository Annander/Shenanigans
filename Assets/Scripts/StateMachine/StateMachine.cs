using System.Collections.Generic;

public class StateMachine
{
    // Stack is the LIFO (Last in, first out) structure
    private Stack<IState> stack = new ();

    public void PushState(IState newState)
    {
        if (stack.Count > 0)
        {
            var topState = stack.Peek();
        
            if (topState == newState)
                return;

            topState?.OnExit();            
        }
        
        newState.OnEnter();
        stack.Push(newState);
    }

    public void PopState()
    {
        if (stack.Count > 0)
        {
            var topState = stack.Peek();
            topState.OnExit();
            stack.Pop();

            var newTopState = stack.Peek();
            newTopState?.OnEnter();
        }
    }

    public void Update()
    {
        if (stack.Count > 0)
        {
            var topState = stack.Peek();
            var stateReturn = topState.OnUpdate();
            
            if(stateReturn == StateReturn.Completed)
                PopState();
        }
    }
    
#if UNITY_EDITOR
    public string CurrentState()
    {
        if(stack.Count > 0)
            return stack.Peek().ToString();

        return "None";
    }
#endif
}