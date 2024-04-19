using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.GridModule
{
    public class Grid : MonoBehaviour
    {
        #region Variables

        private bool _flag;

        [Header("Settings")]
        [SerializeField] private float _colorChangeDuration;
        [SerializeField] private Color _darkenColor;
        [SerializeField] private Color _lightenColor;

        [Header("Components")]
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
            _spriteRenderer.DOColor(_lightenColor, _colorChangeDuration);
        }

        private void Darken()
        {
            _spriteRenderer.DOColor(_darkenColor, _colorChangeDuration);
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