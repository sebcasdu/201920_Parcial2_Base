using UnityEngine;
using AI;
namespace AI
{
    public abstract class SelectWithOption : Node
    {
        [SerializeField]
        public Group successTree;

        [SerializeField]
        private Group failTree;

        public abstract bool Check();

        public override void Execute()
        {
            if (Check())
            {
                successTree.Execute();
            }
            else
            {
                failTree.Execute();
            }
        }
    }
}