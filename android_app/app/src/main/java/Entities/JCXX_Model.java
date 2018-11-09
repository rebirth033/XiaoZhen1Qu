package Entities;

import java.io.Serializable;
import java.sql.Timestamp;
import java.util.List;

public class JCXX_Model  implements Serializable {

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

    public String GetJCXXID() { return JCXXID; }
    public String GetYHID() { return YHID; }
    public Timestamp GetCJSJ() { return CJSJ; }
    public Timestamp GetZXGXSJ() { return ZXGXSJ; }
    public int GetLLCS() { return LLCS; }
    public String GetLXR() { return LXR; }
    public String GetLXDH() { return LXDH; }
    public String GetLXDZ() { return LXDZ; }
    public String GetQQ() { return QQ; }
    public String GetBT() { return BT; }
    public String GetDH() { return DH; }
    public int GetSTATUS() { return STATUS; }
    public int GetXZQDM() { return XZQDM; }
    public int GetLBID() { return LBID; }
    public int GetISHOT() { return ISHOT; }
    public List<Photo_Model> GetPHOTOS() { return PHOTOS; }

    public void setJCXXID(String JCXXID) { JCXXID = JCXXID; }
    public void setYHID(String YHID) { YHID = YHID; }
    public void setCJSJ(String CJSJ) { CJSJ = CJSJ; }
    public void setZXGXSJ(String ZXGXSJ) { ZXGXSJ = ZXGXSJ; }
    public void setLLCS(String LLCS) { LLCS = LLCS; }
    public void setLXR(String LXR) { LXR = LXR; }
    public void setLXDH(String LXDH) { LXDH = LXDH; }
    public void setLXDZ(String LXDZ) { LXDZ = LXDZ; }
    public void setQQ(String QQ) { QQ = QQ; }
    public void setBT(String BT) { BT = BT; }
    public void setDH(String DH) { DH = DH; }
    public void setSTATUS(String STATUS) { STATUS = STATUS; }
    public void setXZQDM(String XZQDM) { XZQDM = XZQDM; }
    public void setLBID(String LBID) { LBID = LBID; }
    public void setISHOT(String ISHOT) { ISHOT = ISHOT; }
    public void setPHOTOS(String PHOTOS) { PHOTOS = PHOTOS; }
}
