using Interfaces;
using UnityEngine;

namespace Commands.Level
{
    public class OnLevelLoaderCommand : ICommand
    {
        private Transform _levelHolder;

        public OnLevelLoaderCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }
        
        public void Execute()
        {
        }

        public void Execute(int LevelID)
        {
            Object.Instantiate(Resources.Load<GameObject>($"Prefabs/LevelPrefebs/level{LevelID}"), _levelHolder);
        }
    }
}
