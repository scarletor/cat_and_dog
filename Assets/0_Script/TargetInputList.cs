using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using TMPro;
public class TargetInputList : MonoBehaviour
{




    public GameObject rightParticle;
    public TextMeshProUGUI textEff;
    public List<InputButtonEnum> targetArrowList;
    public int numberToInput;
    public GameObject symbolList;

    [Button]
    public void CreateNewList(int count)
    {
        targetArrowList.Clear();


        foreach (Transform transform in symbolList.transform)
        {

            transform.Find("Bg").GetComponent<Image>().sprite = blueCircle;

        }







        int i = 0;
        foreach (Transform transform in symbolList.transform)
        {
            if (i >= count)//disable 
            {
                transform.gameObject.SetActive(false);
            }
            else  //enable
            {
                transform.gameObject.SetActive(true);


                var rdRotate = UnityEngine.Random.Range(1, 5);
                if (rdRotate == 1) //up
                {
                    targetArrowList.Add(InputButtonEnum.Up);
                    transform.localScale = new Vector3(1, -1, 1);
                    transform.localRotation = Quaternion.Euler(0, 0, 0);

                }
                else if (rdRotate == 2) //right
                {
                    targetArrowList.Add(InputButtonEnum.Right);
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.localRotation = Quaternion.Euler(0, 0, 90);


                }
                else if (rdRotate == 3)//down
                {
                    targetArrowList.Add(InputButtonEnum.Down);
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.localRotation = Quaternion.Euler(0, 0, 0);


                }
                else if (rdRotate == 4)//left
                {
                    targetArrowList.Add(InputButtonEnum.Left);
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.localRotation = Quaternion.Euler(0, 0, -90);

                }
            }
            i++;
        }

    }
    public Sprite redCircle, greenCircle, blueCircle;
    public void SetSymbolGreen(int index)
    {
        var symbol = symbolList.transform.GetChild(index).Find("Bg").GetComponent<Image>().sprite = greenCircle;
    }

    public void SetSymbolRed(int index)
    {
        symbolList.transform.GetChild(index).Find("Bg").GetComponent<Image>().sprite = redCircle;
    }

    public GameObject pos;
    public void SetSymbolGreenEff(int index)
    {
        var newPart = Instantiate(rightParticle, gameObject.transform, true);
        newPart.transform.position = symbolList.transform.GetChild(index).Find("Bg").transform.position;


        var newPartEffText = Instantiate(textEff, gameObject.transform, false);
        newPartEffText.transform.position = symbolList.transform.GetChild(index).Find("Bg").transform.position;
        newPartEffText.text = "60";



    }


}
