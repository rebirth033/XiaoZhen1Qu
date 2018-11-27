package FBXX.FC;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import com.example.administrator.Public.R;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
import java.util.ArrayList;
import java.util.List;
import Common.Base;
import Entities.FB_FC_HZ_Model;
import com.alibaba.fastjson.JSONObject;

public class FB_FC_HZ2 extends Base implements View.OnClickListener {

    private LinearLayout mllfwpz;
    private LinearLayout mllfwms;
    private TextView mtvfwpz;
    private TextView mtvkfsj;
    private TextView mtvzkxb;
    private TextView mtvrzsj;
    private TextView mtvfb;
    private TextView mtvfwms;
    private TextView mtvlxrsf;
    private TextView mtvlxrlxdh;
    private ImageView mivback;
    //自定义的弹出框类
    FB_FC_FWPZ fwpzWindow;
    FB_FC_ZKYQ rzxxWindow;
    FB_FC_LXRSF lxrsfWindow;
    FB_FC_LXRLXDH lxrlxdhWindow;
    public FB_FC_HZ_Model fb_fc_hz = new FB_FC_HZ_Model();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_hz2);

        Intent intent  = this.getIntent();
        fb_fc_hz = (FB_FC_HZ_Model)intent.getSerializableExtra("FB_FC_HZ");

        initView();

        String YMMC = intent.getStringExtra("YMMC");
        String FWMS = intent.getStringExtra("FWMS");
        if(!(null == YMMC))
            if(YMMC.equalsIgnoreCase("FB_FC_FWMS"))
                mtvfwms.setText(FWMS);
    }

    //初始化页面
    private void initView() {
        mllfwpz = (LinearLayout) findViewById(R.id.ll_hz_fwpz);
        mllfwms = (LinearLayout) findViewById(R.id.ll_hz_fwms);
        mtvfb = (TextView) findViewById(R.id.tv_dbcd_fb);
        mtvfwpz = (TextView) findViewById(R.id.tv_hz_fwpz);
        mtvfwms = (TextView) findViewById(R.id.tv_hz_fwms);
        mtvlxrsf = (TextView) findViewById(R.id.tv_hz_lxrsf);
        mtvlxrlxdh = (TextView) findViewById(R.id.tv_hz_lxrlxdh);
        mivback = (ImageView) findViewById(R.id.iv_back);

        ViewGroup mllkfsj = (ViewGroup) findViewById(R.id.ll_hz_kfsj);
        ViewGroup mllzkxb = (ViewGroup) findViewById(R.id.ll_hz_zkxb);
        ViewGroup mllrzsj = (ViewGroup) findViewById(R.id.ll_hz_rzsj);
        ViewGroup mlllxrsf = (ViewGroup) findViewById(R.id.ll_hz_lxrsf);
        ViewGroup mlllxrlxdh = (ViewGroup) findViewById(R.id.ll_hz_lxrlxdh);

        mtvkfsj = (TextView) findViewById(R.id.tv_hz_kfsj);
        mtvzkxb = (TextView) findViewById(R.id.tv_hz_zkxb);
        mtvrzsj = (TextView) findViewById(R.id.tv_hz_rzsj);

        mllfwpz.setOnClickListener(this);
        mllfwms.setOnClickListener(this);
        mtvfb.setOnClickListener(this);
        mivback.setOnClickListener(this);
        mllkfsj.setOnClickListener(this);
        mllzkxb.setOnClickListener(this);
        mllrzsj.setOnClickListener(this);
        mlllxrsf.setOnClickListener(this);
        mlllxrlxdh.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_FC_HZ");
                break;
            case R.id.ll_hz_fwpz:
                YMTZ("FB_FC_FWPZ");
                break;
            case R.id.ll_hz_fwms:
                YMTZ("FB_FC_FWMS");
                break;
            case R.id.tv_dbcd_fb:
                FB();
                break;
            case R.id.ll_hz_kfsj:
                YMTZ("FB_FC_KFSJ");
                break;
            case R.id.ll_hz_zkxb:
                YMTZ("FB_FC_ZKXB");
                break;
            case R.id.ll_hz_rzsj:
                YMTZ("FB_FC_RZSJ");
                break;
            case R.id.ll_hz_lxrsf:
                YMTZ("FB_FC_LXRSF");
                break;
            case R.id.ll_hz_lxrlxdh:
                YMTZ("FB_FC_LXRLXDH");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC_HZ") {
            Intent intent = new Intent(FB_FC_HZ2.this, FB_FC_HZ.class);
            intent.putExtra("YMMC", "FB_FC_HZ2");//设置参数
            startActivity(intent);
        }
        if (id == "FB_FC_KFSJ") {
            rzxxWindow = new FB_FC_ZKYQ(FB_FC_HZ2.this, rzxxOnClick, "KFSJ");
            rzxxWindow.showAtLocation(FB_FC_HZ2.this.findViewById(R.id.fb_fc_hz2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            rzxxWindow.mtvkfsj.setText(mtvkfsj.getText());
            rzxxWindow.mtvzkxb.setText(mtvzkxb.getText());
            rzxxWindow.mtvrzsj.setText(mtvrzsj.getText());
            rzxxWindow.mwvkfsj.setWheelItemList(WheelStyle.createKFSJString());
            rzxxWindow.mwvzkxb.setWheelItemList(WheelStyle.createZKXBString());
            rzxxWindow.mwvyear.setWheelItemList(WheelStyle.createYearString());
            rzxxWindow.mwvmonth.setWheelItemList(WheelStyle.createMonthString());
            rzxxWindow.mwvday.setWheelItemList(WheelStyle.createDayString());
            rzxxWindow.mwvkfsj.setCurrentItem(WheelStyle.createKFSJString().indexOf(mtvkfsj.getText()));
            rzxxWindow.mwvzkxb.setCurrentItem(WheelStyle.createZKXBString().indexOf(mtvzkxb.getText()));
            if(mtvrzsj.getText().toString().indexOf("请选择") == -1) {
                rzxxWindow.mwvyear.setCurrentItem(WheelStyle.createYearString().indexOf(mtvrzsj.getText().toString().substring(0, mtvrzsj.getText().toString().indexOf("年") + 1)));
                rzxxWindow.mwvmonth.setCurrentItem(WheelStyle.createMonthString().indexOf(mtvrzsj.getText().toString().substring(5, mtvrzsj.getText().toString().indexOf("月") + 1)));
                rzxxWindow.mwvday.setCurrentItem(WheelStyle.createDayString().indexOf(mtvrzsj.getText().toString().substring(7, mtvrzsj.getText().toString().indexOf("日") + 1)));
            }
        }
        if (id == "FB_FC_ZKXB") {
            rzxxWindow = new FB_FC_ZKYQ(FB_FC_HZ2.this, rzxxOnClick, "ZKXB");
            rzxxWindow.showAtLocation(FB_FC_HZ2.this.findViewById(R.id.fb_fc_hz2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            rzxxWindow.mtvkfsj.setText(mtvkfsj.getText());
            rzxxWindow.mtvzkxb.setText(mtvzkxb.getText());
            rzxxWindow.mtvrzsj.setText(mtvrzsj.getText());
            rzxxWindow.mwvkfsj.setWheelItemList(WheelStyle.createKFSJString());
            rzxxWindow.mwvzkxb.setWheelItemList(WheelStyle.createZKXBString());
            rzxxWindow.mwvyear.setWheelItemList(WheelStyle.createYearString());
            rzxxWindow.mwvmonth.setWheelItemList(WheelStyle.createMonthString());
            rzxxWindow.mwvday.setWheelItemList(WheelStyle.createDayString());
            rzxxWindow.mwvkfsj.setCurrentItem(WheelStyle.createKFSJString().indexOf(mtvkfsj.getText()));
            rzxxWindow.mwvzkxb.setCurrentItem(WheelStyle.createZKXBString().indexOf(mtvzkxb.getText()));
            if(mtvrzsj.getText().toString().indexOf("请选择") == -1) {
                rzxxWindow.mwvyear.setCurrentItem(WheelStyle.createYearString().indexOf(mtvrzsj.getText().toString().substring(0, mtvrzsj.getText().toString().indexOf("年") + 1)));
                rzxxWindow.mwvmonth.setCurrentItem(WheelStyle.createMonthString().indexOf(mtvrzsj.getText().toString().substring(5, mtvrzsj.getText().toString().indexOf("月") + 1)));
                rzxxWindow.mwvday.setCurrentItem(WheelStyle.createDayString().indexOf(mtvrzsj.getText().toString().substring(7, mtvrzsj.getText().toString().indexOf("日") + 1)));
            }
        }
        if (id == "FB_FC_RZSJ") {
            rzxxWindow = new FB_FC_ZKYQ(FB_FC_HZ2.this, rzxxOnClick, "RZSJ");
            rzxxWindow.showAtLocation(FB_FC_HZ2.this.findViewById(R.id.fb_fc_hz2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            rzxxWindow.mtvkfsj.setText(mtvkfsj.getText());
            rzxxWindow.mtvzkxb.setText(mtvzkxb.getText());
            rzxxWindow.mtvrzsj.setText(mtvrzsj.getText());
            rzxxWindow.mwvkfsj.setWheelItemList(WheelStyle.createKFSJString());
            rzxxWindow.mwvzkxb.setWheelItemList(WheelStyle.createZKXBString());
            rzxxWindow.mwvyear.setWheelItemList(WheelStyle.createYearString());
            rzxxWindow.mwvmonth.setWheelItemList(WheelStyle.createMonthString());
            rzxxWindow.mwvday.setWheelItemList(WheelStyle.createDayString());
            rzxxWindow.mwvkfsj.setCurrentItem(WheelStyle.createKFSJString().indexOf(mtvkfsj.getText()));
            rzxxWindow.mwvzkxb.setCurrentItem(WheelStyle.createZKXBString().indexOf(mtvzkxb.getText()));
            if(mtvrzsj.getText().toString().indexOf("请选择") == -1) {
                rzxxWindow.mwvyear.setCurrentItem(WheelStyle.createYearString().indexOf(mtvrzsj.getText().toString().substring(0, mtvrzsj.getText().toString().indexOf("年") + 1)));
                rzxxWindow.mwvmonth.setCurrentItem(WheelStyle.createMonthString().indexOf(mtvrzsj.getText().toString().substring(5, mtvrzsj.getText().toString().indexOf("月") + 1)));
                rzxxWindow.mwvday.setCurrentItem(WheelStyle.createDayString().indexOf(mtvrzsj.getText().toString().substring(7, mtvrzsj.getText().toString().indexOf("日") + 1)));
            }
        }
        if (id == "FB_FC_FWPZ") {
            fwpzWindow = new FB_FC_FWPZ(FB_FC_HZ2.this, fwpzOnClick);
            fwpzWindow.showAtLocation(FB_FC_HZ2.this.findViewById(R.id.fb_fc_hz2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            fwpzWindow.SetFWPZ(mtvfwpz.getText().toString());
        }
        if (id == "FB_FC_FWMS") {
            Intent intent = new Intent(FB_FC_HZ2.this, FB_FC_FWMS.class);
            startActivity(intent);
        }
        if (id == "FB_FC_LXRSF") {
            lxrsfWindow = new FB_FC_LXRSF(FB_FC_HZ2.this, lxrsfOnClick);
            lxrsfWindow.showAtLocation(FB_FC_HZ2.this.findViewById(R.id.fb_fc_hz2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_FC_LXRLXDH") {
            lxrlxdhWindow = new FB_FC_LXRLXDH(FB_FC_HZ2.this, lxrlxdhOnClick);
            lxrlxdhWindow.showAtLocation(FB_FC_HZ2.this.findViewById(R.id.fb_fc_hz2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
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
                String targeturl = "http://www.915fl.com/FC/FBFC_HZFJBXX";

                try {
                    String resultJson = JSONObject.toJSONString(fb_fc_hz);
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

    //房屋配置页面按钮监听
    private View.OnClickListener fwpzOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tvwc:
                    fwpzWindow.dismiss();
                    mtvfwpz.setText(fwpzWindow.GetFWPZ());

                    fb_fc_hz.FWPZ = mtvfwpz.getText().toString();
                break;
            }
        }
    };

    //租客要求页面按钮监听
    private View.OnClickListener rzxxOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_rzsj_qd:
                    rzxxWindow.dismiss();
                    mtvkfsj.setText(rzxxWindow.mtvkfsj.getText());
                    mtvzkxb.setText(rzxxWindow.mtvzkxb.getText());
                    mtvrzsj.setText(WheelStyle.createYearString().get(rzxxWindow.mwvyear.getCurrentItem()) + WheelStyle.createMonthString().get(rzxxWindow.mwvmonth.getCurrentItem()) + WheelStyle.createDayString().get(rzxxWindow.mwvday.getCurrentItem()));

                    fb_fc_hz.KFSJ = mtvkfsj.getText().toString();
                    fb_fc_hz.ZKXB = mtvzkxb.getText().toString();
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

                    fb_fc_hz.LXDH = lxrlxdhWindow.metLXDH.getText().toString();
                    break;
            }
        }
    };
}