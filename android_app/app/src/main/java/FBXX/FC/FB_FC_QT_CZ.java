package FBXX.FC;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.EditText;
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
import Common.WheelStyle;
import Entities.FB_FC_CF_Model;

public class FB_FC_QT_CZ extends Base implements View.OnClickListener {

    public FB_FC_CF_Model fb_fc_qt = new FB_FC_CF_Model();
    public TextView mtvqy;
    public TextView mtvlx;
    public TextView metbt;
    public TextView metms;
    public TextView mtvmj;
    public TextView mtvzj;
    public TextView mtvlxrsf;
    public TextView mtvlxrlxdh;

    //自定义的弹出框类
    FB_FC_QT_LX qtlxWindow;
    FB_FC_MJ mjWindow;
    FB_FC_ZJ zjWindow;
    FB_FC_LXRSF lxrsfWindow;
    FB_FC_LXRLXDH lxrlxdhWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_qt_cz);
        initView();
    }

    //初始化页面
    private void initView() {
        findViewById(R.id.iv_back).setOnClickListener(this);
        findViewById(R.id.ll_qt_lx).setOnClickListener(this);
        findViewById(R.id.ll_qt_mj).setOnClickListener(this);
        findViewById(R.id.ll_qt_zj).setOnClickListener(this);
        findViewById(R.id.ll_qt_lxrsf).setOnClickListener(this);
        findViewById(R.id.ll_qt_lxrlxdh).setOnClickListener(this);
        findViewById(R.id.tv_dbcd_fb).setOnClickListener(this);

        mtvlx = (TextView) findViewById(R.id.tv_qt_lx);
        mtvmj = (TextView) findViewById(R.id.tv_qt_mj);
        mtvzj = (TextView) findViewById(R.id.tv_qt_zj);
        metms = (EditText) findViewById(R.id.et_qt_ms);
        mtvlxrsf = (TextView) findViewById(R.id.tv_qt_lxrsf);
        mtvlxrlxdh = (TextView) findViewById(R.id.tv_qt_lxrlxdh);

        mtvlxrsf.setOnClickListener(this);
        mtvlxrlxdh.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_FC_QT_LB");
                break;
            case R.id.tv_dbcd_fb:
                FB();
                break;
            case R.id.ll_qt_lx:
                YMTZ("FB_FC_QT_LX");
                break;
            case R.id.ll_qt_mj:
                YMTZ("FB_FC_MJ");
                break;
            case R.id.ll_qt_zj:
                YMTZ("FB_FC_ZJ");
                break;
            case R.id.tv_qt_lxrsf:
                YMTZ("FB_FC_LXRSF");
                break;
            case R.id.tv_qt_lxrlxdh:
                YMTZ("FB_FC_LXRLXDH");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC_QT_LB") {
            Intent intent = new Intent(FB_FC_QT_CZ.this, FB_FC_QT_LB.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB_FC_QT_LX") {
            qtlxWindow = new FB_FC_QT_LX(FB_FC_QT_CZ.this, qtlxOnClick);
            qtlxWindow.showAtLocation(FB_FC_QT_CZ.this.findViewById(R.id.fb_fc_qt_cz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            qtlxWindow.mtvlx.setText(mtvlx.getText());
            qtlxWindow.mwvlx.setWheelItemList(WheelStyle.createQTLXString());
        }
        if (id == "FB_FC_MJ") {
            mjWindow = new FB_FC_MJ(FB_FC_QT_CZ.this, mjOnClick);
            mjWindow.showAtLocation(FB_FC_QT_CZ.this.findViewById(R.id.fb_fc_qt_cz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            mjWindow.metmj.setText(mtvmj.getText());
        }
        if (id == "FB_FC_ZJ") {
            zjWindow = new FB_FC_ZJ(FB_FC_QT_CZ.this, zjOnClick);
            zjWindow.showAtLocation(FB_FC_QT_CZ.this.findViewById(R.id.fb_fc_qt_cz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            zjWindow.metzj.setText(mtvzj.getText());
        }
        if (id == "FB_FC_LXRSF") {
            lxrsfWindow = new FB_FC_LXRSF(FB_FC_QT_CZ.this, lxrsfOnClick);
            lxrsfWindow.showAtLocation(FB_FC_QT_CZ.this.findViewById(R.id.fb_fc_qt_cz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_LXRLXDH") {
            lxrlxdhWindow = new FB_FC_LXRLXDH(FB_FC_QT_CZ.this, lxrlxdhOnClick);
            lxrlxdhWindow.showAtLocation(FB_FC_QT_CZ.this.findViewById(R.id.fb_fc_qt_cz), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
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
                String targeturl = "http://www.915fl.com/FC/FBFC_qtJBXX";

                try {
                    String resultJson = JSONObject.toJSONString(fb_fc_qt);
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair Json = new BasicNameValuePair("Json", resultJson);
                    NameValuePair BCMS = new BasicNameValuePair("BCMS", metms.getText().toString());
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

    //其他类型页面按钮监听
    private View.OnClickListener qtlxOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_qtlx_qd:
                    qtlxWindow.dismiss();
                    mtvlx.setText(WheelStyle.createQTLXString().get(qtlxWindow.mwvlx.getCurrentItem()));
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

                    fb_fc_qt.PFM = mjWindow.metmj.getText().toString();
                    break;
            }
        }
    };

    //租金页面按钮监听
    private View.OnClickListener zjOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    zjWindow.dismiss();
                    break;
                case R.id.tvqd:
                    zjWindow.dismiss();
                    mtvzj.setText(zjWindow.metzj.getText());

                    fb_fc_qt.ZJ = new BigDecimal(zjWindow.metzj.getText().toString().replace("元","").replace("/","").replace("月",""));
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

                    fb_fc_qt.LXDH = lxrlxdhWindow.metLXDH.getText().toString();
                    break;
            }
        }
    };
}
