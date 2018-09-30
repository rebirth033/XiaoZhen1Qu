package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONObject;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

public class GRZX_Main extends Base implements OnClickListener {

    private ImageView iv_grzx_djtxdl;
    private TextView tv_grzx_djtxdl;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.grzx_main);
        resetBottomMenu();
        ImageView ivsy_grzx = (ImageView) findViewById(R.id.ivGRZX);
        ivsy_grzx.setImageResource(R.drawable.dbcd_grzx_active);
        findById();
    }

    //初始化控件
    private void findById() {
        ViewGroup vgfb = (ViewGroup) findViewById(R.id.llFB);
        ViewGroup vgxx = (ViewGroup) findViewById(R.id.llXX);
        ViewGroup vgsy = (ViewGroup) findViewById(R.id.llSY);
        iv_grzx_djtxdl = (ImageView) findViewById(R.id.ivDJTXDL);
        tv_grzx_djtxdl = (TextView) findViewById(R.id.tvDJTXDL);
        LinearLayout ll_grzx_wdfb = (LinearLayout) findViewById(R.id.llWDFB);
        vgfb.setOnClickListener(this);
        vgxx.setOnClickListener(this);
        vgsy.setOnClickListener(this);
        iv_grzx_djtxdl.setOnClickListener(this);
        ll_grzx_wdfb.setOnClickListener(this);

        try {
            GetGRXX();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.llSY:
                YMTZ("SY");
                break;
            case R.id.llFB:
                YMTZ("FB");
                break;
            case R.id.llXX:
                YMTZ("XX");
                break;
            case R.id.llGRZX:
                YMTZ("GRZX");
                break;
            case R.id.ivDJTXDL:
                YMTZ("YHDL");
                break;
            case R.id.llWDFB:
                if (tv_grzx_djtxdl.getText() != "")
                    YMTZ("WDFB");
                else
                    YMTZ("YHDL");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if (id == "SY") {
            Intent intent = new Intent(GRZX_Main.this, SY_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FB") {
            Intent intent = new Intent(GRZX_Main.this, FB_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "XX") {
            Intent intent = new Intent(GRZX_Main.this, XX_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "YHDL") {
            Intent intent = new Intent(GRZX_Main.this, YHDL.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "WDFB") {
            Intent intent = new Intent(GRZX_Main.this, GRZX_WDFB.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }

    //获取个人信息
    public void GetGRXX() {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String Result = jsonobject.getString("Result");
                    String YHJBXX = jsonobject.getString("YHJBXX");
                    JSONObject jsonyhjbxx = new JSONObject(YHJBXX.toString());

                    if (Result.indexOf("1") != -1) {
                        URL picUrl = new URL("http://www.915fl.com/Areas/Business/Photos/" + jsonyhjbxx.getString("YHID") + "/GRZL/TX.jpg?j=" + Math.random());
                        Bitmap pngBM = BitmapFactory.decodeStream(picUrl.openStream());
                        iv_grzx_djtxdl.setImageBitmap(pngBM);
                        tv_grzx_djtxdl.setText(jsonyhjbxx.getString("YHM"));
                        YHM = jsonyhjbxx.getString("YHM");
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com/GRZL/GetGRZL";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    httpRequest.setEntity(new UrlEncodedFormEntity(parameters, "UTF-8"));
                    DefaultHttpClient httpClient = new DefaultHttpClient();
                    if (null != JSESSIONID) {
                        httpRequest.setHeader("Cookie", "ASP.NET_SessionId=" + JSESSIONID);
                    }
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
}
