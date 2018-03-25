package com.example.administrator.infotownletsecond;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity implements OnClickListener{


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);

        ViewGroup vg=(ViewGroup)findViewById(R.id.llGRZX);

        vg.setOnClickListener(this);
        WZJX();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.llGRZX:
                TZDLY();
                break;
        }
    }

    public void WZJX() {
        new AsyncTask<String, Void, Object>() {

            protected void onPostExecute(Object result) {
                super.onPostExecute(result);
            }

            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://10.0.2.2/FCCX/LoadFCXX";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair TYPE = new BasicNameValuePair("TYPE", "FCCX_ZZF");
                    NameValuePair Condition = new BasicNameValuePair("Condition","IsHot:1");
                    NameValuePair PageIndex = new BasicNameValuePair("PageIndex", "1");
                    NameValuePair PageSize = new BasicNameValuePair("PageSize", "1");
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(TYPE);
                    parameters.add(Condition);
                    parameters.add(PageIndex);
                    parameters.add(PageSize);
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

    //跳转登录页
    public void TZDLY() {
        Intent intent = new Intent(MainActivity.this, YHDLActivity.class);
        startActivity(intent);
        finish();//关闭当前页面
    }
}
