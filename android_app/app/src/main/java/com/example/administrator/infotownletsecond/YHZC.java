package com.example.administrator.infotownletsecond;

import android.app.AlertDialog;
import android.os.AsyncTask;
import android.os.CountDownTimer;
import android.os.Handler;
import android.os.Bundle;
import android.graphics.Color;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.view.View.OnClickListener;
import android.content.Intent;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.CookieStore;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.cookie.Cookie;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
import org.json.JSONObject;
import java.util.ArrayList;
import java.util.List;

public class YHZC extends Base implements OnClickListener {
    private EditText metSJH;
    private EditText metYZM;
    private EditText metMM;
    private TextView mtvHQYZM;
    private TextView mtvDL;
    private TextView mtvGB;
    private TextView mbtnZC;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.yhzc);
        metSJH = (EditText) findViewById(R.id.etSJH);
        metYZM = (EditText) findViewById(R.id.etYZM);
        metMM = (EditText) findViewById(R.id.etMM);
        mtvHQYZM = (TextView) findViewById(R.id.tvHQYZM);
        mtvDL = (TextView) findViewById(R.id.tvDL);
        mtvGB = (TextView) findViewById(R.id.tvGB);
        mbtnZC = (Button) findViewById(R.id.btnZC);
        mtvHQYZM.setOnClickListener(this);
        mtvDL.setOnClickListener(this);
        mbtnZC.setOnClickListener(this);
        BindSJ();
    }

    //绑定手机
    public void BindSJ() {
        metSJH.addTextChangedListener(new TextWatcher() {
            public void afterTextChanged(Editable s) {
                if (metSJH.getText().length() == 11)
                    mtvHQYZM.setTextColor(Color.parseColor("#bc6ba6"));
            }

            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }
        });
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.tvHQYZM:
                if (mtvHQYZM.getText().toString().indexOf("重发") == -1)
                    HQYZM();
                break;
            case R.id.tvDL:
                TZDLY();
                break;
            case R.id.btnZC:
                SJZC();
                break;
        }
    }

    //获取验证码
    public void HQYZM() {
        //异步线程调用网络服务
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                super.onPostExecute(result);
            }

            //该方法运行在后台线程中，因此不能在该线程中更新UI，UI线程为主线程
            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com/YHZC/GetYZM";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair SJ = new BasicNameValuePair("SJ", metSJH.getText().toString());
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(SJ);
                    HttpGet getMethod = new HttpGet(targeturl);
                    httpRequest.setEntity(new UrlEncodedFormEntity(parameters, "UTF-8"));
                    DefaultHttpClient httpClient = new DefaultHttpClient();
                    HttpResponse response = httpClient.execute(httpRequest); //发起GET请求
                    int rescode = response.getStatusLine().getStatusCode(); //获取响应码
                    result = EntityUtils.toString(response.getEntity(), "utf-8");//获取服务器响应内容

                    /* 获取cookieStore ASP.NET_SessionId就是通过上面的方法获取到。*/
                    CookieStore cookieStore = httpClient.getCookieStore();
                    List<Cookie> cookies = cookieStore.getCookies();
                    for (int i = 0; i < cookies.size(); i++) {
                        if ("ASP.NET_SessionId".equals(cookies.get(i).getName())) {
                            JSESSIONID = cookies.get(i).getValue();
                            break;
                        }
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
                return result;
            }
        }.execute();

        CountDownTimer cdt = new CountDownTimer(60000, 1000) {
            int count = 60;

            @Override
            public void onTick(long millisUntilFinished) {
                count = count - 1;
                mtvHQYZM.setText(count + "S后重发");
            }

            @Override
            public void onFinish() {
                mtvHQYZM.setText("重新获取");
            }
        };
        cdt.start();
    }

    //用户手机注册
    public void SJZC() {
        //异步线程调用网络服务
        new AsyncTask<String, Void, Object>() {

            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String Result = jsonobject.getString("Result");
                    if (Result == "1") ZCCG();
                    else ZCSB(jsonobject.getString("Message"));
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com/YHZC/SJRegister";
                //将URL与参数拼接
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair SJ = new BasicNameValuePair("SJ", metSJH.getText().toString());
                    NameValuePair YZM = new BasicNameValuePair("YZM", metYZM.getText().toString());
                    NameValuePair MM = new BasicNameValuePair("MM", metMM.getText().toString());
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(SJ);
                    parameters.add(YZM);
                    parameters.add(MM);
                    httpRequest.setEntity(new UrlEncodedFormEntity(parameters, "UTF-8"));
                    DefaultHttpClient httpClient = new DefaultHttpClient();
                    if(null != JSESSIONID){
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

    //跳转登录页
    public void TZDLY() {
        Intent intent = new Intent(YHZC.this, YHDL.class);
        startActivity(intent);
        finish();//关闭当前页面
    }

    //注册成功
    public void ZCCG() {
        Intent intent = new Intent(YHZC.this, GRZX_Main.class);
        startActivity(intent);
        finish();//关闭当前页面
    }

    //注册失败
    public void ZCSB(String message) {
        final AlertDialog dialog = new AlertDialog.Builder(YHZC.this).create();
        dialog.setTitle("提示");
        dialog.setMessage("注册失败:" + message);
        dialog.setCancelable(false);
        dialog.show();
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                dialog.dismiss();
            }
        }, 3000);
    }
}
