using UnityEngine;

public class CollideWithEnemy : MonoBehaviour
{
    public GameObject mainMenuGameObject;

    private ScoreController scoreController;

    public void Start()
    {
        scoreController = GetComponent<ScoreController>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Возможно, эту штуку нужно инвертировать
        if (collision.gameObject.tag == Tags.SIMPLE_ENEMY)
        {
            int score = scoreController.GetScore();
            mainMenuGameObject.GetComponent<LoseMenuController>().InvokeMenu(score);
        }  
    }
}
