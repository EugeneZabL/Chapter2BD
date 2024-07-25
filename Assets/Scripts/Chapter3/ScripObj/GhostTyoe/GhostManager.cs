using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{

    [SerializeField]
    List<GhostType> _listOfGhost;

    GameObject GameObject;

    private void Start()
    {
        foreach (GhostType ghost in _listOfGhost)
        {
            
            StartCoroutine(SummonGhost(ghost));
        }
    }

    private IEnumerator SummonGhost(GhostType ghost)
    {

        ghost.DebugData();

        GameObject BodyGhost = new GameObject(ghost.name);

        BodyGhost.AddComponent<SpriteRenderer>();

        BodyGhost.GetComponent<SpriteRenderer>().sprite = ghost.Sprite;

        BodyGhost.transform.position = new Vector3(-10, Random.Range(-4, 4), 0);

        BodyGhost.SetActive(false);

        while (true)
        {
            yield return new WaitForSeconds(ghost.Delay);

            BodyGhost.SetActive(true);

            BodyGhost.transform.position = new Vector3(-10, Random.Range(-4, 4), 0);

            while (BodyGhost.transform.position.x < 12)
            {
                BodyGhost.transform.position = new Vector3(BodyGhost.transform.position.x + ghost.Speed * Time.deltaTime, BodyGhost.transform.position.y, BodyGhost.transform.position.z);

                yield return new WaitForFixedUpdate();
            }

            BodyGhost.SetActive(false);
        }
    }
}
