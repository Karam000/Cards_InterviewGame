using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] float movementDuration = 0.8f;
   public void MoveToPlayer(Player player, int index)
   {
        this.transform.DOMove(player.transform.position + index * Vector3.forward * 0.2f, movementDuration) ;
   }
}
