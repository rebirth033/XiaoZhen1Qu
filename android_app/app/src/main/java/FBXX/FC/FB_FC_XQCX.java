package FBXX.FC;

import android.content.Intent;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.widget.EditText;
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
import org.json.JSONArray;
import org.json.JSONObject;
import java.util.ArrayList;
import java.util.List;
import COMMON.Base;

public class FB_FC_XQCX extends Base implements View.OnClickListener {

    private EditText metXQMC;
    private LinearLayout mllXQLB;
    private TextView mtvQX;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_xqcx);
        findById();
        GetXQLB();
    }

    private void findById() {
        mtvQX = (TextView) findViewById(R.id.tvQX);
        metXQMC = (EditText) findViewById(R.id.etXQMC);
        mllXQLB = (LinearLayout) findViewById(R.id.llXQLB);
        metXQMC.setOnClickListener(this);
        metXQMC.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                GetXQLB();
                return false;
            }
        });
        mtvQX.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.tvQX:
                YMTZ("FB_FC_ZZ");
                break;
            case R.id.llXQLB:
                YMTZ("FB_FC_ZZ");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if (id == "FB_FC_ZZ") {
            Intent intent = new Intent(FB_FC_XQCX.this, FB_FC_ZZ.class);
            intent.putExtra("YMMC", "FB_FC_XQCX");//设置参数
            intent.putExtra("YMMC", "FB_FC_XQCX");//设置参数
            startActivity(intent);
            finish();//关闭当前页面
        }
    }

    //获取小区列表
    public void GetXQLB() {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String JResult = jsonobject.getString("Result");
                    String JList = jsonobject.getString("list");
                    HandlerXQLB(JList);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;

                String targeturl = "http://www.915fl.com/FC/LoadXQJBXXSByPY";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair XQMC = new BasicNameValuePair("XQMC", metXQMC.getText().toString());
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(XQMC);
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

    //处理小区列表
    public void HandlerXQLB(String JList) {
        try {
            mllXQLB.removeAllViews();//清空布局
            JSONArray jsonarray = new JSONArray(JList);
            for (int i = 0; i < jsonarray.length(); i++) {
                JSONObject jsonObject = jsonarray.getJSONObject(i);
                String XQMC = jsonObject.getString("XQMC");
                String XQDZ = jsonObject.getString("XQDZ");

                LinearLayout llouter = new LinearLayout(this);
                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(1600, 240);
                llouter.setLayoutParams(layoutParams);
                llouter.setOrientation(LinearLayout.VERTICAL);
                llouter.setBackgroundDrawable(this.getResources().getDrawable(R.drawable.border));

                TextView tvmc = new TextView(this);
                tvmc.setWidth(1600);
                tvmc.setHeight(100);
                tvmc.setPadding(80,30,0,0);
                tvmc.setTextSize(16);
                tvmc.setTextColor(Color.parseColor("#000000"));
                tvmc.setText(XQMC);

                TextView tvdz = new TextView(this);
                tvdz.setWidth(1600);
                tvdz.setHeight(120);
                tvdz.setPadding(50,0,0,0);
                tvdz.setTextSize(14);
                tvdz.setTextColor(Color.parseColor("#999999"));
                tvdz.setText(XQDZ);

                llouter.addView(tvmc);
                llouter.addView(tvdz);
                mllXQLB.addView(llouter);
                llouter.setOnClickListener(new View.OnClickListener() {
                    public void onClick(View v) {
                        List<View> viewList = getAllChildViews(v);
                        TextView tvxqmc = (TextView)viewList.get(0);
                        Intent intent = new Intent(FB_FC_XQCX.this, FB_FC_ZZ.class);
                        intent.putExtra("XQMC", tvxqmc.getText());//设置参数
                        intent.putExtra("YMMC", "FB_FC_XQCX");//设置参数
                        startActivity(intent);
                        finish();//关闭当前页面
                    }
                });
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
