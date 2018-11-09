package Entities;

import java.io.Serializable;

public class Photo_Model  implements Serializable {

    public String PHOTOID;
    public String PHOTOURL;
    public String PHOTONAME;
    public String JCXXID;

    public String GetPHOTOID() { return PHOTOID; }
    public String GetPHOTOURL() { return PHOTOURL; }
    public String GetPHOTONAME() { return PHOTONAME; }
    public String GetJCXXID() { return JCXXID; }

    public void setPHOTOID(String PHOTOID) { PHOTOID = PHOTOID; }
    public void setPHOTOURL(String PHOTOURL) { PHOTOURL = PHOTOURL; }
    public void setPHOTONAME(String PHOTONAME) { PHOTONAME = PHOTONAME; }
    public void setJCXXID(String JCXXID) { JCXXID = JCXXID; }

}
