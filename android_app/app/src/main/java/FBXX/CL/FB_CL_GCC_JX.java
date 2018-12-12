package FBXX.CL;

import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.AsyncTask;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
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

public class FB_CL_GCC_JX extends PopupWindow {

    private LinearLayout mllLB;
    private ImageView mivBack;
    private View mMenuView;

    public FB_CL_GCC_JX(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_cl_gcc_jx, null);
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
        //获取列表
        //GetLB(itemsOnClick);
        String JList = "[{\"XQMC\":\"挖掘机\"},{\"XQMC\":\"吊车\"},{\"XQMC\":\"铲车\"},{\"XQMC\":\"压路机\"}]";
        HandlerLB(JList, itemsOnClick);
    }

    //初始化页面
    private void initView(final View.OnClickListener itemsOnClick) {
        mivBack = (ImageView) mMenuView.findViewById(R.id.iv_back);
        mllLB = (LinearLayout) mMenuView.findViewById(R.id.llLB);
        mivBack.setOnClickListener(itemsOnClick);
    }

    //获取列表
    public void GetLB(final View.OnClickListener itemsOnClick) {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String JResult = jsonobject.getString("Result");
                    String JList = jsonobject.getString("list");
                    HandlerLB(JList,itemsOnClick);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;

                String targeturl = "http://www.915fl.com/FC/LoadXQJBXXSByPY";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair XQMC = new BasicNameValuePair("XQMC", "");
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(XQMC);
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

    //处理列表
    public void HandlerLB(String JList,View.OnClickListener itemsOnClick) {
        try {
            mllLB.removeAllViews();//清空布局
            JSONArray jsonarray = new JSONArray(JList);
            for (int i = 0; i < jsonarray.length(); i++) {
                JSONObject jsonObject = jsonarray.getJSONObject(i);
                String XQMC = jsonObject.getString("XQMC");

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

                llouter.addView(tvmc);
                mllLB.addView(llouter);
                llouter.setOnClickListener(itemsOnClick);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
