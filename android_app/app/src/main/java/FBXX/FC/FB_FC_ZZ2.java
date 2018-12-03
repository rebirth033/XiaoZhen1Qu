package FBXX.FC;

import android.content.Intent;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
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
import Entities.FB_FC_ZZ_Model;
import com.alibaba.fastjson.JSONObject;

public class FB_FC_ZZ2 extends Base implements View.OnClickListener {

    private LinearLayout mllFWPZ;
    private LinearLayout mllFWLD;
    private LinearLayout mllCZYQ;
    public TextView mtvkfsj;
    public TextView mtvyzrs;
    public TextView mtvrzsj;
    private TextView mtvfb;
    private EditText metbcms;
    private ImageView mivback;
    //自定义的弹出框类
    FB_FC_RZXX rzxxWindow;
    public FB_FC_ZZ_Model fb_fc_zz = new FB_FC_ZZ_Model();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_fc_zz2);

        Intent intent  = this.getIntent();
        fb_fc_zz = (FB_FC_ZZ_Model)intent.getSerializableExtra("fb_fc_zz");

        initView();
        loadFWPZ();
        loadFWLD();
        loadCZYQ();
    }

    //初始化页面
    private void initView() {
        mllFWPZ = (LinearLayout) findViewById(R.id.ll_zz_fwpz);
        mllFWLD = (LinearLayout) findViewById(R.id.ll_zz_fwld);
        mllCZYQ = (LinearLayout) findViewById(R.id.ll_zz_czyq);
        mtvfb = (TextView) findViewById(R.id.tv_dbcd_fb);
        metbcms = (EditText) findViewById(R.id.et_content_middle_bcms);
        mivback = (ImageView) findViewById(R.id.iv_back);

        ViewGroup mllkfsj = (ViewGroup) findViewById(R.id.ll_zz_kfsj);
        ViewGroup mllyzrs = (ViewGroup) findViewById(R.id.ll_zz_yzrs);
        ViewGroup mllrzsj = (ViewGroup) findViewById(R.id.ll_zz_rzsj);

        mtvkfsj = (TextView) findViewById(R.id.tv_zz_kfsj);
        mtvyzrs = (TextView) findViewById(R.id.tv_zz_yzrs);
        mtvrzsj = (TextView) findViewById(R.id.tv_zz_rzsj);

        mtvfb.setOnClickListener(this);
        mivback.setOnClickListener(this);
        mllkfsj.setOnClickListener(this);
        mllyzrs.setOnClickListener(this);
        mllrzsj.setOnClickListener(this);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_FC_ZZ");
                break;
            case R.id.tv_dbcd_fb:
                FB();
                break;
            case R.id.ll_zz_kfsj:
                YMTZ("FB_FC_RZXX_KFSJ");
                break;
            case R.id.ll_zz_yzrs:
                YMTZ("FB_FC_RZXX_YZRS");
                break;
            case R.id.ll_zz_rzsj:
                YMTZ("FB_FC_RZXX_RZSJ");
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_FC_ZZ") {
            Intent intent = new Intent(FB_FC_ZZ2.this, FB_FC_ZZ.class);
            intent.putExtra("YMMC", "FB_FC_ZZ2");//设置参数
            startActivity(intent);
        }
        if (id == "FB_FC_RZXX_KFSJ") {
            rzxxWindow = new FB_FC_RZXX(FB_FC_ZZ2.this, rzxxOnClick, "KFSJ");
            rzxxWindow.showAtLocation(FB_FC_ZZ2.this.findViewById(R.id.fb_fc_zz2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            rzxxWindow.mtvkfsj.setText(mtvkfsj.getText());
            rzxxWindow.mtvyzrs.setText(mtvyzrs.getText());
            rzxxWindow.mtvrzsj.setText(mtvrzsj.getText());
            rzxxWindow.mwvkfsj.setWheelItemList(WheelStyle.createKFSJString());
            rzxxWindow.mwvyzrs.setWheelItemList(WheelStyle.createYZRSString());
            rzxxWindow.mwvyear.setWheelItemList(WheelStyle.createYearString());
            rzxxWindow.mwvmonth.setWheelItemList(WheelStyle.createMonthString());
            rzxxWindow.mwvday.setWheelItemList(WheelStyle.createDayString());
            rzxxWindow.mwvkfsj.setCurrentItem(WheelStyle.createKFSJString().indexOf(mtvkfsj.getText()));
            rzxxWindow.mwvyzrs.setCurrentItem(WheelStyle.createYZRSString().indexOf(mtvyzrs.getText()));
            if(mtvrzsj.getText().toString().indexOf("请选择") == -1) {
                rzxxWindow.mwvyear.setCurrentItem(WheelStyle.createYearString().indexOf(mtvrzsj.getText().toString().substring(0, mtvrzsj.getText().toString().indexOf("年") + 1)));
                rzxxWindow.mwvmonth.setCurrentItem(WheelStyle.createMonthString().indexOf(mtvrzsj.getText().toString().substring(5, mtvrzsj.getText().toString().indexOf("月") + 1)));
                rzxxWindow.mwvday.setCurrentItem(WheelStyle.createDayString().indexOf(mtvrzsj.getText().toString().substring(7, mtvrzsj.getText().toString().indexOf("日") + 1)));
            }
        }
        if (id == "FB_FC_RZXX_YZRS") {
            rzxxWindow = new FB_FC_RZXX(FB_FC_ZZ2.this, rzxxOnClick, "YZRS");
            rzxxWindow.showAtLocation(FB_FC_ZZ2.this.findViewById(R.id.fb_fc_zz2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            rzxxWindow.mtvkfsj.setText(mtvkfsj.getText());
            rzxxWindow.mtvyzrs.setText(mtvyzrs.getText());
            rzxxWindow.mtvrzsj.setText(mtvrzsj.getText());
            rzxxWindow.mwvkfsj.setWheelItemList(WheelStyle.createKFSJString());
            rzxxWindow.mwvyzrs.setWheelItemList(WheelStyle.createYZRSString());
            rzxxWindow.mwvyear.setWheelItemList(WheelStyle.createYearString());
            rzxxWindow.mwvmonth.setWheelItemList(WheelStyle.createMonthString());
            rzxxWindow.mwvday.setWheelItemList(WheelStyle.createDayString());
            rzxxWindow.mwvkfsj.setCurrentItem(WheelStyle.createKFSJString().indexOf(mtvkfsj.getText()));
            rzxxWindow.mwvyzrs.setCurrentItem(WheelStyle.createYZRSString().indexOf(mtvyzrs.getText()));
            if(mtvrzsj.getText().toString().indexOf("请选择") == -1) {
                rzxxWindow.mwvyear.setCurrentItem(WheelStyle.createYearString().indexOf(mtvrzsj.getText().toString().substring(0, mtvrzsj.getText().toString().indexOf("年") + 1)));
                rzxxWindow.mwvmonth.setCurrentItem(WheelStyle.createMonthString().indexOf(mtvrzsj.getText().toString().substring(5, mtvrzsj.getText().toString().indexOf("月") + 1)));
                rzxxWindow.mwvday.setCurrentItem(WheelStyle.createDayString().indexOf(mtvrzsj.getText().toString().substring(7, mtvrzsj.getText().toString().indexOf("日") + 1)));
            }
        }
        if (id == "FB_FC_RZXX_RZSJ") {
            rzxxWindow = new FB_FC_RZXX(FB_FC_ZZ2.this, rzxxOnClick, "RZSJ");
            rzxxWindow.showAtLocation(FB_FC_ZZ2.this.findViewById(R.id.fb_fc_zz2), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            rzxxWindow.mtvkfsj.setText(mtvkfsj.getText());
            rzxxWindow.mtvyzrs.setText(mtvyzrs.getText());
            rzxxWindow.mtvrzsj.setText(mtvrzsj.getText());
            rzxxWindow.mwvkfsj.setWheelItemList(WheelStyle.createKFSJString());
            rzxxWindow.mwvyzrs.setWheelItemList(WheelStyle.createYZRSString());
            rzxxWindow.mwvyear.setWheelItemList(WheelStyle.createYearString());
            rzxxWindow.mwvmonth.setWheelItemList(WheelStyle.createMonthString());
            rzxxWindow.mwvday.setWheelItemList(WheelStyle.createDayString());
            rzxxWindow.mwvkfsj.setCurrentItem(WheelStyle.createKFSJString().indexOf(mtvkfsj.getText()));
            rzxxWindow.mwvyzrs.setCurrentItem(WheelStyle.createYZRSString().indexOf(mtvyzrs.getText()));
            if(mtvrzsj.getText().toString().indexOf("请选择") == -1) {
                rzxxWindow.mwvyear.setCurrentItem(WheelStyle.createYearString().indexOf(mtvrzsj.getText().toString().substring(0, mtvrzsj.getText().toString().indexOf("年") + 1)));
                rzxxWindow.mwvmonth.setCurrentItem(WheelStyle.createMonthString().indexOf(mtvrzsj.getText().toString().substring(5, mtvrzsj.getText().toString().indexOf("月") + 1)));
                rzxxWindow.mwvday.setCurrentItem(WheelStyle.createDayString().indexOf(mtvrzsj.getText().toString().substring(7, mtvrzsj.getText().toString().indexOf("日") + 1)));
            }
        }
    }

    //加载房屋配置
    public void loadFWPZ(){
        String fwpzs0 = "宽带,床,衣柜,沙发,冰箱,洗衣机";
        String fwpzs1 = "空调,阳台,独立卫生间";
        String[] fwpzlist = new String[2];
        fwpzlist[0] = fwpzs0;
        fwpzlist[1] = fwpzs1;

        for(int j = 0; j < 2; j++) {
            LinearLayout llouter = new LinearLayout(this);
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(1600, 240);
            llouter.setLayoutParams(layoutParams);
            llouter.setOrientation(LinearLayout.HORIZONTAL);

            for (int i = 0; i < fwpzlist[j].split(",").length; i++) {
                TextView tvmc = new TextView(this);
                layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT);
                layoutParams.setMargins(10, 0, 0, 0);//4个参数按顺序分别是左上右下
                tvmc.setLayoutParams(layoutParams);
                tvmc.setPadding(10, 7, 10, 7);
                tvmc.setTextSize(16);
                tvmc.setTextColor(Color.parseColor("#666666"));
                tvmc.setText(fwpzlist[j].split(",")[i]);
                tvmc.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_unselect));
                tvmc.setTag(R.drawable.radius_unselect);
                tvmc.setOnClickListener(new View.OnClickListener(){
                    public void onClick(View v) {
                       TextView tv = (TextView)v;
                       int res = (int) tv.getTag();
                       if(res == R.drawable.radius_select) {
                           tv.setTextColor(Color.parseColor("#666666"));
                           tv.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_unselect));
                           tv.setTag(R.drawable.radius_unselect);
                       }
                       else{
                           tv.setTextColor(Color.parseColor("#ffffff"));
                           tv.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_select));
                           tv.setTag(R.drawable.radius_select);
                       }
                    }
                });
                llouter.addView(tvmc);
            }
            mllFWPZ.addView(llouter);
        }
    }

    //加载房屋亮点
    public void loadFWLD(){
        String fwpzs0 = "南北通透,有阳台,首次出租";
        String fwpzs1 = "临近地铁,可短租,独立卫生间";
        String[] fwpzlist = new String[2];
        fwpzlist[0] = fwpzs0;
        fwpzlist[1] = fwpzs1;

        for(int j = 0; j < 2; j++) {
            LinearLayout llouter = new LinearLayout(this);
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(1600, 240);
            llouter.setLayoutParams(layoutParams);
            llouter.setOrientation(LinearLayout.HORIZONTAL);

            for (int i = 0; i < fwpzlist[j].split(",").length; i++) {
                TextView tvmc = new TextView(this);
                layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT);
                layoutParams.setMargins(10, 0, 0, 0);//4个参数按顺序分别是左上右下
                tvmc.setLayoutParams(layoutParams);
                tvmc.setPadding(10, 7, 10, 7);
                tvmc.setTextSize(16);
                tvmc.setTextColor(Color.parseColor("#666666"));
                tvmc.setText(fwpzlist[j].split(",")[i]);
                tvmc.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_unselect));
                tvmc.setTag(R.drawable.radius_unselect);
                tvmc.setOnClickListener(new View.OnClickListener(){
                    public void onClick(View v) {
                        TextView tv = (TextView)v;
                        int res = (int) tv.getTag();
                        if(res == R.drawable.radius_select) {
                            tv.setTextColor(Color.parseColor("#666666"));
                            tv.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_unselect));
                            tv.setTag(R.drawable.radius_unselect);
                        }
                        else{
                            tv.setTextColor(Color.parseColor("#ffffff"));
                            tv.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_select));
                            tv.setTag(R.drawable.radius_select);
                        }
                    }
                });
                llouter.addView(tvmc);
            }
            mllFWLD.addView(llouter);
        }
    }

    //加载出租要求
    public void loadCZYQ(){
        String fwpzs0 = "只限女生,一家人,禁止养宠物,半年起租";
        String fwpzs1 = "一年起租,租户稳定,作息正常,禁烟";
        String[] fwpzlist = new String[2];
        fwpzlist[0] = fwpzs0;
        fwpzlist[1] = fwpzs1;

        for(int j = 0; j < 2; j++) {
            LinearLayout llouter = new LinearLayout(this);
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(1600, 240);
            llouter.setLayoutParams(layoutParams);
            llouter.setOrientation(LinearLayout.HORIZONTAL);

            for (int i = 0; i < fwpzlist[j].split(",").length; i++) {
                TextView tvmc = new TextView(this);
                layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT);
                layoutParams.setMargins(10, 0, 0, 0);//4个参数按顺序分别是左上右下
                tvmc.setLayoutParams(layoutParams);
                tvmc.setPadding(10, 7, 10, 7);
                tvmc.setTextSize(16);
                tvmc.setTextColor(Color.parseColor("#666666"));
                tvmc.setText(fwpzlist[j].split(",")[i]);
                tvmc.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_unselect));
                tvmc.setTag(R.drawable.radius_unselect);
                tvmc.setOnClickListener(new View.OnClickListener(){
                    public void onClick(View v) {
                        TextView tv = (TextView)v;
                        int res = (int) tv.getTag();
                        if(res == R.drawable.radius_select) {
                            tv.setTextColor(Color.parseColor("#666666"));
                            tv.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_unselect));
                            tv.setTag(R.drawable.radius_unselect);
                        }
                        else{
                            tv.setTextColor(Color.parseColor("#ffffff"));
                            tv.setBackgroundDrawable(getResources().getDrawable(R.drawable.radius_select));
                            tv.setTag(R.drawable.radius_select);
                        }
                    }
                });
                llouter.addView(tvmc);
            }
            mllCZYQ.addView(llouter);
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
                String targeturl = "http://www.915fl.com/FC/FBFC_ZZFJBXX";
                fb_fc_zz.FWPZ = GetDuoX(mllFWPZ);
                fb_fc_zz.FWLD = GetDuoX(mllFWLD);
                fb_fc_zz.CZYQ = GetDuoX(mllCZYQ);

                try {
                    String resultJson = JSONObject.toJSONString(fb_fc_zz);
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair Json = new BasicNameValuePair("Json", resultJson);
                    NameValuePair BCMS = new BasicNameValuePair("BCMS", metbcms.getText().toString());
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

    //房屋情况页面按钮监听
    private View.OnClickListener rzxxOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_rzsj_qd:
                    rzxxWindow.dismiss();
                    mtvkfsj.setText(rzxxWindow.mtvkfsj.getText());
                    mtvyzrs.setText(rzxxWindow.mtvyzrs.getText());
                    mtvrzsj.setText(WheelStyle.createYearString().get(rzxxWindow.mwvyear.getCurrentItem()) + WheelStyle.createMonthString().get(rzxxWindow.mwvmonth.getCurrentItem()) + WheelStyle.createDayString().get(rzxxWindow.mwvday.getCurrentItem()));
                    break;
            }
        }
    };
}