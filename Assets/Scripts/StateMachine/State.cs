public interface IState
{
    void OnEnter();
    StateReturn OnUpdate();
    void OnExit();
}