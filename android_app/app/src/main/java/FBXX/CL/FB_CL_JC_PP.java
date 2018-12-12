package FBXX.CL;

import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.AsyncTask;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
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
import Common.Base;

public class FB_CL_JC_PP extends PopupWindow {

    public EditText metPPMC;
    private LinearLayout mllPPLB;
    private TextView mtvQX;
    private View mMenuView;

    public FB_CL_JC_PP(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_cl_jc_pp, null);
        //设置SelectPicPopupWindow的View
        this.setContentView(mMenuView);
        //设置SelectPicPopupWindow弹出窗体的宽
        this.setWidth(ViewGroup.LayoutParams.FILL_PARENT);
        //设置SelectPicPopupWindow弹出窗体的高
        this.setHeight(ViewGroup.LayoutParams.FILL_PARENT);
        //设置SelectPicPopupWindow弹出窗体可点击
        this.setFocusable(true);
        //设置SelectPicPopupWindow弹出窗体动画效果
        this.setAnimationStyle(R.style.AnimBottom);
        //实例化一个ColorDrawable颜色为半透明
        ColorDrawable dw = new ColorDrawable(0xb0000000);
        //设置SelectPicPopupWindow弹出窗体的背景
        this.setBackgroundDrawable(dw);
        //初始化页面
        initView(itemsOnClick);
        //获取轿车品牌
        GetJCPP(itemsOnClick);
    }

    private void initView(final View.OnClickListener itemsOnClick) {
        mtvQX = (TextView) mMenuView.findViewById(R.id.tvqx);
        metPPMC = (EditText) mMenuView.findViewById(R.id.etppmc);
        mllPPLB = (LinearLayout) mMenuView.findViewById(R.id.llPPLB);
        metPPMC.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                GetJCPP(itemsOnClick);
                return false;
            }
        });
        mtvQX.setOnClickListener(itemsOnClick);
    }

    //获取轿车品牌
    public void GetJCPP(final View.OnClickListener itemsOnClick) {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String JResult = jsonobject.getString("Result");
                    String JList = jsonobject.getString("list");
                    HandlerJCPP(JList,itemsOnClick);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;

                String targeturl = "http://www.915fl.com/FC/LoadJCPPByPY";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair PPMC = new BasicNameValuePair("XQMC", metPPMC.getText().toString());
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(PPMC);
                    httpRequest.setEntity(new UrlEncodedFormEntity(parameters, "UTF-8"));
                    DefaultHttpClient httpClient = new DefaultHttpClient();
                    if (null != Base.JSESSIONID) httpRequest.setHeader("Cookie", "ASP.NET_SessionId=" + Base.JSESSIONID);

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

    //处理轿车品牌
    public void HandlerJCPP(String JList,View.OnClickListener itemsOnClick) {
        try {
            mllPPLB.removeAllViews();//清空布局
            JSONArray jsonarray = new JSONArray(JList);
            for (int i = 0; i < jsonarray.length(); i++) {
                JSONObject jsonObject = jsonarray.getJSONObject(i);
                String XQMC = jsonObject.getString("XQMC");
                String XQDZ = jsonObject.getString("XQDZ");

                LinearLayout llouter = new LinearLayout(mMenuView.getContext());
                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(1600, 240);
                llouter.setLayoutParams(layoutParams);
                llouter.setOrientation(LinearLayout.VERTICAL);
                llouter.setBackgroundDrawable(mMenuView.getResources().getDrawable(R.drawable.border));

                TextView tvmc = new TextView(mMenuView.getContext());
                tvmc.setWidth(1600);
                tvmc.setHeight(100);
                tvmc.setPadding(80,30,0,0);
                tvmc.setTextSize(16);
                tvmc.setTextColor(Color.parseColor("#000000"));
                tvmc.setText(XQMC);

                TextView tvdz = new TextView(mMenuView.getContext());
                tvdz.setWidth(1600);
                tvdz.setHeight(120);
                tvdz.setPadding(50,0,0,0);
                tvdz.setTextSize(14);
                tvdz.setTextColor(Color.parseColor("#999999"));
                tvdz.setText(XQDZ);

                llouter.addView(tvmc);
                llouter.addView(tvdz);
                mllPPLB.addView(llouter);
                llouter.setOnClickListener(itemsOnClick);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
