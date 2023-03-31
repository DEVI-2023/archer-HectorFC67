using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {

        // Cuántas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;

        private Animator animator;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // Método que se llamará cuando el enemigo reciba un impacto
        public void Hit()
        {
            animator.SetTrigger("Hit");
            OnScoreAdded.Invoke(10);
            hitPoints--;
            if(hitPoints <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            animator.SetTrigger("Die");
            OnScoreAdded.Invoke(30);
            Destroy(gameObject, 3);
        }
    }

}