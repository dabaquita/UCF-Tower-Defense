using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonIndex controller;
    [SerializeField] Animator animator;
    [SerializeField] AnimationFunctions animationFunction;
    [SerializeField] int buttonIndex;
    private Button button;
    private GameObject mainMenu;

    void Start()
    {
      button = GetComponent<Button>();
      mainMenu = GameObject.Find("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        animationFunction = GetComponent<AnimationFunctions>();
  
        if(controller.index == buttonIndex)
        {
            
            animator.SetBool ("Selected", true);
            if(Input.GetAxis ("Submit") == 1)
            {
                
                animator.SetBool ("Pressed", true);
                button.onClick.Invoke();
                
            }
            else if (animator.GetBool ("Pressed"))
            {
                
                animator.SetBool("Pressed", false);
                animationFunction.disableOnce = true;
            }
            
        }
        else 
        {
            animator.SetBool ("Selected", false);
        }
        //button.gameObject.SetActive(true);
    }
}
