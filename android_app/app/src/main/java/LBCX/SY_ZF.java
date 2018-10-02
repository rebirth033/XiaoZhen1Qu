package LBCX;

import android.content.Intent;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
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

public class SY_ZF extends Base implements View.OnClickListener {

    private ImageView mivBACK;
    private LinearLayout mllCNXH;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.sy_zf);
        findById();
        GetCNXH();
    }

    private void findById() {
        mivBACK = (ImageView) findViewById(R.id.ivBACK);
        mivBACK.setOnClickListener(this);
        mllCNXH = (LinearLayout) findViewById(R.id.llCNXH);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("BACK");
                break;
        }
    }

    //首页_租房
    public void YMTZ(String id) {
        if (id == "BACK") {
            Intent intent = new Intent(SY_ZF.this, SY_Main.class);
            finish();//关闭当前页面
        }
    }

    //猜你喜欢
    public void GetCNXH() {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String JResult = jsonobject.getString("Result");
                    String JList = jsonobject.getString("list");
                    HandlerCNXH(JList);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com/FCCX/LoadFCXXWithoutXZQ";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair TYPE = new BasicNameValuePair("TYPE", "FCXX_ZZF");
                    NameValuePair Condition = new BasicNameValuePair("Condition", "STATUS:1,ISHOT:1");
                    NameValuePair PageIndex = new BasicNameValuePair("PageIndex", "1");
                    NameValuePair PageSize = new BasicNameValuePair("PageSize", "10");
                    NameValuePair XZQ = new BasicNameValuePair("XZQ", "福州");
                    NameValuePair XZQDM = new BasicNameValuePair("XZQDM", "350100");
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(TYPE);
                    parameters.add(Condition);
                    parameters.add(PageIndex);
                    parameters.add(PageSize);
                    parameters.add(XZQ);
                    parameters.add(XZQDM);
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

    //处理猜你喜欢
    public void HandlerCNXH(String JList) {
        try {
            JSONArray jsonarray = new JSONArray(JList);
            for (int i = 0; i < 7; i += 2) {

                LinearLayout llouter = new LinearLayout(this);
                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(1600, 600);
                llouter.setLayoutParams(layoutParams);
                mllCNXH.addView(llouter);

                JSONObject jsonObject = jsonarray.getJSONObject(i);
                String XQMC = jsonObject.getString("XQMC");
                String S = jsonObject.getString("S");
                String PFM = jsonObject.getString("PFM");
                String ZJ = jsonObject.getString("ZJ");
                JSONArray photoarray = new JSONArray(jsonObject.getString("PHOTOS"));
                JSONObject photoObject = photoarray.getJSONObject(0);

                LinearLayout llinner1 = new LinearLayout(this);
                llinner1.setOrientation(LinearLayout.VERTICAL);
                llinner1.setPadding(50,0,0,0);

                ImageView ivtp = new ImageView(this);
                ivtp.setLayoutParams(new ViewGroup.LayoutParams(600, 360));
                ivtp.setScaleType(ImageView.ScaleType.FIT_XY);
                ivtp.setImageBitmap(getHttpBitmap(photoObject.getString("PHOTOURL")));

                TextView tvbt = new TextView(this);
                tvbt.setWidth(600);
                tvbt.setHeight(80);
                tvbt.setTextSize(18);
                tvbt.setText("整租 " + XQMC);

                TextView tvxq = new TextView(this);
                tvxq.setWidth(600);
                tvxq.setHeight(80);
                tvxq.setTextSize(18);
                tvxq.setText(S + "室 | " + PFM + "平");

                TextView tvzj = new TextView(this);
                tvzj.setWidth(600);
                tvzj.setHeight(80);
                tvzj.setTextSize(18);
                tvzj.setTextColor(Color.parseColor("#bc6ba6"));
                tvzj.setText(ZJ + "元");

                llinner1.addView(ivtp);
                llinner1.addView(tvbt);
                llinner1.addView(tvxq);
                llinner1.addView(tvzj);
                llouter.addView(llinner1);

                jsonObject = jsonarray.getJSONObject(i+1);
                XQMC = jsonObject.getString("XQMC");
                S = jsonObject.getString("S");
                PFM = jsonObject.getString("PFM");
                ZJ = jsonObject.getString("ZJ");
                photoarray = new JSONArray(jsonObject.getString("PHOTOS"));
                photoObject = photoarray.getJSONObject(0);

                llinner1 = new LinearLayout(this);
                llinner1.setOrientation(LinearLayout.VERTICAL);
                llinner1.setPadding(50,0,0,0);

                ivtp = new ImageView(this);
                ivtp.setLayoutParams(new ViewGroup.LayoutParams(600, 360));
                ivtp.setScaleType(ImageView.ScaleType.FIT_XY);
                ivtp.setImageBitmap(getHttpBitmap(photoObject.getString("PHOTOURL")));

                tvbt = new TextView(this);
                tvbt.setWidth(600);
                tvbt.setHeight(80);
                tvbt.setTextSize(18);
                tvbt.setText("整租 " + XQMC);

                tvxq = new TextView(this);
                tvxq.setWidth(600);
                tvxq.setHeight(80);
                tvxq.setTextSize(18);
                tvxq.setText(S + "室 | " + PFM + "平");

                tvzj = new TextView(this);
                tvzj.setWidth(600);
                tvzj.setHeight(80);
                tvzj.setTextSize(18);
                tvzj.setTextColor(Color.parseColor("#bc6ba6"));
                tvzj.setText(ZJ + "元");

                llinner1.addView(ivtp);
                llinner1.addView(tvbt);
                llinner1.addView(tvxq);
                llinner1.addView(tvzj);
                llouter.addView(llinner1);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
