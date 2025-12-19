using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Follow : MonoBehaviour
{
    public Player player;
    void Update()
    {
        if (FindObjectOfType<GameManager>().isGameActive == false)
        {
            return;
        }
        transform.Translate(Vector2.right * player.speed * Time.deltaTime);
    }
}
