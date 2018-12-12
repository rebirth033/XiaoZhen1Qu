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

public class FB_FC_SP_JYHY extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private LinearLayout mllJYHYLB;

    public FB_FC_SP_JYHY(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_sp_jyhy, null);
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
        //处理商铺类型
        HandlerSPLX();
    }

    private void initView(View.OnClickListener itemsOnClick) {

        mllJYHYLB = (LinearLayout) mMenuView.findViewById(R.id.ll_fb_fc_jyhy_body);

        mMenuView.findViewById(R.id.tvwc).setOnClickListener(itemsOnClick);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.tv0:
                //Input("0");
                break;
        }
    }

    //处理商铺类型
    public void HandlerSPLX() {
        try {
            String JList = "[{\"CODENAME\":\"餐饮美食\"},{\"CODENAME\":\" 美容美发\"},{\"CODENAME\":\" 服饰鞋包\"},{\"CODENAME\":\" 休闲娱乐\"}]";
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
                mllJYHYLB.addView(llouter);
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

    //获取单选
    public String GetCheck(){
        String bhfy = new String();
        List<View> viewList = Base.getAllChildViews(mllJYHYLB);
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
        List<View> viewList = Base.getAllChildViews(mllJYHYLB);
        for(int i=0;i<viewList.size();i++){
            if(viewList.get(i).getClass().toString().contains("ImageView")){
                ImageView iv = (ImageView)viewList.get(i);
                iv.setImageResource(R.drawable.check_gray);
                iv.setTag(R.drawable.check_gray);
            }
        }
    }
    //设置单选
    public void SetCheck(String splx){
        List<View> viewList = Base.getAllChildViews(mllJYHYLB);
        for(int i = 0; i < viewList.size(); i++) {
            if(viewList.get(i).getClass().toString().contains("LinearLayout")){
                List<View> vs = Base.getAllChildViews(viewList.get(i));
                TextView tv = (TextView)vs.get(0);
                ImageView iv = (ImageView)vs.get(1);
                if(tv.getText().toString().equalsIgnoreCase(splx)) {
                    iv.setImageResource(R.drawable.check_purple);
                    iv.setTag(R.drawable.check_purple);
                }
            }
        }
    }
}
