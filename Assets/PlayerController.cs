using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player movement code from https://github.com/jiankaiwang/FirstPersonController
    public float speed = 10.0f;

    public float fov = 90.0f;

    private float translation;
    private float strafe;

    public float currentHealth = 100.0f;
    // Every time a human is devoured, increase size by this %
    private float healthIncreasePercentage = 1.15f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Camera.main.fieldOfView = fov;
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(strafe, 0, translation);

        // Feast!
        if (Input.GetKeyDown(KeyCode.R))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10f * (currentHealth / 100f), -1))
            {
                // TODO: extend tongue object out to human, pull them to player, destroy
                if (hit.transform.tag.Equals("Human"))
                {
                    Destroy(hit.transform.gameObject);
                    currentHealth *= healthIncreasePercentage;
                }
            }
        }

        // Increase size of player
        // TODO: GRADUALLY SCALE INSTEAD OF INSTANTLY UPSCALING
        var scale = currentHealth / 100.0f;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }
}
