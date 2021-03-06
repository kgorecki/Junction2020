﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    private float speed = 10f;
    private float gravity = 0.01f;
    private AudioSource[] audioSource;

    public void Setup(Quaternion direction)
    {
        this.direction = Quaternion.AngleAxis(90, Vector3.up) * direction * Vector3.forward;
        // TODO: to be removed when catank model is loaded
        this.direction = Quaternion.AngleAxis(45, Vector3.right) * this.direction;
        Destroy(gameObject, 5f);

        audioSource = GetComponents<AudioSource>();
        audioSource[0].Play();
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        direction.y -= gravity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.name == "Placeholder Enemy")
        {
            int score = PlayerPrefs.GetInt("TOTALSCORE");
            PlayerPrefs.SetInt("TOTALSCORE", score + 1);
            audioSource[1].Play();
        }
    }
}
