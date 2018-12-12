package FBXX.CL;

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
import Entities.CL_JC_Model;
import FBXX.FC.FB_FC_LXRLXDH;
import FBXX.FC.FB_FC_LXRSF;
import FBXX.FC.FB_FC_SJ;

public class FB_CL_JC2 extends Base implements View.OnClickListener {

    public CL_JC_Model fb_cl_jc = new CL_JC_Model();
    public EditText metkcdd;
    public TextView mtvpzxx;
    public TextView mtvghcs;
    public TextView mtvjzpz;
    public TextView mtvckms;
    public TextView mtvlxrsf;
    public TextView mtvlxrlxdh;

    //自定义的弹出框类
    FB_CL_JC_PP ppWindow;
    FB_FC_SJ jgWindow;
    FB_CL_JC_GHCS ghcsWindow;
    FB_CL_JC_JZPZ jzpzWindow;
    FB_FC_LXRSF lxrsfWindow;
    FB_FC_LXRLXDH lxrlxdhWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_cl_jc2);
        Intent intent  = this.getIntent();
        fb_cl_jc = (CL_JC_Model)intent.getSerializableExtra("FB_CL_JC");


        String YMMC = intent.getStringExtra("YMMC");
        String CKMS = intent.getStringExtra("CKMS");
        if(!(null == YMMC))
            if(YMMC.equalsIgnoreCase("FB_CL_CKMS"))
                mtvckms.setText(CKMS);

        initView();
    }

    //初始化页面
    private void initView() {
        findViewById(R.id.iv_back).setOnClickListener(this);
        findViewById(R.id.ll_jc_kcdd).setOnClickListener(this);
        findViewById(R.id.ll_jc_pzxx).setOnClickListener(this);
        findViewById(R.id.ll_jc_ghcs).setOnClickListener(this);
        findViewById(R.id.ll_jc_jzpz).setOnClickListener(this);
        findViewById(R.id.ll_jc_ckms).setOnClickListener(this);
        findViewById(R.id.ll_jc_lxrsf).setOnClickListener(this);
        findViewById(R.id.ll_jc_lxrlxdh).setOnClickListener(this);
        findViewById(R.id.tv_dbcd_fb).setOnClickListener(this);

        metkcdd = (EditText) findViewById(R.id.et_jc_kcdd);
        mtvpzxx = (TextView) findViewById(R.id.tv_jc_pzxx);
        mtvghcs = (TextView) findViewById(R.id.tv_jc_ghcs);
        mtvjzpz = (TextView) findViewById(R.id.tv_jc_jzpz);
        mtvckms = (TextView) findViewById(R.id.tv_jc_ckms);
        mtvlxrsf = (TextView) findViewById(R.id.tv_jc_lxrsf);
        mtvlxrlxdh = (TextView) findViewById(R.id.tv_jc_lxrlxdh);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_CL_JC");
                break;
            case R.id.tv_dbcd_fb:
                FB();
                break;
            case R.id.ll_jc_kcdd:
                YMTZ("FB_CL_JC_KCDD");
                break;
            case R.id.ll_jc_pzxx:
                YMTZ("FB_CL_JC_PZXX");
                break;
            case R.id.ll_jc_ghcs:
                YMTZ("FB_CL_JC_GHCS");
                break;
            case R.id.ll_jc_jzpz:
                YMTZ("FB_CL_JC_JZPZ");
                break;
            case R.id.ll_jc_jg:
                YMTZ("FB_CL_JG");
                break;
            case R.id.ll_jc_ckms:
                YMTZ("FB_CL_CKMS");
                break;
            case R.id.tv_jc_lxrsf:
                YMTZ("FB_LXRSF");
                break;
            case R.id.tv_jc_lxrlxdh:
                YMTZ("FB_LXRLXDH");
        }
    }

    //页面跳转
    public void YMTZ(String id) {

        if (id == "FB_CL_JC") {
            Intent intent = new Intent(FB_CL_JC2.this, FB_CL_JC.class);
            startActivity(intent);
        }
        if (id == "FB_CL_JC_GHCS") {
            ghcsWindow = new FB_CL_JC_GHCS(FB_CL_JC2.this, ghcsOnClick);
            ghcsWindow.showAtLocation(FB_CL_JC2.this.findViewById(R.id.fb_cl_jc2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            ghcsWindow.mwvghcs.setWheelItemList(WheelStyle.createGHCSString());
        }
        if (id == "FB_CL_JC_JZPZ") {
            jzpzWindow = new FB_CL_JC_JZPZ(FB_CL_JC2.this, jzpzOnClick);
            jzpzWindow.showAtLocation(FB_CL_JC2.this.findViewById(R.id.fb_cl_jc2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_CL_CKMS") {
            Intent intent = new Intent(FB_CL_JC2.this, FB_CL_JC_CKMS.class);
            intent.putExtra("YMMC", "FB_CL_JC2");//设置参数
            startActivity(intent);
        }
        if (id == "FB_FC_LXRSF") {
            lxrsfWindow = new FB_FC_LXRSF(FB_CL_JC2.this, lxrsfOnClick);
            lxrsfWindow.showAtLocation(FB_CL_JC2.this.findViewById(R.id.fb_cl_jc2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_LXRLXDH") {
            lxrlxdhWindow = new FB_FC_LXRLXDH(FB_CL_JC2.this, lxrlxdhOnClick);
            lxrlxdhWindow.showAtLocation(FB_CL_JC2.this.findViewById(R.id.fb_cl_jc2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
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
                String targeturl = "http://www.915fl.com/FC/FB_CL_JCJBXX";

                try {
                    String resultJson = JSONObject.toJSONString(fb_cl_jc);
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair Json = new BasicNameValuePair("Json", resultJson);
                    NameValuePair BCMS = new BasicNameValuePair("BCMS", mtvckms.getText().toString());
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


    //加装配置页面按钮监听
    private View.OnClickListener jzpzOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvwc:
                    jzpzWindow.dismiss();
                    mtvjzpz.setText(jzpzWindow.GetCheck());

                    fb_cl_jc.CLJZPZ = jzpzWindow.GetCheck();
                    break;
            }
        }
    };

    //过户次数按钮监听
    private View.OnClickListener ghcsOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    ghcsWindow.dismiss();
                    break;
                case R.id.tv_ghcs_qd:
                    ghcsWindow.dismiss();
                    mtvghcs.setText(WheelStyle.createGHCSString().get(ghcsWindow.mwvghcs.getCurrentItem()));

                    fb_cl_jc.GHCS = ghcsWindow.mtvghcs.getText().toString();
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

                    fb_cl_jc.LXDH = lxrlxdhWindow.metLXDH.getText().toString();
                    break;
            }
        }
    };
}
