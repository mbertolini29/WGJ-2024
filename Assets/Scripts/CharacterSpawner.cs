using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
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
    }
}
