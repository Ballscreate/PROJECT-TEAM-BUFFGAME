using Mirror;
public abstract class State 
{
    protected readonly StateMachine stateMachine;

    public State(StateMachine stateMachine)
    {
       this.stateMachine = stateMachine;
    }
    
    public virtual void Enter() => UnityEngine.Debug.Log($"Enter {this.GetType().Name}");
   
    public virtual void Exit() => UnityEngine.Debug.Log($"Exit {this.GetType().Name}");
   
    public virtual void Update(){}
}
