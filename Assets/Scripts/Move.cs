using UnityEngine;
using UnityEngine.UI;


public class Move : MonoBehaviour {

    [SerializeField]
    private Transform goal;
    [SerializeField]
    private float velocidade = 1f;
    [SerializeField]
    private float magntde = 0.01f;
    [SerializeField]
    private float rotVeloc = 0.4f;

    public bool goLumb = false;
    private Animator AnimChar;

    void Start() {

        AnimChar = GetComponent<Animator>();

    }
    private void Update(){
        if (goLumb == true){
            Lumb();
        }else{
            AnimChar.SetBool("Walk", false);
            AnimChar.SetBool("Lumber", false);
        }
        
    }
    private void Lumb() {

        Vector3 localT = goal.transform.position - this.transform.position;
        localT.y = this.transform.position.y;

        Vector3 LookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        Vector3 rotLookAt = LookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(rotLookAt), Time.deltaTime * rotVeloc);

        Debug.DrawRay(this.transform.position, localT, Color.red);

        if (Vector3.Distance(LookAtGoal, transform.position) > magntde)
        {
            this.transform.Translate(localT.normalized * velocidade * Time.deltaTime, Space.World);
            AnimChar.SetBool("Walk", true);
            AnimChar.SetBool("Lumber", false);
        }
        else
        {
            AnimChar.SetBool("Walk", false);
            AnimChar.SetBool("Lumber", true);
        }
    }
    public void gogo(){
        if(goLumb == false){
            goLumb = true;
        }else if (goLumb == true){
            goLumb = false;
        }
    }
}
