package FBXX.FC;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.TextView;
import com.alibaba.fastjson.JSONObject;
import com.example.administrator.Public.R;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import Common.Base;
import Common.EditPicture;
import Common.WheelStyle;
import Entities.FB_FC_ESF_Model;
import LBXZ.FB_FC;

public class FB_FC_ESF extends Base implements View.OnClickListener {

    public FB_FC_ESF_Model FB_FC_ESF = new FB_FC_ESF_Model();
    public TextView mtvxqmc;
    public TextView mtvmj;
    public TextView mtvsj;
    public TextView mtvts;
    public TextView mtvcx;
    public TextView mtvlc;
    public TextView mtvfwlx;
    public TextView mtvgnlx;
    public TextView mtvcqnx;
    public TextView mtvcqlx;
    public TextView mtvzxqk;
    public TextView mtvfwms;
    public TextView mtvlxrsf;
    public TextView mtvlxrlxdh;
    //自定义的弹出框类
    FB_FC_XQCX xqcxWindow;
    FB_FC_MJ mjWindow;
    FB_FC_SJ sjWindow;
    FB_FC_FWQK fwqkWindow;
    FB_FC_ESF_LXGN lxgnWindow;
    FB_FC_ESF_CQZX cqzxWindow;
    FB_FC_LXRSF lxrsfWindow;
    FB_FC_LXRLXDH lxrlxdhWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_esf);
        Intent intent = getIntent();
        initView();
        String XQMC = intent.getStringExtra("XQMC");
        String YMMC = intent.getStringExtra("YMMC");
        if(YMMC.equalsIgnoreCase("FB_FC_XQCX"))
            mtvxqmc.setText(XQMC);
    }

    //初始化页面
    private void initView() {
        mtvxqmc = (TextView) findViewById(R.id.tv_esf_xqmc);
        mtvts = (TextView) findViewById(R.id.tv_esf_ts);
        mtvcx = (TextView) findViewById(R.id.tv_esf_cx);
        mtvlc = (TextView) findViewById(R.id.tv_esf_lc);
        mtvfwlx = (TextView) findViewById(R.id.tv_esf_fwlx);
        mtvgnlx = (TextView) findViewById(R.id.tv_esf_gnlx);
        mtvcqnx = (TextView) findViewById(R.id.tv_esf_cqnx);
        mtvcqlx = (TextView) findViewById(R.id.tv_esf_cqlx);
        mtvzxqk = (TextView) findViewById(R.id.tv_esf_zx);
        mtvmj = (TextView) findViewById(R.id.tv_esf_mj);
        mtvsj = (TextView) findViewById(R.id.tv_esf_sj);
        mtvfwms = (TextView) findViewById(R.id.tv_esf_fwms);
        mtvlxrsf = (TextView) findViewById(R.id.tv_esf_lxrsf);
        mtvlxrlxdh = (TextView) findViewById(R.id.tv_esf_lxrlxdh);
        findViewById(R.id.iv_back).setOnClickListener(this);
        findViewById(R.id.iv_sczp).setOnClickListener(this);
        findViewById(R.id.ll_esf_xqmc).setOnClickListener(this);
        findViewById(R.id.ll_esf_ts).setOnClickListener(this);
        findViewById(R.id.ll_esf_cx).setOnClickListener(this);
        findViewById(R.id.ll_esf_lc).setOnClickListener(this);
        findViewById(R.id.ll_esf_fwlx).setOnClickListener(this);
        findViewById(R.id.ll_esf_gnlx).setOnClickListener(this);
        findViewById(R.id.ll_esf_cqnx).setOnClickListener(this);
        findViewById(R.id.ll_esf_cqlx).setOnClickListener(this);
        findViewById(R.id.ll_esf_zx).setOnClickListener(this);
        findViewById(R.id.ll_esf_mj).setOnClickListener(this);
        findViewById(R.id.ll_esf_sj).setOnClickListener(this);
        findViewById(R.id.ll_esf_lxrsf).setOnClickListener(this);
        findViewById(R.id.ll_esf_lxrlxdh).setOnClickListener(this);
        findViewById(R.id.tv_dbcd_fb).setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_FC");
                break;
            case R.id.iv_sczp:
                YMTZ("EditPicture");
                break;
            case R.id.ll_esf_xqmc:
                YMTZ("FB_FC_XQCX");
                break;
            case R.id.ll_esf_mj:
                YMTZ("FB_FC_MJ");
                break;
            case R.id.ll_esf_sj:
                YMTZ("FB_FC_SJ");
                break;
            case R.id.ll_esf_ts:
                YMTZ("FB_FC_FWQK_TS");
                break;
            case R.id.ll_esf_cx:
                YMTZ("FB_FC_LXCX_CX");
                break;
            case R.id.ll_esf_lc:
                YMTZ("FB_FC_FWQK_LC");
                break;
            case R.id.ll_esf_fwlx:
                YMTZ("FB_FC_LXGN_FWLX");
                break;
            case R.id.ll_esf_gnlx:
                YMTZ("FB_FC_LXGN_FWLX");
                break;
            case R.id.ll_esf_cqnx:
                YMTZ("FB_FC_CQZX_CQNX");
                break;
            case R.id.ll_esf_cqlx:
                YMTZ("FB_FC_CQZX_CQLX");
                break;
            case R.id.ll_esf_zx:
                YMTZ("FB_FC_CQZX_ZXQK");
                break;
            case R.id.ll_esf_lxrsf:
                YMTZ("FB_FC_LXRSF");
                break;
            case R.id.ll_esf_lxrlxdh:
                YMTZ("FB_FC_LXRLXDH");
                break;
            case R.id.tv_dbcd_fb:
                FB();
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC") {
            Intent intent = new Intent(FB_FC_ESF.this, FB_FC.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "EditPicture") {
            Intent intent = new Intent(FB_FC_ESF.this, EditPicture.class);
            startActivity(intent);
        }
        if (id == "FB_FC_XQCX") {
            xqcxWindow = new FB_FC_XQCX(FB_FC_ESF.this, xqcxOnClick);
            xqcxWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_MJ") {
            mjWindow = new FB_FC_MJ(FB_FC_ESF.this, mjOnClick);
            mjWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            mjWindow.metmj.setText(mtvmj.getText());
        }
        if (id == "FB_FC_SJ") {
            sjWindow = new FB_FC_SJ(FB_FC_ESF.this, sjOnClick);
            sjWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            sjWindow.metsj.setText(mtvsj.getText());
        }
        if (id == "FB_FC_FWQK_TS") {
            fwqkWindow = new FB_FC_FWQK(FB_FC_ESF.this, fwqkOnClick, "TS");
            fwqkWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            fwqkWindow.mtvts.setText(mtvts.getText());
            fwqkWindow.mtvlc.setText(mtvlc.getText());
            fwqkWindow.mwvs.setWheelItemList(WheelStyle.createSString());
            fwqkWindow.mwvt.setWheelItemList(WheelStyle.createTString());
            fwqkWindow.mwvw.setWheelItemList(WheelStyle.createWString());
            fwqkWindow.mwvcx.setWheelItemList(WheelStyle.createCXString());
            fwqkWindow.mwvc.setWheelItemList(WheelStyle.createCString());
            fwqkWindow.mwvgjc.setWheelItemList(WheelStyle.createGJCString());
            fwqkWindow.mwvcx.setCurrentItem(WheelStyle.createCXString().indexOf(mtvcx.getText()));
            if(mtvts.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvs.setCurrentItem(WheelStyle.createSString().indexOf(mtvts.getText().toString().substring(0, mtvts.getText().toString().indexOf("室") + 1)));
                fwqkWindow.mwvt.setCurrentItem(WheelStyle.createTString().indexOf(mtvts.getText().toString().substring(2, mtvts.getText().toString().indexOf("厅") + 1)));
                fwqkWindow.mwvw.setCurrentItem(WheelStyle.createWString().indexOf(mtvts.getText().toString().substring(4, mtvts.getText().toString().indexOf("卫") + 1)));
            }
            if(mtvlc.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvc.setCurrentItem(WheelStyle.createCString().indexOf(mtvlc.getText().toString().substring(0, mtvlc.getText().toString().indexOf("/")) + "层"));
                fwqkWindow.mwvgjc.setCurrentItem(WheelStyle.createGJCString().indexOf("共" + mtvlc.getText().toString().substring(2, 3) + "层"));
            }
        }
        if (id == "FB_FC_FWQK_CX") {
            fwqkWindow = new FB_FC_FWQK(FB_FC_ESF.this, fwqkOnClick, "CX");
            fwqkWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            fwqkWindow.mtvts.setText(mtvts.getText());
            fwqkWindow.mtvcx.setText(mtvcx.getText());
            fwqkWindow.mtvlc.setText(mtvlc.getText());
            fwqkWindow.mwvs.setWheelItemList(WheelStyle.createSString());
            fwqkWindow.mwvt.setWheelItemList(WheelStyle.createTString());
            fwqkWindow.mwvw.setWheelItemList(WheelStyle.createWString());
            fwqkWindow.mwvcx.setWheelItemList(WheelStyle.createCXString());
            fwqkWindow.mwvc.setWheelItemList(WheelStyle.createCString());
            fwqkWindow.mwvgjc.setWheelItemList(WheelStyle.createGJCString());
            fwqkWindow.mwvcx.setCurrentItem(WheelStyle.createCXString().indexOf(mtvcx.getText()));
            if(mtvts.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvs.setCurrentItem(WheelStyle.createSString().indexOf(mtvts.getText().toString().substring(0, mtvts.getText().toString().indexOf("室") + 1)));
                fwqkWindow.mwvt.setCurrentItem(WheelStyle.createTString().indexOf(mtvts.getText().toString().substring(2, mtvts.getText().toString().indexOf("厅") + 1)));
                fwqkWindow.mwvw.setCurrentItem(WheelStyle.createWString().indexOf(mtvts.getText().toString().substring(4, mtvts.getText().toString().indexOf("卫") + 1)));
            }
            if(mtvlc.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvc.setCurrentItem(WheelStyle.createCString().indexOf(mtvlc.getText().toString().substring(0, mtvlc.getText().toString().indexOf("/")) + "层"));
                fwqkWindow.mwvgjc.setCurrentItem(WheelStyle.createGJCString().indexOf("共" + mtvlc.getText().toString().substring(2, 3) + "层"));
            }
        }
        if (id == "FB_FC_FWQK_LC") {
            fwqkWindow = new FB_FC_FWQK(FB_FC_ESF.this, fwqkOnClick, "LC");
            fwqkWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            fwqkWindow.mtvts.setText(mtvts.getText());
            fwqkWindow.mtvlc.setText(mtvlc.getText());
            fwqkWindow.mwvs.setWheelItemList(WheelStyle.createSString());
            fwqkWindow.mwvt.setWheelItemList(WheelStyle.createTString());
            fwqkWindow.mwvw.setWheelItemList(WheelStyle.createWString());
            fwqkWindow.mwvcx.setWheelItemList(WheelStyle.createCXString());
            fwqkWindow.mwvc.setWheelItemList(WheelStyle.createCString());
            fwqkWindow.mwvgjc.setWheelItemList(WheelStyle.createGJCString());
            fwqkWindow.mwvcx.setCurrentItem(WheelStyle.createCXString().indexOf(mtvcx.getText()));
            if(mtvts.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvs.setCurrentItem(WheelStyle.createSString().indexOf(mtvts.getText().toString().substring(0, mtvts.getText().toString().indexOf("室") + 1)));
                fwqkWindow.mwvt.setCurrentItem(WheelStyle.createTString().indexOf(mtvts.getText().toString().substring(2, mtvts.getText().toString().indexOf("厅") + 1)));
                fwqkWindow.mwvw.setCurrentItem(WheelStyle.createWString().indexOf(mtvts.getText().toString().substring(4, mtvts.getText().toString().indexOf("卫") + 1)));
            }
            if(mtvlc.getText().toString().indexOf("请选择") == -1) {
                fwqkWindow.mwvc.setCurrentItem(WheelStyle.createCString().indexOf(mtvlc.getText().toString().substring(0, mtvlc.getText().toString().indexOf("/")) + "层"));
                fwqkWindow.mwvgjc.setCurrentItem(WheelStyle.createGJCString().indexOf("共" + mtvlc.getText().toString().substring(2, mtvlc.getText().length()) + "层"));
            }
        }
        if (id == "FB_FC_LXGN_FWLX") {
            lxgnWindow = new FB_FC_ESF_LXGN(FB_FC_ESF.this, lxgnOnClick, "FWLX");
            lxgnWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            lxgnWindow.mtvfwlx.setText(mtvfwlx.getText());
            lxgnWindow.mtvgnlx.setText(mtvgnlx.getText());
            lxgnWindow.mwvfwlx.setWheelItemList(WheelStyle.createFWLXString());
            lxgnWindow.mwvgnlx.setWheelItemList(WheelStyle.createGNLXString());
            lxgnWindow.mwvfwlx.setCurrentItem(WheelStyle.createFWLXString().indexOf(mtvfwlx.getText()));
            lxgnWindow.mwvgnlx.setCurrentItem(WheelStyle.createGNLXString().indexOf(mtvgnlx.getText()));
        }
        if (id == "FB_FC_LXGN_GNLX") {
            lxgnWindow = new FB_FC_ESF_LXGN(FB_FC_ESF.this, lxgnOnClick, "GNLX");
            lxgnWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            lxgnWindow.mtvfwlx.setText(mtvfwlx.getText());
            lxgnWindow.mtvgnlx.setText(mtvgnlx.getText());
            lxgnWindow.mwvfwlx.setWheelItemList(WheelStyle.createFWLXString());
            lxgnWindow.mwvgnlx.setWheelItemList(WheelStyle.createGNLXString());
            lxgnWindow.mwvfwlx.setCurrentItem(WheelStyle.createFWLXString().indexOf(mtvfwlx.getText()));
            lxgnWindow.mwvgnlx.setCurrentItem(WheelStyle.createGNLXString().indexOf(mtvgnlx.getText()));
        }
        if (id == "FB_FC_CQZX_CQNX") {
            cqzxWindow = new FB_FC_ESF_CQZX(FB_FC_ESF.this, cqzxOnClick, "CQNX");
            cqzxWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            cqzxWindow.mtvcqnx.setText(mtvcqnx.getText());
            cqzxWindow.mtvcqlx.setText(mtvcqlx.getText());
            cqzxWindow.mtvzxqk.setText(mtvzxqk.getText());
            cqzxWindow.mwvcqnx.setWheelItemList(WheelStyle.createCQNXString());
            cqzxWindow.mwvcqlx.setWheelItemList(WheelStyle.createCQLXString());
            cqzxWindow.mwvzxqk.setWheelItemList(WheelStyle.createZXQKString());
        }
        if (id == "FB_FC_CQZX_CQLX") {
            cqzxWindow = new FB_FC_ESF_CQZX(FB_FC_ESF.this, cqzxOnClick, "CQLX");
            cqzxWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            cqzxWindow.mtvcqnx.setText(mtvcqnx.getText());
            cqzxWindow.mtvcqlx.setText(mtvcqlx.getText());
            cqzxWindow.mtvzxqk.setText(mtvzxqk.getText());
            cqzxWindow.mwvcqnx.setWheelItemList(WheelStyle.createCQNXString());
            cqzxWindow.mwvcqlx.setWheelItemList(WheelStyle.createCQLXString());
            cqzxWindow.mwvzxqk.setWheelItemList(WheelStyle.createZXQKString());
        }
        if (id == "FB_FC_CQZX_ZXQK") {
            cqzxWindow = new FB_FC_ESF_CQZX(FB_FC_ESF.this, cqzxOnClick, "ZXQK");
            cqzxWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            cqzxWindow.mtvcqnx.setText(mtvcqnx.getText());
            cqzxWindow.mtvcqlx.setText(mtvcqlx.getText());
            cqzxWindow.mtvzxqk.setText(mtvzxqk.getText());
            cqzxWindow.mwvcqnx.setWheelItemList(WheelStyle.createCQNXString());
            cqzxWindow.mwvcqlx.setWheelItemList(WheelStyle.createCQLXString());
            cqzxWindow.mwvzxqk.setWheelItemList(WheelStyle.createZXQKString());
        }
        if (id == "FB_FC_LXRSF") {
            lxrsfWindow = new FB_FC_LXRSF(FB_FC_ESF.this, lxrsfOnClick);
            lxrsfWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_LXRLXDH") {
            lxrlxdhWindow = new FB_FC_LXRLXDH(FB_FC_ESF.this, lxrlxdhOnClick);
            lxrlxdhWindow.showAtLocation(FB_FC_ESF.this.findViewById(R.id.fb_fc_esf), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "NextStep") {
            Intent intent = new Intent(FB_FC_ESF.this, FB_FC_HZ2.class);
            Bundle bundle = new Bundle();
            bundle.putSerializable("FB_FC_HZ", FB_FC_ESF);
            intent.putExtras(bundle);
            startActivity(intent);
        }
    }


    //发布
    public void FB(){
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    String resultJson = JSONObject.toJSONString(result);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com/FC/FB_FC_ESFJBXX";

                try {
                    String resultJson = JSONObject.toJSONString(FB_FC_ESF);
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair Json = new BasicNameValuePair("Json", resultJson);
                    NameValuePair BCMS = new BasicNameValuePair("BCMS", mtvfwms.getText().toString());
                    NameValuePair FWZP = new BasicNameValuePair("FWZP", "1");
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(Json);
                    parameters.add(BCMS);
                    parameters.add(FWZP);
                    httpRequest.setEntity(new UrlEncodedFormEntity(parameters, "UTF-8"));
                    DefaultHttpClient httpClient = new DefaultHttpClient();
                    if (null != JSESSIONID) httpRequest.setHeader("Cookie", "ASP.NET_SessionId=" + JSESSIONID);

                    HttpResponse response = httpClient.execute(httpRequest); //发起GET请求
                    int rescode = response.getStatusLine().getStatusCode(); //获取响应码
                    result = EntityUtils.toString(response.getEntity(), "utf-8");//获取服务器响应内容
                } catch (Exception e) {
                    e.printStackTrace();
                }
                return result;
            }
        }.execute();
    }

    //小区查询页面按钮监听
    private View.OnClickListener xqcxOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvqx:
                    xqcxWindow.dismiss();
                    break;
                default:
                    xqcxWindow.dismiss();
                    List<View> viewList = Base.getAllChildViews(v);
                    TextView tvxqmc = (TextView)viewList.get(0);
                    mtvxqmc.setText(tvxqmc.getText());

                    FB_FC_ESF.XQMC = tvxqmc.getText().toString();
                    break;
            }
        }
    };

    //面积页面按钮监听
    private View.OnClickListener mjOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    mjWindow.dismiss();
                    break;
                case R.id.tvqd:
                    mjWindow.dismiss();
                    mtvmj.setText(mjWindow.metmj.getText());

                    FB_FC_ESF.PFM = mjWindow.metmj.getText().toString();
                    break;
            }
        }
    };

    //售价页面按钮监听
    private View.OnClickListener sjOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    sjWindow.dismiss();
                    break;
                case R.id.tvqd:
                    sjWindow.dismiss();
                    mtvsj.setText(sjWindow.metsj.getText());

                    FB_FC_ESF.SJ = new BigDecimal(sjWindow.metsj.getText().toString().replace("元",""));
                    break;
            }
        }
    };

    //房屋情况页面按钮监听
    private View.OnClickListener fwqkOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_lc_qd:
                    fwqkWindow.dismiss();
                    mtvts.setText(fwqkWindow.mtvts.getText());
                    mtvcx.setText(fwqkWindow.mtvcx.getText());
                    mtvlc.setText(WheelStyle.createCString().get(fwqkWindow.mwvc.getCurrentItem()).replace("层","") + "/" + WheelStyle.createGJCString().get(fwqkWindow.mwvgjc.getCurrentItem()).replace("共","").replace("层",""));

                    FB_FC_ESF.S = WheelStyle.createSString().get(fwqkWindow.mwvs.getCurrentItem());
                    FB_FC_ESF.T = WheelStyle.createTString().get(fwqkWindow.mwvt.getCurrentItem());
                    FB_FC_ESF.W = WheelStyle.createWString().get(fwqkWindow.mwvw.getCurrentItem());
                    FB_FC_ESF.CX = fwqkWindow.mtvcx.getText().toString();
                    FB_FC_ESF.C = WheelStyle.createCString().get(fwqkWindow.mwvc.getCurrentItem()).replace("层","");
                    FB_FC_ESF.GJC = WheelStyle.createGJCString().get(fwqkWindow.mwvc.getCurrentItem()).replace("层","");
                    break;
            }
        }
    };

    //类型供暖页面按钮监听
    private View.OnClickListener lxgnOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_gnlx_qd:
                    lxgnWindow.dismiss();
                    mtvfwlx.setText(WheelStyle.createFWLXString().get(lxgnWindow.mwvfwlx.getCurrentItem()));
                    mtvgnlx.setText(WheelStyle.createGNLXString().get(lxgnWindow.mwvgnlx.getCurrentItem()));
                    break;
            }
        }
    };

    //产权装修页面按钮监听
    private View.OnClickListener cqzxOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_zxqk_qd:
                    cqzxWindow.dismiss();
                    mtvcqnx.setText(cqzxWindow.mtvcqnx.getText());
                    mtvcqlx.setText(cqzxWindow.mtvcqlx.getText());
                    mtvzxqk.setText(WheelStyle.createZXQKString().get(cqzxWindow.mwvzxqk.getCurrentItem()));
                    break;
            }
        }
    };

    //联系人身份页面按钮监听
    private View.OnClickListener lxrsfOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvwc:
                    lxrsfWindow.dismiss();
                    mtvlxrsf.setText(lxrsfWindow.GetCheck());

                    break;
            }
        }
    };

    //联系人联系电话页面按钮监听
    private View.OnClickListener lxrlxdhOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    lxrlxdhWindow.dismiss();
                    break;
                case R.id.tvqd:
                    lxrlxdhWindow.dismiss();
                    mtvlxrlxdh.setText(lxrlxdhWindow.metLXDH.getText());

                    FB_FC_ESF.LXDH = lxrlxdhWindow.metLXDH.getText().toString();
                    break;
            }
        }
    };
}
