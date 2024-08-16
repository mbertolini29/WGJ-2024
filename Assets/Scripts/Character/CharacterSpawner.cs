using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public UIManager uiManager;
    public GameObject wizardPrefab;
    public float delayTime = 3f;
    public float growDuration = 2f;

    void Start()
    {
        StartCoroutine(SpawnCharacterAfterDelay());
    }

    IEnumerator SpawnCharacterAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        GameObject NPC = Instantiate(wizardPrefab, wizardPrefab.transform.position, Quaternion.identity);
        
        NPC.transform.localScale = Vector3.zero;

        float elapsedTime = 0f;
        while (elapsedTime < growDuration)
        {
            elapsedTime += Time.deltaTime;
            float scale = Mathf.Clamp01(elapsedTime / growDuration);
            NPC.transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

        NPC.transform.localScale = Vector3.one;

        // Método para conectar el NPC con UIManager
        NPC npcScript = NPC.GetComponent<NPC>();
        if (npcScript != null && uiManager != null)
        {
            uiManager.SetNPC(npcScript); 
        }

        //metodo para conectar el NPC al charactermovement
        CharacterMovement characterMovement = FindObjectOfType<CharacterMovement>();
        if(characterMovement!=null)
        {
            characterMovement.SetNPC(npcScript);
        }
    }
}
