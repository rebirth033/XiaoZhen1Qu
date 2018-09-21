package com.example.administrator.infotownletsecond;

import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.view.View;
import android.view.View.OnClickListener;
import android.content.Intent;
import android.app.AlertDialog;
import android.os.Handler;
import android.os.Bundle;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONObject;
import java.util.ArrayList;
import java.util.List;

public class YHDLActivity extends AppCompatActivity implements OnClickListener {
    private EditText metSJH;
    private EditText metMM;
    private TextView mtvGB;
    private TextView mtvZC;
    private TextView mbtnDL;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.yhdl);
        metSJH = (EditText) findViewById(R.id.etSJH);
        metMM = (EditText) findViewById(R.id.etMM);
        mtvGB = (TextView) findViewById(R.id.tvGB);
        mtvZC = (TextView) findViewById(R.id.tvZC);
        mbtnDL = (Button) findViewById(R.id.btnDL);
        mtvZC.setOnClickListener(this);
        mbtnDL.setOnClickListener(this);
    }
    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.tvZC:
                TZZCY();
                break;
            case R.id.btnDL:
                YHDL();
                break;
        }
    }
    //跳转注册页
    public void TZZCY() {
        Intent intent = new Intent(YHDLActivity.this, YHZCActivity.class);
        startActivity(intent);
        finish();//关闭当前页面
    }
    //用户登录
    public void YHDL() {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String Result = jsonobject.getString("Result");
                    String Message = jsonobject.getString("Message");
                    String temp = Result;
                    if(Result.indexOf("1") != -1) {
                        DLCG();
                    }
                    else {
                        DLSB(Message);
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com/YHDL/MMLogin";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair YHM = new BasicNameValuePair("YHM", metSJH.getText().toString());//把要发送的数据封装在NameValuePair对象中，并设置键值
                    NameValuePair MM = new BasicNameValuePair("MM", metMM.getText().toString());
                    NameValuePair SFZDDL = new BasicNameValuePair("SFZDDL", "false");
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(YHM);
                    parameters.add(MM);
                    parameters.add(SFZDDL);
                    httpRequest.setEntity(new UrlEncodedFormEntity(parameters, "UTF-8"));
                    DefaultHttpClient httpClient = new DefaultHttpClient();

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
    //登录成功
    public void DLCG(){
        Intent intent = new Intent(YHDLActivity.this, GRZX_MainActivity.class);
        startActivity(intent);
        finish();//关闭当前页面
    }
    //登录成功
    public void DLSB(String message){
        final AlertDialog dialog = new AlertDialog.Builder(YHDLActivity.this).create();
        dialog.setTitle("提示");
        dialog.setMessage("登录失败:" + message);
        dialog.setCancelable(false);
        dialog.show();
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {dialog.dismiss();}
        }, 3000);
    }
}
