using System;
using Zenject;
using UnityEngine;

namespace Assets.Scripts.GridModule
{
    public class GridManagerFacade : MonoBehaviour, IInitializable, IDisposable
    {
        #region Variables

        [SerializeField][Min(2)] private int _gridSize = 2;

        #endregion Variables

        #region Functions

        public void GridManagerFacadeMonoConstructor()
        {

        }

        public void Initialize()
        {
            
        }

        public void Dispose()
        {
            
        }

        #endregion Functions
    }
}