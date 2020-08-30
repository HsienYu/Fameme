using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pill : MonoBehaviour
{

    public TitleManager Title;
    public RankManager Rank;
    public GameObject obj;

    public Material red;
    public Material white;
    public Material yellow;
    public Material pink;

    //bool state = false;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, 3);
        if (i == 0){
            obj.GetComponent<Renderer>().material = red;
        }else if (i == 1){
            obj.GetComponent<Renderer>().material = white;
        }else if (i == 2)
        {
            obj.GetComponent<Renderer>().material = yellow;
        }else if (i == 3)
        {
            obj.GetComponent<Renderer>().material = pink;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.gyro.userAcceleration.z);
        if(Input.gyro.userAcceleration.z > 2){
            //state = true;
            Title.ChangeToRanking();

            Rank.SetPill(GameManager.Instance.GetPillScore(PillType.Red),
                GameManager.Instance.GetPillScore(PillType.White),
                GameManager.Instance.GetPillScore(PillType.Yellow),
                GameManager.Instance.GetPillScore(PillType.Pink));
            Rank.gameObject.SetActive(true);
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Pressed primary button.");
        //    Title.ChangeToRanking();

        //    Rank.SetPill(GameManager.Instance.GetPillScore(PillType.Red),
        //        GameManager.Instance.GetPillScore(PillType.White),
        //        GameManager.Instance.GetPillScore(PillType.Yellow),
        //        GameManager.Instance.GetPillScore(PillType.Pink));
        //    Rank.gameObject.SetActive(true);
        //}

    }
}
