using UnityEngine;
using System.Collections;

public class WorldItem : MonoBehaviour {

    public Item item;

    public Rigidbody skeleton;
    public Vector3 location;
    public float interactDistance = 1f;
    public Vector3 minSpeed = new Vector3(.025f, .025f, .025f);

    public void ItemWorldRemove()
    {
        Destroy(this.gameObject);
    }

    public void Start()
    {
        skeleton = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        //if ((skeleton.velocity.x < minSpeed.x && skeleton.velocity.y < minSpeed.y && skeleton.velocity.z < minSpeed.z) && skeleton.velocity.magnitude != 0)
        //{
        //    if(skeleton.velocity.x != 0 && skeleton.velocity.y != 0 && skeleton.velocity.z != 0)
        //    {
        //        skeleton.velocity = new Vector3(0, 0, 0);
        //        skeleton.angularVelocity = new Vector3(0, 0, 0);
        //    }
        //}
    }
}