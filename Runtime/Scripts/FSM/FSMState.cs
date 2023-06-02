
namespace MendiGames.Utils.FSM
{
    public class FSMState<T> where T : System.Enum
    {
        public T id { get; private set; }
        public string name { get; set; }

        public delegate void DelegateNoArg();
        public DelegateNoArg OnEnter;
        public DelegateNoArg OnExit;
        public DelegateNoArg OnUpdate;
        public DelegateNoArg OnFixedUpdate;

        public FSMState(T id)
        {
            this.id = id;
        }

        public FSMState(T controller, string name) : this(controller)
        {
            this.name = name;
        }

        
        public virtual void Enter() {
            OnEnter?.Invoke();
        }

        public virtual void Exit() {
            OnExit?.Invoke();
        }
        
        public virtual void Update() {
            OnUpdate?.Invoke();
        }

        public virtual void FixedUpdate() { 
            OnFixedUpdate?.Invoke();
        }
    }
}