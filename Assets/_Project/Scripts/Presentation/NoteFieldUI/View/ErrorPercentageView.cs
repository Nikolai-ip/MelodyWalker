using System;
using System.Linq;
using _Project.Scripts.Domain.Entities;
using DG.Tweening;
using Plugins.DOTweenFramework;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Presentation.NoteFieldUI.View
{
    public class ErrorPercentageView: MonoBehaviour, IViewEnableable<ErrorPercentageViewData>
    {
        [SerializeField] private ErrorPercentagePhrasesData _errorPercentagePhrasesData;
        [SerializeField] private TweenAnimation _showAnimation;
        [SerializeField] private TextMeshProUGUI _succesStatusText;
        public void SetData(ErrorPercentageViewData data)
        {
            if (data.MelodyIsValid)
            {
                var phraseData = _errorPercentagePhrasesData.SuccessStatusPhrasesInspector
                    .FirstOrDefault(phrase => data.ErrorPercentage >= phrase.ErrorMinPercentage &&
                                              data.ErrorPercentage <= phrase.ErrorMaxPercentage);
                _succesStatusText.text = phraseData == null ? "" : phraseData.Phrase;
            }
            else
            {
                _succesStatusText.text = _errorPercentagePhrasesData.NotValidMelodyText;
            }
        }

        public void Show()
        {
            _showAnimation.Play();
        }

        public void Hide()
        {
            _showAnimation.Kill();
        }
    }

    public struct ErrorPercentageViewData
    {
        public float ErrorPercentage { get; }
        public bool MelodyIsValid { get; }

        public ErrorPercentageViewData(float errorPercentage, bool melodyIsValid)
        {
            ErrorPercentage = errorPercentage;
            MelodyIsValid = melodyIsValid;
        }
    }
}