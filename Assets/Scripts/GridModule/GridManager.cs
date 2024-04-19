using System;
using Zenject;

namespace Assets.Scripts.GridModule
{
    public class GridManager : IDisposable
    {
        #region Variables

        private SignalBus _signalBus;

        private Grid[,] _gridArray;
        private GridCreator _gridCreator;

        #endregion Variables

        #region Functions

        public GridManager(GridCreator gridCreator, SignalBus signalBus)
        {
            _signalBus = signalBus;
            _gridCreator = gridCreator;
            _gridArray = _gridCreator.CreateGrid(2);

            SetupGrid(2);

            _signalBus.Subscribe<SetupGridSignal>(OnSetupGridSignalFired);
        }

        public void Dispose()
        {
            _gridArray = null;
            _gridCreator = null;

            _signalBus.Unsubscribe<SetupGridSignal>(OnSetupGridSignalFired);
            _signalBus = null;
        }

        private void SetupGrid(int size)
        {
            _gridArray = _gridCreator.CreateGrid(size);
        }

        private void OnSetupGridSignalFired()
        {
            
        }

        #endregion Functions
    }
}