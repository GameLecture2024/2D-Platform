using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("��ȭ �ý���")]
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
        // nameText,dialogue �ؽ�Ʈ�� �޾ƿͼ� �������ִ� ������Ʈ - ���� â���� �Ʒ� �׸��� ã�ƿͶ�.
        nameText = GameObject.Find("Canvas/Dialouge Background/NPC_Name").GetComponent<TextMeshProUGUI>();
        dialogueText = GameObject.Find("Canvas/Dialouge Background/Dialogue_Text").GetComponent<TextMeshProUGUI>();
        // Ȱ��ȭ�Ǿ� �ִ� ä��ȭ���� ��Ȱ���ض�.
        dialogueObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        InteractNPC(hasExistNPC);
    }

    public void InteractNPC(bool canSpeak)
    {
        // �÷��̾ e��ư�� ������ �� + NPC �ֺ��� ���� ��
        if (Input.GetKeyDown(KeyCode.E) && canSpeak)
        {
            EnableDialogue();
        }
    }

    private void EnableDialogue()
    {
        // ��ȭâ ��Ȱ��ȭ�Ǿ� �ִ� ���� -> Ȱ��ȭ
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
        // npc�� ������ ȭ�鿡 ����Ѵ�.
        nameText.text = currentNPC.npcName;
        dialogueText.text = currentNPC.dialogues[0];

        // n���Ŀ� 1���� ����϶�.

        // Ű����� next ��ư�� ���� �� ���� �ؽ�Ʈ�� ���´�.
        //dialogueText.text = currentNPC.dialogues[1];
    }
    public void CloseText()
    {
        DialogueBackGround.SetActive(false);
    }
}
