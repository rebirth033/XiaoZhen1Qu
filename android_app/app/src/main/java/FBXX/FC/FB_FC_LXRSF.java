package FBXX.FC;

import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewGroup.LayoutParams;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.TextView;
import com.example.administrator.Public.R;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.List;
import Common.Base;

public class FB_FC_LXRSF extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private LinearLayout mllSFLB;

    public FB_FC_LXRSF(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_lxrsf, null);
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
        //获取身份
        HandlerLXRSF();
    }

    private void initView(View.OnClickListener itemsOnClick) {
        TextView mtvwc = (TextView) mMenuView.findViewById(R.id.tvwc);
        mllSFLB = (LinearLayout) mMenuView.findViewById(R.id.ll_fb_fc_lxrsf_body);
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

    //处理身份
    public void HandlerLXRSF() {
        try {
            String JList = "[{\"CODENAME\":\"个人房东\"},{\"CODENAME\":\"个人转租\"},{\"CODENAME\":\"职业房东\"},{\"CODENAME\":\"经纪人\"}]";
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
                mllSFLB.addView(llouter);
                llouter.setOnClickListener(new View.OnClickListener(){
                    public void onClick(View v) {
                        ResetCheck();
                        List<View> viewList = Base.getAllChildViews(v);
                        ImageView ivxqmc = (ImageView)viewList.get(1);
                        ivxqmc.setImageResource(R.drawable.check_purple);
                        ivxqmc.setTag(R.drawable.check_purple);
                    }
                });
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    //获取身份
    public String GetCheck(){
        String bhfy = new String();
        List<View> viewList = Base.getAllChildViews(mllSFLB);
        for(int i = 0; i < viewList.size(); i++) {
            if(viewList.get(i).getClass().toString().contains("LinearLayout")){
                List<View> vs = Base.getAllChildViews(viewList.get(i));
                TextView tv = (TextView)vs.get(0);
                ImageView iv = (ImageView)vs.get(1);
                int res = (int) iv.getTag();
                if(res == R.drawable.check_purple) {
                    bhfy += tv.getText()+",";
                }
            }
        }
        return bhfy.substring(0,bhfy.length()-1);
    }

    //实现单选效果
    public void ResetCheck(){
        List<View> viewList = Base.getAllChildViews(mllSFLB);
        for(int i=0;i<viewList.size();i++){
            if(viewList.get(i).getClass().toString().contains("ImageView")){
                ImageView iv = (ImageView)viewList.get(i);
                iv.setImageResource(R.drawable.check_gray);
                iv.setTag(R.drawable.check_gray);
            }
        }
    }
}
