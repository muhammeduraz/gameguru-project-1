using UnityEngine;

namespace Assets.Scripts.GridModule
{
    public struct SetupGridSignal
    {
        private int _size;
        public int Size { get => _size; }

        public SetupGridSignal(int size)
        {
            _size = size;
        }
    }
}