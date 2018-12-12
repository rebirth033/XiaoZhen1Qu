package FBXX.CL;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.TextView;
import com.alibaba.fastjson.JSONObject;
import com.example.administrator.Public.R;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import Common.Base;
import Common.WheelStyle;
import Entities.CL_GCC_Model;
import FBXX.FC.FB_FC_SJ;
import LBXZ.FB_CL;

public class FB_CL_GCC extends Base implements View.OnClickListener {

    public CL_GCC_Model fb_cl_gcc = new CL_GCC_Model();
    public TextView mtvjx;
    public TextView mtvccnx;
    public TextView mtvjg;
    public TextView mtvckms;
    public TextView mtvlxrsf;
    public TextView mtvlxrlxdh;

    //自定义的弹出框类
    FB_FC_SJ jgWindow;
    FB_CL_GCC_JX jxWindow;
    FB_CL_CCNX ccnxWindow;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fb_cl_gcc);
        Intent intent  = this.getIntent();
        String YMMC = intent.getStringExtra("YMMC");
        String CKMS = intent.getStringExtra("CKMS");
        if(!(null == YMMC))
            if(YMMC.equalsIgnoreCase("FB_CL_CKMS"))
                mtvckms.setText(CKMS);
        initView();
    }

    //初始化页面
    private void initView() {
        findViewById(R.id.iv_back).setOnClickListener(this);
        findViewById(R.id.ll_gcc_jx).setOnClickListener(this);
        findViewById(R.id.ll_gcc_ccnx).setOnClickListener(this);
        findViewById(R.id.ll_gcc_jg).setOnClickListener(this);
        findViewById(R.id.ll_gcc_ckms).setOnClickListener(this);
        findViewById(R.id.ll_gcc_lxrsf).setOnClickListener(this);
        findViewById(R.id.ll_gcc_lxrlxdh).setOnClickListener(this);
        findViewById(R.id.tv_dbcd_fb).setOnClickListener(this);

        mtvjx = (TextView) findViewById(R.id.tv_gcc_jx);
        mtvccnx = (TextView) findViewById(R.id.tv_gcc_ccnx);
        mtvjg = (TextView) findViewById(R.id.tv_gcc_jg);
        mtvckms = (TextView) findViewById(R.id.tv_gcc_ckms);
        mtvlxrsf = (TextView) findViewById(R.id.tv_gcc_lxrsf);
        mtvlxrlxdh = (TextView) findViewById(R.id.tv_gcc_lxrlxdh);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.iv_back:
                YMTZ("FB_CL");
                break;
            case R.id.ll_gcc_jx:
                YMTZ("FB_CL_GCC_JX");
                break;
            case R.id.ll_gcc_ccnx:
                YMTZ("FB_CL_GCC_CCNX");
                break;
            case R.id.ll_gcc_jg:
                YMTZ("FB_CL_JG");
                break;
            case R.id.ll_gcc_ckms:
                YMTZ("FB_CL_CKMS");
                break;
            case R.id.tv_gcc_lxrsf:
                YMTZ("FB_LXRSF");
                break;
            case R.id.tv_gcc_lxrlxdh:
                YMTZ("FB_LXRLXDH");
                break;
            case R.id.tv_dbcd_fb:
                FB();
                break;
        }
    }

    //页面跳转
    public void YMTZ(String id) {
        if (id == "FB_CL") {
            Intent intent = new Intent(FB_CL_GCC.this, FB_CL.class);
            startActivity(intent);
            finish();
        }
        if (id == "FB_CL_GCC_JX") {
            jxWindow = new FB_CL_GCC_JX(FB_CL_GCC.this, jxOnClick);
            jxWindow.showAtLocation(FB_CL_GCC.this.findViewById(R.id.fb_cl_gcc), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
        }
        if (id == "FB_CL_GCC_CCNX") {
            ccnxWindow = new FB_CL_CCNX(FB_CL_GCC.this, ccnxOnClick);
            ccnxWindow.showAtLocation(FB_CL_GCC.this.findViewById(R.id.fb_cl_gcc), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            ccnxWindow.mwvyear.setWheelItemList(WheelStyle.createYearString());
            ccnxWindow.mwvmonth.setWheelItemList(WheelStyle.createMonthString());
            if(!mtvccnx.getText().toString().equalsIgnoreCase("")) {
                ccnxWindow.mwvyear.setCurrentItem(WheelStyle.createYearString().indexOf(mtvccnx.getText().toString().substring(0, mtvccnx.getText().toString().indexOf("年") + 1)));
                ccnxWindow.mwvmonth.setCurrentItem(WheelStyle.createMonthString().indexOf(mtvccnx.getText().toString().substring(5, mtvccnx.getText().toString().indexOf("月") + 1)));
            }
        }
        if (id == "FB_CL_JG") {
            jgWindow = new FB_FC_SJ(FB_CL_GCC.this, jgOnClick);
            jgWindow.showAtLocation(FB_CL_GCC.this.findViewById(R.id.fb_cl_gcc), Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, 0);
            jgWindow.metsj.setText(mtvjg.getText());
        }
        if (id == "FB_CL_CKMS") {
            Intent intent = new Intent(FB_CL_GCC.this, FB_CL_JC_CKMS.class);
            intent.putExtra("YMMC", "FB_CL_GCC");//设置参数
            startActivity(intent);
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
                String targeturl = "http://www.915fl.com/FC/FB_CL_GCCJBXX";

                try {
                    String resultJson = JSONObject.toJSONString(fb_cl_gcc);
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair Json = new BasicNameValuePair("Json", resultJson);
                    NameValuePair BCMS = new BasicNameValuePair("BCMS", mtvckms.getText().toString());
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

    //机型页面按钮监听
    private View.OnClickListener jxOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.iv_back:
                    jxWindow.dismiss();
                    break;
                default:
                    jxWindow.dismiss();
                    List<View> viewList = Base.getAllChildViews(v);
                    TextView tvxqmc = (TextView)viewList.get(0);
                    mtvjx.setText(tvxqmc.getText());

                    //fb_cl_gcc. = tvxqmc.getText().toString();
                    break;
            }
        }
    };

    //价格页面按钮监听
    private View.OnClickListener jgOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.ivqx:
                    jgWindow.dismiss();
                    break;
                case R.id.tvqd:
                    jgWindow.dismiss();
                    mtvjg.setText(jgWindow.metsj.getText());

                    fb_cl_gcc.JG = new BigDecimal(jgWindow.metsj.getText().toString().replace("万元",""));
                    break;
            }
        }
    };

    //产权年限
    private View.OnClickListener ccnxOnClick = new View.OnClickListener(){
        public void onClick(View v) {
            switch (v.getId()) {
                case R.id.tv_ccnx_qd:
                    ccnxWindow.dismiss();
                    mtvccnx.setText(WheelStyle.createYearString().get(ccnxWindow.mwvyear.getCurrentItem()) + WheelStyle.createMonthString().get(ccnxWindow.mwvmonth.getCurrentItem()));
                    break;
            }
        }
    };
}
