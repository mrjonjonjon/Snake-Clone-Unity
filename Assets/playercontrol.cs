using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
      
      static Vector3 direction=new Vector3(1,0,0);
      public int snakelength=3;
      public float stepsize=2f;
      public float tickspeed=0.2f;
      public float boostspeed=0.05f;
      //public static playercontrol sharedinstance=null;

     
    public List<Transform> bodypool;
    public Transform snakesegment;

    
    void Awake()
    {

        

         if (true)
             {
                bodypool = new List<Transform>();
             }
                for(int i=0;i<snakelength;i++){
                    bodypool.Add(Instantiate(snakesegment));
                }
            

             

    }

    void Start()
    {  
        
        StartCoroutine(moveSnake());
       
    }



    void OnTriggerEnter2D(Collider2D col){
             
if(col.gameObject.CompareTag("food")){
    
    Grow();
    Destroy(col.gameObject);
    gamemanager.sharedinstance.spawnFood();
    gamemanager.sharedinstance.Clone();
}


    }

void OnCollisionEnter2D(Collision2D col){




}


    void Update(){
        if(!gameObject.CompareTag("clone")){

if(Input.GetKey(KeyCode.LeftShift)){
    tickspeed=boostspeed;
    //gamemanager.sharedinstance.increment=0.2f;
}else{
    tickspeed=0.2f; 
  // gamemanager.sharedinstance.increment=0.1f;
}
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
       
        direction=new Vector3(-1,0,0);
       
    }else if(Input.GetKeyDown(KeyCode.RightArrow)){

        direction=new Vector3(1,0,0);


    }else if(Input.GetKeyDown(KeyCode.UpArrow)){
        direction=new Vector3(0,1,0);


    }else if(Input.GetKeyDown(KeyCode.DownArrow)){

        direction=new Vector3(0,-1,0);

    }

        }


    }

IEnumerator moveSnake(){
        while(true){

          if(bodypool.Count!=0){
 for(int i=0;i<bodypool.Count-1;i++){
                bodypool[i].position=bodypool[i+1].position;
            }
            bodypool[bodypool.Count-1].position=transform.position;
          }
           

            transform.position+=direction*stepsize;
           // Grow();
            yield return new WaitForSeconds(tickspeed);
        }

}
   

   void Grow(){
       Transform newseg=Instantiate(snakesegment);
       newseg.transform.position=bodypool[0].position;
       bodypool.Insert(0,newseg);

   }
}

