using System;
using System.Collections;
using _Project.Scripts.Application.UseCases.Enemy;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Domain.Services;
using _Project.Scripts.Infrastructure.Configs;
using _Project.Scripts.Infrastructure.Input;
using Plugins.DOTweenFramework;
using UnityEngine;
using Zenject;

namespace Assets._Project.Scripts.Application.UseCases
{
    public class TutorialLabelTrigger : MonoBehaviour
    {

        [SerializeField] private TweenAnimation _tutorailLableAnim;
        [SerializeField] private GameObject _tutorialLabel;
        [SerializeField] private Melody_SO _melody_SO;
        private SpellRunner _spellRunner;
        [SerializeField] private GameObject _walls;

        [Inject]
        public void Construct(SpellRunner spellRunner)
        {
            _spellRunner = spellRunner;
        }
        private void OnEnable()
        {
            _spellRunner.OnMelodySpellCastSuccess += OnSpellCasted;
        }
        private void OnDisable()
        {
            _spellRunner.OnMelodySpellCastSuccess -= OnSpellCasted;
        }

        private void OnSpellCasted(Melody melody)
        {
            if (melody.Equals(_melody_SO.GetMelody()))
            {
                //Tutorial passed
                _tutorialLabel.SetActive(false);
                _walls.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerTag>(out var player))
           
                StartTutorial();
            
        }
        private void StartTutorial()
        {
            _tutorialLabel.SetActive(true);
            _tutorailLableAnim.Play();
            _walls.SetActive(true);
        }
    }
}