using UnityEngine;

public class BreakableBlockManager : MonoBehaviour
{
    private int breakableBlocksAmount;

    public void CountBlocks()
    {
        breakableBlocksAmount++;
    }

    public void BlockDestroyed()
    {
        breakableBlocksAmount--;

        if(breakableBlocksAmount <= 0)
        {
            GameManager.instance.UpdateGameState(GameStates.Win);
            StartCoroutine(LevelManager.instance.LoadNextLevel());
        }
    }
}
