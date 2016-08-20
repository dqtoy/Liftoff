﻿using UnityEngine;
using System.Collections;

public class RocketHolder : MonoBehaviour {
    public bool[] purchased;

    public int rocketCount;

    public Sprite r1;
    public Sprite r2;
    public Sprite r3;
    public Sprite r4;
    public Sprite r5;
    public Sprite r6;
    public Sprite r7;
    public Sprite r8;
    public Sprite r9;
    public Sprite r10;
    public Sprite r11;
    public Sprite r12;
    public Sprite r13;
    public Sprite r14;
    public Sprite r15;
    public Sprite r16;
    public Sprite r17;
    public Sprite r18;
    public Sprite r19;
    public Sprite r20;
    public Sprite r21;
    public Sprite r22;
    public Sprite r23;
    public Sprite r24;
    public Sprite r25;
    public Sprite r26;
    public Sprite r27;
    public Sprite r28;
    public Sprite r29;
    public Sprite r30;
    public Sprite r31;
    public Sprite r32;
    public Sprite r33;
    public Sprite r34;
    public Sprite r35;
    public Sprite r36;
    public Sprite r37;
    public Sprite r38;
    public Sprite r39;
    public Sprite r40;
    public Sprite r41;
    public Sprite r42;
    public Sprite r43;
    public Sprite r44;
    public Sprite r45;
    public Sprite r46;
    public Sprite r47;
    public Sprite r48;
    public Sprite r49;
    public Sprite r50;
    public Sprite r51;
    public Sprite r52;
    public Sprite r53;
    public Sprite r54;
    public Sprite r55;
    public Sprite r56;
    public Sprite r57;
    public Sprite r58;
    public Sprite r59;

    public Sprite crayon1;
    public Sprite crayon2;
    public Sprite crayon3;
    public Sprite crayon4;

    public RocketInfo ri;
    void Awake() {
        Util.rocketHolder = this;
        ri = new RocketInfo(r1, true, "RANDOM", 0);
        purchased = new bool[400];
        purchased[1] = true;
    }
    void Start() {
        
    }

    public RocketInfo getRocket() {
        return getRocket((int)ScrollManager.selector);
    }

