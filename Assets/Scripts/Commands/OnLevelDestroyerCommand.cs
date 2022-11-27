using Interfaces;
using UnityEngine;


namespace Command
{
    public class OnlevelDestroyerCommand : ICommand
    {
        private Transform _levelHolder;
        public OnlevelDestroyerCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }

        public void Execute()
        {
            Object.Destroy(_levelHolder.GetChild(0).gameObject);
        }

        public void Execute(int value)
        {
        }

    }
}