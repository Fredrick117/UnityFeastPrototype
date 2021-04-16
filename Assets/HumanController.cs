using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    [SerializeField]
    public float humanSpeed = 3.5f;

    private Vector3 playerPosition;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Flee when player approaches
        playerPosition = player.transform.position;
        if (Vector3.Distance(transform.position, playerPosition) < 15.0f * player.transform.localScale.x) {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, -1 * humanSpeed * Time.deltaTime);
        }
    }
}
