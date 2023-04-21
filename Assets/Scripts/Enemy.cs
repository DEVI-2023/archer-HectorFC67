using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {
        // Cuántas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;

        private Animator animator;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        public float minX = -5f;
        public float maxX = 5f;
        public float minZ = -5f;
        public float maxZ = 5f;

        private void Awake()
        {
            RespawnRandom();
            animator = GetComponent<Animator>();
        }

        private void RespawnRandom()
        {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            Vector3 spawnPosition = new Vector3(x, 0f, z);
            this.transform.position = spawnPosition;
        }

        // Método que se llamará cuando el enemigo reciba un impacto
        public void Hit()
        {
            this.animator.SetTrigger("Hit");
            hitPoints--;
        }

        private void Die()
        {
            this.animator.SetTrigger("Die");
        }

        private void OnTriggerEnter(Collider other)
        {
            Hit();
            if (hitPoints == 0)
            {
                Die();
                Destroy(this.gameObject, 2f);
                Vector3 transform = new Vector3(-235f, -206f, 176f);

                GameObject.FindGameObjectWithTag("Light").SetActive(false);

            }
        }

    }

}