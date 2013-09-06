namespace Game
{
    public class UserAction
    {
        public UserActionType ActionType { get; set; }
        public int Count { get; set; }

        public UserAction()
        {}

        public UserAction(UserActionType action, int count)
        {
            ActionType = action;
            Count = count;
        }
    }
}
