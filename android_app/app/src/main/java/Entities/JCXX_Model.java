package Entities;

import java.io.Serializable;
import java.sql.Timestamp;
import java.util.List;

public class JCXX_Model implements Serializable {

    public String JCXXID;
    public String YHID;
    public Timestamp CJSJ;
    public Timestamp ZXGXSJ;
    public int LLCS;
    public String LXR;
    public String LXDH;
    public String LXDZ;
    public String QQ;
    public String BT;
    public String DH;
    public int STATUS;
    public int XZQDM;
    public int LBID;
    public int ISHOT;
    public List<Photo_Model> PHOTOS;

}
