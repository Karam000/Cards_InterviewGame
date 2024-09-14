using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private float movementDuration = 0.8f;
    [HideInInspector] public int cardValue;
    private Player myOwner;

    private void Awake()
    {
        cardValue = UnityEngine.Random.Range(1, 53);
    }

    public void MoveToPlayer(Player player, int index)
    {
        this.transform.DOMove(player.transform.position + index * Vector3.forward * 0.2f, movementDuration);
        myOwner = player;
    }

    public void PlayCard(Transform playPos)
    {
        this.transform.DOMove(playPos.position, movementDuration);
    }

    private void OnMouseDown()
    {
        if (myOwner is UserPlayer) //to prevent from clicking on other players' cards
            myOwner.PlayCard(this);
    }
}