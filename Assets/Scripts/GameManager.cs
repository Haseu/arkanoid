using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pointPanel;
    public GameObject prefabSpecialItem;
    public GameObject paddle;

    protected int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnItem", 3);
    }

    protected void spawnItem()
    {
        GameObject specialItem = Instantiate(prefabSpecialItem);
        specialItem.transform.position = new Vector2(UnityEngine.Random.Range(-7, 7), UnityEngine.Random.Range(1, -3));
    }

    public void onBallCollision(GameObject other)
    {
        if (other.CompareTag("GameOver"))
        {
            SceneManager.LoadScene(2);
        }
        else if (other.CompareTag("SpecialItem"))
        {
            onSpecialItemCOllision(other);
        }
        else if (other.CompareTag("Brick"))
        {
            addPoint(100);
        }
    }

    protected void addPoint(int points)
    {
        score += points;
        pointPanel.text = score.ToString();
    }

    public void onSpecialItemCOllision(GameObject other)
    {
        Vector2 size = paddle.GetComponent<SpriteRenderer>().size;
        size.x += 0.5f;

        paddle.GetComponent<SpriteRenderer>().size = size;
        paddle.GetComponent<CapsuleCollider2D>().size = size;

        Destroy(other);
        Invoke("spawnItem", 5);
    }
}
