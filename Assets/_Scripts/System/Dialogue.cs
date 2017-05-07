using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;

public class Dialogue : MonoBehaviour {

    public GameObject dialoguePanel;
    public Text textComponent;

    public List<List<string>> dialogs = new List<List<string>>();

    public string[] dialogStrings;
    public float seconds = 0.15f;
    public float charRateMult = 0.5f;

    public KeyCode DialogInput = KeyCode.Return;
    private bool isStrRevealed = false;

    public GameObject ContinueIcon;
    public GameObject StopIcon;

    private bool end = false;

    void Start()
    {
        ReadText();
    }

    private IEnumerator DisplayString(int num)
    {
        string str = dialogStrings[num];
        int currentCharIndex = 0;
        textComponent.text = "";

        while(currentCharIndex < str.Length)
        {
            textComponent.text += str[currentCharIndex];
            currentCharIndex++;

            if(currentCharIndex < str.Length)
            {
                if(Input.GetKey(DialogInput))
                    yield return new WaitForSeconds(seconds * charRateMult);
                else
                    yield return new WaitForSeconds(seconds);
            }
            else
            {
                break;
            }
        }

        /*while (true)
        {
             if (Input.GetKeyDown(DialogInput))
                 break;
        }*/

        isStrRevealed = false;
        textComponent.text = "";
    }

    public IEnumerator PlayDialog(int  d)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player1Conroller>().canMove = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        dialoguePanel.SetActive(true);

        foreach (string str in dialogs[d])
        {
            int currentCharIndex = 0;
            textComponent.text = "";

            while (currentCharIndex < str.Length)
            {
                textComponent.text += str[currentCharIndex];
                currentCharIndex++;

                if (currentCharIndex < str.Length)
                {
                    if (Input.GetKey(DialogInput))
                        yield return new WaitForSeconds(seconds * charRateMult);
                    else
                        yield return new WaitForSeconds(seconds);
                }
                else
                {
                    break;
                }
            }

            /*while (true)
            {
                 if (Input.GetKeyDown(DialogInput))
                     break;
            }*/
            yield return new WaitForSeconds(1);
            isStrRevealed = false;
            textComponent.text = "";

        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player1Conroller>().canMove = true;
        dialoguePanel.SetActive(false);
        textComponent.text = "";

    }

    void ReadText()
    {
        string line;

        StreamReader reader = new StreamReader(Application.dataPath + "/StreamingAssets/Dialog.txt"/* "C:\\Users\\TeeNik\\Desktop\\IAADArt\\Dialog.txt"*/, Encoding.Default);

        int count = -1; ;

        using (reader)
        {
            do
            {
                line = reader.ReadLine();

                if (line != null)
                {
                    int justNum;
                    if (Int32.TryParse(line, out justNum))
                    {
                        dialogs.Add(new List<string>());
                        count++;
                        continue;
                    }

                    dialogs[count].Add(line);
                 }
            }
            while (line != null);
        }

    }
}
