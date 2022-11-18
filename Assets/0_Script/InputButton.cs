using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public GameAudition gameAudition;
    public void OnClickButtonUp()
    {
        gameAudition.OnClickButtonUpFunc();

    }




    public void OnClickButtonDown()
    {
        gameAudition.OnClickButtonDownFunc();
    }

   

    public void OnClickButtonLeft()
    {
        gameAudition.OnClickButtonLeftFunc();

    }



    public void OnClickButtonRight()
    {
        gameAudition.OnClickButtonRightFunc();

    }







    public List<Button> buttonList;
    public void EnableButton()
    {
        buttonList.ForEach(bt => {
            bt.interactable = true;
        });
    }
    public void DisableButton()
    {
        buttonList.ForEach(bt => {
            bt.interactable = false;
        });
    }

}

    public enum InputButtonEnum
    { 
        none,
        Left,
        Right,
        Up,
        Down
    }
