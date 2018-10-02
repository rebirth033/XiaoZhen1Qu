package LBXZ;

import android.content.Intent;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import COMMON.Base;
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

public class FB_SHFW extends Base implements View.OnClickListener {

    private LinearLayout mllFB_SHFW;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_shfw);
        findById();
        GetXL();
    }

    private void findById() {
        ImageView ivBack = (ImageView) findViewById(R.id.ivBACK);
        ivBack.setOnClickListener(this);
        mllFB_SHFW = (LinearLayout) findViewById(R.id.LL_FB_SHFW_ROW);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("FB_Main");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if (id == "FB_Main") {
            Intent intent = new Intent(FB_SHFW.this, FB_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }

    //获取生活服务小类
    public void GetXL() {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String JResult = jsonobject.getString("Result");
                    String JList = jsonobject.getString("list");
                    HandlerXL(JList);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com/LBXZ/LoadXL";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair LBID = new BasicNameValuePair("LBID", "9");
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(LBID);
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

    //处理生活服务小类
    public void HandlerXL(String JList) {
        try {
            LinearLayout llitem_first = new LinearLayout(this);
            LinearLayout.LayoutParams llitem_firstParams = new LinearLayout.LayoutParams(1600, 60);
            llitem_first.setLayoutParams(llitem_firstParams);
            llitem_first.setPadding(10,10,0,0);
            llitem_first.setBackgroundDrawable(this.getResources().getDrawable(R.drawable.border));

            mllFB_SHFW.addView(llitem_first);

            JSONArray jsonarray = new JSONArray(JList);
            for (int i = 0; i < jsonarray.length(); i++) {
                JSONObject jsonObject = jsonarray.getJSONObject(i);
                String CODES_XXLBS = jsonObject.getString("CODES_XXLBS");
                JSONArray jsonarray_second = new JSONArray(CODES_XXLBS);

                for (int j = 0; j < jsonarray_second.length(); j++) {
                    JSONObject jsonObject_second = jsonarray_second.getJSONObject(j);
                    String LBNAME = jsonObject_second.getString("LBNAME");

                    LinearLayout llitem = new LinearLayout(this);
                    LinearLayout.LayoutParams llitemParams = new LinearLayout.LayoutParams(1600, 160);
                    llitem.setLayoutParams(llitemParams);
                    llitem.setPadding(10, 10, 0, 0);
                    llitem.setGravity(Gravity.BOTTOM);
                    llitem.setBackgroundDrawable(this.getResources().getDrawable(R.drawable.border));

                    TextView tvxl = new TextView(this);
                    LinearLayout.LayoutParams tvxlParams = new LinearLayout.LayoutParams(1600, 160);
                    tvxl.setLayoutParams(tvxlParams);
                    tvxl.setPadding(10, 30, 0, 0);
                    tvxl.setText(LBNAME);
                    tvxl.setTextSize(16);
                    tvxl.setTextColor(Color.parseColor("#000000"));

                    llitem.addView(tvxl);
                    mllFB_SHFW.addView(llitem);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
