using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;

namespace Assets.Scripts.GridModule
{
    public class Grid : MonoBehaviour
    {
        #region Variables

        private bool _flagged;

        [Header("Settings")]
        [SerializeField] private int2 _index;

        [Header("Settings")]
        [SerializeField] private float _colorChangeDuration;
        [SerializeField] private Color _darkenColor;
        [SerializeField] private Color _lightenColor;

        [Header("Components")]
        [SerializeField] private SpriteRenderer _xRenderer;
        [SerializeField] private SpriteRenderer _backgroundRenderer;

        #endregion Variables
        
        #region Properties

        public bool Flagged { get => _flagged; }
        public int2 Index { get => _index; set => _index = value; }

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
            _flagged = true;
            _xRenderer.enabled = true;
        }

        public void SetAsUnflagged()
        {
            _flagged = false;
            _xRenderer.enabled = false;
        }

        private void Lighten()
        {
            _backgroundRenderer.DOColor(_lightenColor, _colorChangeDuration);
        }

        private void Darken()
        {
            _backgroundRenderer.DOColor(_darkenColor, _colorChangeDuration);
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