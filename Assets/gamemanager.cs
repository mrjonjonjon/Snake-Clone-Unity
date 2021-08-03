using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamemanager : MonoBehaviour
{
    public GameObject clone;
    public GameObject food;
    public float increment=0.1f;
public static gamemanager sharedinstance=null;
public Text scoretext;
float score=0f;
    void Awake(){

          if(sharedinstance!=null && sharedinstance!=this){
            Destroy(gameObject);
        }else{

        sharedinstance=this;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void spawnFood(){
 GameObject newfood=Instantiate(food);
 newfood.transform.position=new Vector3(Random.Range(-8f,8f),Random.Range(-5f,5f));

}
    // Update is called once per frame
    void Update()
    {increaseScore(increment);
       scoretext.text="SCORE:"+score.ToString();
        //food.transform.position=
    }

    void increaseScore(float increment){
        score+=increment;
    }

    public void Clone(){
        Instantiate(clone);
    }
}
