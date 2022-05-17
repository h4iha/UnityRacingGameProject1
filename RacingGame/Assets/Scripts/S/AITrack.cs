using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrack : MonoBehaviour
{
    public GameObject Tracker;
   // GameObject[] Cs;

    public GameObject C0;
    public GameObject C1;
    public GameObject C2;
    public GameObject C3;
    public GameObject C4;
    public GameObject C5;
    public GameObject C6;
    public GameObject C7;
    public GameObject C8;
    public GameObject C9;
    public GameObject C10;
    public GameObject C11;
    public GameObject C12;
    public GameObject C13;
    public GameObject C14;
    public GameObject C15;
    public GameObject C16;
    public GameObject C17;
    public GameObject C18;
    public GameObject C19;
    public GameObject C20;
    public GameObject C21;
    public GameObject C22;
    public GameObject C23;
    public GameObject C24;
    public GameObject C25;
    public GameObject C26;
    public GameObject C27;
    public GameObject C28;
    public GameObject C29;
    public GameObject C30;
    public GameObject C31;

    public int count;

    void Update()
    {
        if(count == 0) { Tracker.transform.position = C0.transform.position;
            Tracker.transform.rotation = C0.transform.rotation; 
        }
        if (count == 1) { Tracker.transform.position = C1.transform.position; 
            Tracker.transform.rotation = C1.transform.rotation; 
        }
        if (count == 2) { Tracker.transform.position = C2.transform.position;
            Tracker.transform.rotation = C2.transform.rotation;
        }
        if (count == 3) { Tracker.transform.position = C3.transform.position;
            Tracker.transform.rotation = C3.transform.rotation;
        }
        if (count == 4) { Tracker.transform.position = C4.transform.position;
            Tracker.transform.rotation = C4.transform.rotation;
        }
        if (count == 5) { Tracker.transform.position = C5.transform.position;
            Tracker.transform.rotation = C5.transform.rotation;
        }
        if (count == 6) { Tracker.transform.position = C6.transform.position;
            Tracker.transform.rotation = C6.transform.rotation;
        }
        if (count == 7) { Tracker.transform.position = C7.transform.position;
            Tracker.transform.rotation = C7.transform.rotation;
        }
        if (count == 8) { Tracker.transform.position = C8.transform.position;
            Tracker.transform.rotation = C8.transform.rotation;
        }
        if (count == 9) { Tracker.transform.position = C9.transform.position;
            Tracker.transform.rotation = C9.transform.rotation;
        }
        if (count == 10) { Tracker.transform.position = C10.transform.position;
            Tracker.transform.rotation = C10.transform.rotation;
        }
        if (count == 11) { Tracker.transform.position = C11.transform.position;
            Tracker.transform.rotation = C11.transform.rotation;
        }
        if (count == 12) { Tracker.transform.position = C12.transform.position;
            Tracker.transform.rotation = C12.transform.rotation;
        }
        if (count == 13) { Tracker.transform.position = C13.transform.position;
            Tracker.transform.rotation = C13.transform.rotation;
        }
        if (count == 14) { Tracker.transform.position = C14.transform.position;
            Tracker.transform.rotation = C14.transform.rotation;
        }
        if (count == 15) { Tracker.transform.position = C15.transform.position;
            Tracker.transform.rotation = C15.transform.rotation;
        }
        if (count == 16) { Tracker.transform.position = C16.transform.position;
            Tracker.transform.rotation = C16.transform.rotation;
        }
        if (count == 17) { Tracker.transform.position = C17.transform.position;
            Tracker.transform.rotation = C17.transform.rotation;
        }
        if (count == 18) { Tracker.transform.position = C18.transform.position;
            Tracker.transform.rotation = C18.transform.rotation;
        }
        if (count == 19) { Tracker.transform.position = C19.transform.position;
            Tracker.transform.rotation = C19.transform.rotation;
        }
        if (count == 20) { Tracker.transform.position = C20.transform.position;
            Tracker.transform.rotation = C20.transform.rotation;
        }
        if (count == 21) { Tracker.transform.position = C21.transform.position;
            Tracker.transform.rotation = C21.transform.rotation;
        }
        if (count == 22) { Tracker.transform.position = C22.transform.position;
            Tracker.transform.rotation = C22.transform.rotation;
        }
        if (count == 23) { Tracker.transform.position = C23.transform.position;
            Tracker.transform.rotation = C23.transform.rotation;
        }
        if (count == 24) { Tracker.transform.position = C24.transform.position;
            Tracker.transform.rotation = C24.transform.rotation;
        }
        if (count == 25) { Tracker.transform.position = C25.transform.position;
            Tracker.transform.rotation = C25.transform.rotation;
        }
        if (count == 26) { Tracker.transform.position = C26.transform.position;
            Tracker.transform.rotation = C26.transform.rotation;
        }
        if (count == 27) { Tracker.transform.position = C27.transform.position;
            Tracker.transform.rotation = C27.transform.rotation;
        }
        if (count == 28) { Tracker.transform.position = C28.transform.position;
            Tracker.transform.rotation = C28.transform.rotation;
        }
        if (count == 29) { Tracker.transform.position = C29.transform.position;
            Tracker.transform.rotation = C29.transform.rotation;
        }
        if (count == 30) { Tracker.transform.position = C30.transform.position;
            Tracker.transform.rotation = C30.transform.rotation;
        }
        if (count == 31) { Tracker.transform.position = C31.transform.position;
            Tracker.transform.rotation = C31.transform.rotation;
        }

        //TheMaker.transform.position = Marks[count].transform.position;
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "AIBody")
        {
            //this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<MeshCollider>().enabled = false;
            if (count == 32)
            {
                count = 0;
            }
            count += 1;
            yield return new WaitForSeconds(0.02f);
            //this.GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<MeshCollider>().enabled = true;
        }
    }
}