    public RocketInfo getRocket(int i) {
        switch (i) {
            case 0: if (Util.wm.alternate) {
                    string oldName = ri.name;
                    do {
                        ri = getRocket((int)Random.Range(1f, ScrollManager.rocketCount + 0.99f));
                    }
                    while (!ri.purchased || oldName.Equals(ri.name));
                    ri.name = "RANDOM";
                    Util.wm.alternate = !Util.wm.alternate;
                    return ri;
                }
                else {
                    return ri;
                }
            // RocketInfo(Sprite spr, bool p, string n, int c, bool noz, bool fire)
            case 1:  return new RocketInfo(r1,  purchased[i], r1.name, 0); //rocket
            case 2:  return new RocketInfo(r2,  purchased[i], r2.name, 50); //f9
            case 3:  return new RocketInfo(r3,  purchased[i], r3.name, 50); //soyuz
            case 4:  return new RocketInfo(r4,  purchased[i], r4.name, 100); //proton
            case 5:  return new RocketInfo(r5,  purchased[i], r5.name, 100); //atlas 4
            case 6:  return new RocketInfo(r6,  purchased[i], r6.name, 100); //atlas 5
            case 7:  return new RocketInfo(r7,  purchased[i], r7.name, 150); //ariane 5
            case 8:  return new RocketInfo(r8,  purchased[i], r8.name, 175); //shuttle
            case 9:  return new RocketInfo(r9,  purchased[i], r9.name, 200); //v2
            case 10: return new RocketInfo(r10, purchased[i], r10.name, 200); //n1
            case 11: return new RocketInfo(r11, purchased[i], r11.name, 300); //SaturnV
            case 12: return new RocketInfo(r12, purchased[i], r12.name, 200); //Apollo
            case 13: return new RocketInfo(r13, purchased[i], r13.name, 200, false, true); //Blackbird
            case 14: return new RocketInfo(r14, purchased[i], r14.name, 200); //tomahawk
            case 15: return new RocketInfo(r15, purchased[i], r15.name, 0, false, true); //fighter jet
            case 16: return new RocketInfo(r16, purchased[i], r16.name, 0, false, true); //star destroyer
            case 17: return new RocketInfo(r17, purchased[i], r17.name, 0, false, true); //bottle
            case 18: return new RocketInfo(r18, purchased[i], r18.name, 0, false, false); //crayon
            case 19: return new RocketInfo(r19, purchased[i], r19.name, 0, false, false); //paper
            case 20: return new RocketInfo(r20, purchased[i], r20.name, 0, false, true); ///machine gun
            case 21: return new RocketInfo(r21, purchased[i], r21.name, 0, false, true);  //steel man
            case 22: return new RocketInfo(r22, purchased[i], r22.name, 0); //SLS
            case 23: return new RocketInfo(r23, purchased[i], r23.name, 0); //delta IV heavy
            case 24: return new RocketInfo(r24, purchased[i], r24.name, 0); //Eiffel rocket
            case 25: return new RocketInfo(r25, purchased[i], r25.name, 0, false, false); //myphone
            case 26: return new RocketInfo(r26, purchased[i], r26.name, 0);
            case 27: return new RocketInfo(r27, purchased[i], r27.name, 0);
            case 28: return new RocketInfo(r28, purchased[i], r28.name, 0);
            case 29: return new RocketInfo(r29, purchased[i], r29.name, 0);
            case 30: return new RocketInfo(r30, purchased[i], r30.name, 0);
            case 31: return new RocketInfo(r31, purchased[i], r31.name, 0);
            case 32: return new RocketInfo(r32, purchased[i], r32.name, 0);
            case 33: return new RocketInfo(r33, purchased[i], r33.name, 0);
            case 34: return new RocketInfo(r34, purchased[i], r34.name, 0);
            case 35: return new RocketInfo(r35, purchased[i], r35.name, 0);
            case 36: return new RocketInfo(r36, purchased[i], r36.name, 0);
            case 37: return new RocketInfo(r37, purchased[i], r37.name, 0);
            case 38: return new RocketInfo(r38, purchased[i], r38.name, 0);
            case 39: return new RocketInfo(r39, purchased[i], r39.name, 0);
            case 40: return new RocketInfo(r40, purchased[i], r40.name, 0);
            case 41: return new RocketInfo(r41, purchased[i], r41.name, 0);
            case 42: return new RocketInfo(r42, purchased[i], r42.name, 0);
            case 43: return new RocketInfo(r43, purchased[i], r43.name, 0);
            case 44: return new RocketInfo(r44, purchased[i], r44.name, 0);
            case 45: return new RocketInfo(r45, purchased[i], r45.name, 0);
            case 46: return new RocketInfo(r46, purchased[i], r46.name, 0);
            case 47: return new RocketInfo(r47, purchased[i], r47.name, 0);
            case 48: return new RocketInfo(r48, purchased[i], r48.name, 0);
            case 49: return new RocketInfo(r49, purchased[i], r49.name, 0);
            case 50: return new RocketInfo(r50, purchased[i], r50.name, 0);
            case 51: return new RocketInfo(r51, purchased[i], r51.name, 0);
            case 52: return new RocketInfo(r52, purchased[i], r52.name, 0);
            case 53: return new RocketInfo(r53, purchased[i], r53.name, 0);
            case 54: return new RocketInfo(r54, purchased[i], r54.name, 0);
            case 55: return new RocketInfo(r55, purchased[i], r55.name, 0);
            case 56: return new RocketInfo(r56, purchased[i], r56.name, 0);
            case 57: return new RocketInfo(r57, purchased[i], r57.name, 0);
            case 58: return new RocketInfo(r58, purchased[i], r58.name, 0);
            case 59: return new RocketInfo(r59, purchased[i], r59.name, 0);
                //RocketInfo(Sprite spr, bool p, string n, int c, bool noz, bool f)
        }
        return null;
    }
}

public class RocketInfo {
    public Sprite sprite;
    public string name;
    public bool nozzle;
    public bool fire;
    public int cost;
    public bool purchased;
    

    public RocketInfo(Sprite spr, bool p, string n, int c) {
        setup(spr, p, n, c, true, true);
    }

    public RocketInfo(Sprite spr, bool p, string n, int c, bool noz, bool f) {
        setup(spr, p, n, c, noz, f);
    }



    public void setup(Sprite spr, bool p, string n, int c, bool noz, bool f) {
        sprite = spr;
        purchased = p;
        name = n;
        cost = c;
        nozzle = noz;
        fire = f;
    }
}
