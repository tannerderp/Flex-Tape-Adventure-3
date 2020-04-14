using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = FindObjectOfType<PlayerMovement>().health;
        if(slider.value <= 0)
        {
            SceneManager.LoadScene("GameOverCutscene");
        }
    }
}
