package COMMON;

import android.content.Intent;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
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
import org.json.JSONArray;
import org.json.JSONObject;
import java.util.ArrayList;
import java.util.List;
import LBXZ.FB_Main;

public class GRZX_WDFB extends Base implements View.OnClickListener {

    private LinearLayout mllWDFB;
    private ImageView mivBACK;
    private TextView mtvFBXX;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.grzx_wdfb);
        findById();
        GetWDFB();
    }

    private void findById() {
        mivBACK = (ImageView) findViewById(R.id.ivBACK);
        mllWDFB = (LinearLayout) findViewById(R.id.llWDFB);
        mtvFBXX = (TextView) findViewById(R.id.tvFBXX);
        mivBACK.setOnClickListener(this);
        mtvFBXX.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.ivBACK:
                YMTZ("GRZX");
                break;
            case R.id.tvFBXX:
                YMTZ("FBXX");
                break;
        }
    }

    //个人中心
    public void YMTZ(String id) {
        if (id == "GRZX") {
            Intent intent = new Intent(GRZX_WDFB.this, GRZX_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
        if (id == "FBXX") {
            Intent intent = new Intent(GRZX_WDFB.this, FB_Main.class);
            startActivity(intent);
            finish();//关闭当前页面
        }
    }

    //获取我的发布
    public void GetWDFB() {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String JResult = jsonobject.getString("Result");
                    String JList = jsonobject.getString("list");
                    HandlerWDFB(JList);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;
                String targeturl = "http://www.915fl.com/WDFB/LoadYHFBXX";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair TYPE = new BasicNameValuePair("TYPE", "divXSZXX");
                    NameValuePair PageIndex = new BasicNameValuePair("PageIndex", "1");
                    NameValuePair PageSize = new BasicNameValuePair("PageSize", "10000");
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(TYPE);
                    parameters.add(PageIndex);
                    parameters.add(PageSize);
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

    //处理我的发布
    public void HandlerWDFB(String JList) {
        try {
            JSONArray jsonarray = new JSONArray(JList);
            for (int i = 0; i < jsonarray.length(); i++) {
                JSONObject jsonObject = jsonarray.getJSONObject(i);
                String BT = jsonObject.getString("BT");
                String ZXGXSJ = jsonObject.getString("ZXGXSJ");
                String STATUS = jsonObject.getString("STATUS");
                String LLCS = jsonObject.getString("LLCS");
                JSONArray photoarray = new JSONArray(jsonObject.getString("PHOTOS"));
                JSONObject photoObject = photoarray.getJSONObject(0);

                LinearLayout llmain = new LinearLayout(this);
                LinearLayout.LayoutParams llmainParams = new LinearLayout.LayoutParams(1600, 540);
                llmainParams.setMargins(0,0,0,20);
                llmain.setLayoutParams(llmainParams);
                llmain.setOrientation(LinearLayout.VERTICAL);

                LinearLayout llcontent = new LinearLayout(this);
                LinearLayout.LayoutParams llcontentParams = new LinearLayout.LayoutParams(1600, 400);
                llcontentParams.setMargins(0,0,0,0);
                llcontent.setLayoutParams(llcontentParams);
                llcontent.setBackgroundColor(Color.parseColor("#FFFFFF"));
                llcontent.setOrientation(LinearLayout.HORIZONTAL);
                llcontent.setBackgroundDrawable(this.getResources().getDrawable(R.drawable.border));

                ImageView ivtp = new ImageView(this);
                LinearLayout.LayoutParams ivtpParams = new LinearLayout.LayoutParams(440, 310);
                ivtpParams.setMargins(20,20,20,20);
                ivtp.setLayoutParams(ivtpParams);
                ivtp.setScaleType(ImageView.ScaleType.FIT_XY);
                ivtp.setImageBitmap(getHttpBitmap(photoObject.getString("PHOTOURL")));//显示在界面上

                LinearLayout llcontent_text = new LinearLayout(this);
                llcontent_text.setOrientation(LinearLayout.VERTICAL);

                TextView tvbt = new TextView(this);
                LinearLayout.LayoutParams tvbtParams = new LinearLayout.LayoutParams(800, 140);
                tvbtParams.setMargins(20,20,20,15);
                tvbt.setLayoutParams(tvbtParams);
                tvbt.setText(BT);

                TextView tvgxsj = new TextView(this);
                LinearLayout.LayoutParams tvgxsjParams = new LinearLayout.LayoutParams(800, 60);
                tvgxsjParams.setMargins(20,10,20,15);
                tvgxsj.setLayoutParams(tvgxsjParams);
                tvgxsj.setText("发布于:" + strToDateLong(ZXGXSJ));

                TextView tvllcs = new TextView(this);
                LinearLayout.LayoutParams tvllcsParams = new LinearLayout.LayoutParams(800, 60);
                tvllcsParams.setMargins(20,10,20,15);
                tvllcs.setLayoutParams(tvllcsParams);
                tvllcs.setText("浏览:" + LLCS + "次");

                LinearLayout llbottom = new LinearLayout(this);
                LinearLayout.LayoutParams llbottomParams = new LinearLayout.LayoutParams(1600, 140);
                llcontentParams.setMargins(0,10,0,0);
                llbottom.setLayoutParams(llbottomParams);
                llbottom.setPadding(10,10,210,10);
                llbottom.setBackgroundColor(Color.parseColor("#FFFFFF"));
                llbottom.setOrientation(LinearLayout.HORIZONTAL);
                llbottom.setHorizontalGravity(Gravity.RIGHT);

                TextView tvxg = new TextView(this);
                LinearLayout.LayoutParams tvxgParams = new LinearLayout.LayoutParams(200, 80);
                tvxgParams.setMargins(10,10,10,10);
                tvxg.setLayoutParams(tvxgParams);
                tvxg.setPadding(10,10,10,10);
                tvxg.setBackgroundDrawable(this.getResources().getDrawable(R.drawable.button_edge));
                tvxg.setText("修改");
                tvxg.setTextSize(14);
                tvxg.setTextColor(Color.parseColor("#bc6ba6"));

                TextView tvsc = new TextView(this);
                LinearLayout.LayoutParams tvscParams = new LinearLayout.LayoutParams(200, 80);
                tvscParams.setMargins(10,10,10,10);
                tvsc.setLayoutParams(tvscParams);
                tvsc.setPadding(10,10,10,10);
                tvsc.setBackgroundDrawable(this.getResources().getDrawable(R.drawable.button_edge));
                tvsc.setText("删除");
                tvsc.setTextSize(14);
                tvsc.setTextColor(Color.parseColor("#bc6ba6"));

                TextView tvsx = new TextView(this);
                LinearLayout.LayoutParams tvsxParams = new LinearLayout.LayoutParams(200, 80);
                tvsxParams.setMargins(10,10,10,10);
                tvsx.setLayoutParams(tvsxParams);
                tvsx.setPadding(10,10,10,10);
                tvsx.setBackgroundDrawable(this.getResources().getDrawable(R.drawable.button_edge));
                tvsx.setText("刷新");
                tvsx.setTextSize(14);
                tvsx.setTextColor(Color.parseColor("#bc6ba6"));

                TextView tvfx = new TextView(this);
                LinearLayout.LayoutParams tvfxParams = new LinearLayout.LayoutParams(200, 80);
                tvfxParams.setMargins(10,10,10,10);
                tvfx.setLayoutParams(tvfxParams);
                tvfx.setPadding(10,10,10,10);
                tvfx.setBackgroundDrawable(this.getResources().getDrawable(R.drawable.button_edge));
                tvfx.setText("分享");
                tvfx.setTextSize(14);
                tvfx.setTextColor(Color.parseColor("#bc6ba6"));

                llcontent.addView(ivtp);
                llcontent_text.addView(tvbt);
                llcontent_text.addView(tvgxsj);
                llcontent_text.addView(tvllcs);
                llcontent.addView(llcontent_text);
                llbottom.addView(tvxg);
                llbottom.addView(tvsc);
                llbottom.addView(tvsx);
                llbottom.addView(tvfx);
                llmain.addView(llcontent);
                llmain.addView(llbottom);
                mllWDFB.addView(llmain);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
