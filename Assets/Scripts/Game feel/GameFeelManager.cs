using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFeelManager : MonoBehaviour
{
    [SerializeField] VisualManager VisualManager;
    [SerializeField] AudioManager AudioManager;
    
    public static GameFeelManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
   
    public void CelebrateCard(Card card)
    {
        VisualManager.PlayCelebrationParticle(CelebrationStates.MaxCard,card.transform.position);
    }
    public void CelebratePlayer(Player player)
    {
        VisualManager.PlayCelebrationParticle(CelebrationStates.PlayerWin, player.transform.position);
    }
    
}
