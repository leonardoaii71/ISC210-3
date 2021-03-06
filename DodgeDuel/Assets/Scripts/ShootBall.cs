﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    
    public GameObject ball;
    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private Vector3 direccion;
    public float speed = 10f;
    private LaunchLine launchline;
    public GameController gameController;
    
    public void Awake()
    {
        //todo refactor
        launchline = GetComponent<LaunchLine>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition  = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * 5;

        if (Input.GetMouseButtonDown(0)) {
            //posición inicial cuando se presiona el botón del mouse
            posicionInicial = mousePosition;
            launchline.SetStartPoint(transform.position);
            //didClick = true;
        }
        else if (Input.GetMouseButton(0)) {
            //cuando el botón está presionado
            posicionFinal = mousePosition;
            direccion = posicionFinal - posicionInicial;
            launchline.SetEndPoint(transform.position - direccion);
        }
        else if (Input.GetMouseButtonUp(0)) {
            EndDrag();
        }
    }
    private void EndDrag()
    {
        
        direccion.Normalize();
        //ball = Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y + 5), transform.rotation);
        ball.transform.position = transform.position;
        ball.gameObject.SetActive(true);
        ball.GetComponent<Rigidbody>().velocity = direccion * -speed;
        gameController.moving = true;
        ball.transform.SetParent(null);

    }
}
