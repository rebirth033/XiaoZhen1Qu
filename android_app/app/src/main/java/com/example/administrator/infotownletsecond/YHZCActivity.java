package com.example.administrator.infotownletsecond;

import android.app.AlertDialog;
import android.os.AsyncTask;
import android.os.CountDownTimer;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
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
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONObject;

public class YHZCActivity extends AppCompatActivity implements OnClickListener {
    private EditText metSJH;
    private EditText metDTM;
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
        metDTM = (EditText) findViewById(R.id.etDTM);
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
                String targeturl = "http://www.915fl.com/YHJBXX/GetYZM?SJ=" + metSJH.getText();
                HttpGet getMethod = new HttpGet(targeturl);
                DefaultHttpClient httpClient = new DefaultHttpClient();
                try {
                    HttpResponse response = httpClient.execute(getMethod); //发起GET请求
                    int rescode = response.getStatusLine().getStatusCode(); //获取响应码
                    result = EntityUtils.toString(response.getEntity(), "utf-8");//获取服务器响应内容
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
                    String Message = jsonobject.getString("Message");
                    if(Result == "1") ZCCG();
                    else ZCSB(Message);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com.com/YHJBXX/SJRegister?SJ=" + metSJH.getText() + "&YZM=" + metDTM.getText() + "&MM=" + metMM.getText();
                //将URL与参数拼接
                HttpGet getMethod = new HttpGet(targeturl);
                DefaultHttpClient httpClient = new DefaultHttpClient();
                try {
                    HttpResponse response = httpClient.execute(getMethod); //发起GET请求
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
        Intent intent = new Intent(YHZCActivity.this, YHDLActivity.class);
        startActivity(intent);
        finish();//关闭当前页面
    }
    //注册成功
    public void ZCCG(){
        Intent intent = new Intent(YHZCActivity.this, GRZXActivity.class);
        startActivity(intent);
        finish();//关闭当前页面
    }
    //注册成功
    public void ZCSB(String message){
        final AlertDialog dialog = new AlertDialog.Builder(YHZCActivity.this).create();
        dialog.setTitle("提示");
        dialog.setMessage("注册失败:" + message);
        dialog.setCancelable(false);
        dialog.show();
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {dialog.dismiss();}
        }, 3000);
    }
}
