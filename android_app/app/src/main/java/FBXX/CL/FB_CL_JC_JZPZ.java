package FBXX.CL;

import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.AsyncTask;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewGroup.LayoutParams;
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

public class FB_CL_JC_JZPZ extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private LinearLayout mllLB;

    public FB_CL_JC_JZPZ(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_cl_jc_jzpz, null);
        //设置SelectPicPopupWindow的View
        this.setContentView(mMenuView);
        //设置SelectPicPopupWindow弹出窗体的宽
        this.setWidth(LayoutParams.FILL_PARENT);
        //设置SelectPicPopupWindow弹出窗体的高
        this.setHeight(LayoutParams.FILL_PARENT);
        //设置SelectPicPopupWindow弹出窗体可点击
        this.setFocusable(true);
        //设置SelectPicPopupWindow弹出窗体动画效果
        this.setAnimationStyle(R.style.AnimBottom);
        //实例化一个ColorDrawable颜色为半透明
        ColorDrawable dw = new ColorDrawable(0xb0000000);
        //设置SelectPicPopupWindow弹出窗体的背景
        this.setBackgroundDrawable(dw);
        //初始化视图
        initView(itemsOnClick);
        //获取数据
        String JList = "[{\"CODENAME\":\"GPS导航\"},{\"CODENAME\":\" 倒车影像\"},{\"CODENAME\":\" 定速巡航\"},{\"CODENAME\":\" 多媒体控制\"}]";
        HandlerData(JList);
    }

    private void initView(View.OnClickListener itemsOnClick) {
        TextView mtvwc = (TextView) mMenuView.findViewById(R.id.tvwc);
        mllLB = (LinearLayout) mMenuView.findViewById(R.id.ll_fb_data_body);
        mtvwc.setOnClickListener(itemsOnClick);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.tv0:
                //Input("0");
                break;
        }
    }

    //获取数据
    public void GetData() {
        new AsyncTask<String, Void, Object>() {
            protected void onPostExecute(Object result) {
                try {
                    JSONObject jsonobject = new JSONObject(result.toString());
                    String JResult = jsonobject.getString("Result");
                    String JList = jsonobject.getString("list");
                    HandlerData(JList);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            protected Object doInBackground(String... params) {
                Object result = null;

                String targeturl = "http://www.915fl.com/Common/LoadCODESByTYPENAME";
                try {
                    HttpPost httpRequest = new HttpPost(targeturl);
                    NameValuePair TYPENAME = new BasicNameValuePair("TYPENAME", "车辆加装配置");
                    NameValuePair TBName = new BasicNameValuePair("TBName", "CODES_FC");
                    List<NameValuePair> parameters = new ArrayList<NameValuePair>();//创建一个集合，存NameValuePair对象的
                    parameters.add(TYPENAME);
                    parameters.add(TBName);
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

    //处理数据
    public void HandlerData(String JList) {
        try {
            JSONArray jsonarray = new JSONArray(JList);
            for (int i = 0; i < jsonarray.length(); i++) {
                JSONObject jsonObject = jsonarray.getJSONObject(i);
                String CODENAME = jsonObject.getString("CODENAME");

                LinearLayout llouter = new LinearLayout(mMenuView.getContext());
                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(1600, 240);
                llouter.setLayoutParams(layoutParams);
                llouter.setOrientation(LinearLayout.HORIZONTAL);
                llouter.setBackgroundDrawable(mMenuView.getResources().getDrawable(R.drawable.border));

                TextView tvmc = new TextView(mMenuView.getContext());
                tvmc.setWidth(1000);
                tvmc.setHeight(240);
                tvmc.setPadding(80,60,0,0);
                tvmc.setTextSize(18);
                tvmc.setTextColor(Color.parseColor("#000000"));
                tvmc.setText(CODENAME);

                ImageView ivmc = new ImageView(mMenuView.getContext());
                ivmc.setLayoutParams(new ViewGroup.LayoutParams(200, 240));
                ivmc.setScaleType(ImageView.ScaleType.FIT_XY);
                ivmc.setPadding(60, 80, 60, 80);
                //显示在界面上
                ivmc.setImageResource(R.drawable.check_gray);
                ivmc.setTag(R.drawable.check_gray);
                llouter.addView(tvmc);
                llouter.addView(ivmc);
                mllLB.addView(llouter);
                llouter.setOnClickListener(new View.OnClickListener(){
                    public void onClick(View v) {
                        List<View> viewList = Base.getAllChildViews(v);
                        ImageView ivxqmc = (ImageView)viewList.get(1);
                        int res = (int) ivxqmc.getTag();
                        if(res == R.drawable.check_gray) {
                            ivxqmc.setImageResource(R.drawable.check_purple);
                            ivxqmc.setTag(R.drawable.check_purple);
                        }
                        else {
                            ivxqmc.setImageResource(R.drawable.check_gray);
                            ivxqmc.setTag(R.drawable.check_gray);
                        }
                    }
                });
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    //获取多选
    public String GetCheck(){
        String bhfy = new String();
        List<View> viewList = Base.getAllChildViews(mllLB);
        for(int i=0;i<viewList.size();i++){
            if(viewList.get(i).getClass().toString().contains("LinearLayout")){
                List<View> vs = Base.getAllChildViews(viewList.get(i));
                TextView tv = (TextView)vs.get(0);
                ImageView iv = (ImageView)vs.get(1);
                int res = (int) iv.getTag();
                if(res == R.drawable.check_purple) {
                    bhfy += tv.getText() + ",";
                }
            }
        }
        return bhfy.substring(0, bhfy.length() - 1);
    }
}
