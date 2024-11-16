using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("대화 시스템")]
    public GameObject DialogueBackGround;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueObject;
    [Space]
    public bool hasExistNPC = false;
    public NPCText currentNPC;



    // Start is called before the first frame update
    void Start()
    {
        // nameText,dialogue 텍스트를 받아와서 실행해주는 컴포넌트 - 게임 창에서 아래 항목을 찾아와라.
        nameText = GameObject.Find("Canvas/Dialouge Background/NPC_Name").GetComponent<TextMeshProUGUI>();
        dialogueText = GameObject.Find("Canvas/Dialouge Background/Dialogue_Text").GetComponent<TextMeshProUGUI>();
        // 활성화되어 있는 채팅화면을 비활성해라.
        dialogueObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        InteractNPC(hasExistNPC);
    }

    public void InteractNPC(bool canSpeak)
    {
        // 플레이어가 e버튼을 눌렀을 때 + NPC 주변에 있을 때
        if (Input.GetKeyDown(KeyCode.E) && canSpeak)
        {
            EnableDialogue();
        }
    }

    private void EnableDialogue()
    {
        // 대화창 비활성화되어 있는 상태 -> 활성화
        if (DialogueBackGround.activeInHierarchy)
        {
            DialogueBackGround.SetActive(false);
        }
        else
        {
            TypeText();
        }
    }

    private void TypeText()
    {
        DialogueBackGround.SetActive(true);
        // npc의 정보를 화면에 출력한다.
        nameText.text = currentNPC.npcName;
        dialogueText.text = currentNPC.dialogues[0];

        // n초후에 1번을 출력하라.

        // 키보드로 next 버튼을 누를 때 다음 텍스트가 나온다.
        //dialogueText.text = currentNPC.dialogues[1];
    }
    public void CloseText()
    {
        DialogueBackGround.SetActive(false);
    }
}
