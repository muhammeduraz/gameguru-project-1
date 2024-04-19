using UnityEngine;

namespace Assets.Scripts.GridModule
{
    public class Grid : MonoBehaviour
    {
        #region Variables

        private bool _flag;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        #endregion Variables
        
        #region Properties

        public bool Flag { get => _flag; }

        #endregion Properties

        #region Functions

        public void Initialize()
        {

        }

        public void Terminate()
        {

        }

        public void SetAsFlagged()
        {
            _flag = true;
        }

        public void SetAsUnflagged()
        {
            _flag = false;
        }

        private void Lighten()
        {

        }

        private void Darken()
        {

        }

        public void OnHoverEnter()
        {
            Darken();
        }

        public void OnHoverExit()
        {
            Lighten();
        }

        #endregion Functions
    }
}