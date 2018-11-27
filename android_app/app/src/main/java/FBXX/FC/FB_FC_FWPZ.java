package FBXX.FC;

import com.example.administrator.Public.R;
import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.TextView;
import java.util.List;
import Common.Base;

public class FB_FC_FWPZ extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private LinearLayout mllfwpz;
    private TextView mtvwc;

    public FB_FC_FWPZ(Activity context, View.OnClickListener itemsOnClick) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_fc_fwpz, null);
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
        initView(itemsOnClick, context);
    }

    private void initView(View.OnClickListener itemsOnClick, Activity context) {
        mllfwpz = (LinearLayout) mMenuView.findViewById(R.id.ll_fb_fc_fwpz);
        mtvwc = (TextView) mMenuView.findViewById(R.id.tvwc);
        mtvwc.setOnClickListener(itemsOnClick);

        loadFWPZ(context);
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.llcw:
//                mtvcw.setHintTextColor(Color.parseColor("#bc6ba6"));
//                mtvcw.setTextColor(Color.parseColor("#bc6ba6"));
//                mtvdt.setHintTextColor(Color.parseColor("#999999"));
//                mtvdt.setTextColor(Color.parseColor("#000000"));
//                tabcw.select();
//                mvpbody.setCurrentItem(0);
                break;
        }
    }

    //加载房屋配置
    public void loadFWPZ(final Activity context){

        String[] fwpzs0 = "家具,家电,其他".split(",");
        for(int i = 0; i < fwpzs0.length; i++) {
            LinearLayout llouter = new LinearLayout(context);
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(1600, 160);
            llouter.setLayoutParams(layoutParams);
            llouter.setOrientation(LinearLayout.HORIZONTAL);
            llouter.setBackgroundColor(Color.parseColor("#ffffff"));

            TextView tvmc = new TextView(context);
            layoutParams = new LinearLayout.LayoutParams(320, 160);
            layoutParams.setMargins(0, 0, 0, 0);
            tvmc.setLayoutParams(layoutParams);
            tvmc.setTextSize(15);
            tvmc.setTextColor(Color.parseColor("#666666"));
            tvmc.setText(fwpzs0[i]);

            llouter.addView(tvmc);
            mllfwpz.addView(llouter);

            String[] fwpzs1 = new String[]{};
            String[] fwpzs2 = new String[]{};

            if(fwpzs0[i].indexOf("家具") != -1){
                fwpzs1 = "桌椅,沙发,衣柜,床".split(",");
            }
            if(fwpzs0[i].indexOf("家电") != -1){
                fwpzs1 = "电视,冰箱,空调,洗衣机".split(",");
                fwpzs2 = "热水器,微波炉".split(",");
            }
            if(fwpzs0[i].indexOf("其他") != -1){
                fwpzs1 = "暖气,宽带,阳台,燃气灶".split(",");
            }

            llouter = new LinearLayout(context);
            layoutParams = new LinearLayout.LayoutParams(1600, 160);
            llouter.setLayoutParams(layoutParams);
            llouter.setOrientation(LinearLayout.HORIZONTAL);
            llouter.setBackgroundColor(Color.parseColor("#ffffff"));

            for(int j = 0; j < fwpzs1.length; j++) {
                tvmc = new TextView(context);
                layoutParams = new LinearLayout.LayoutParams(320, 120);
                layoutParams.setMargins(5, 5, 5, 5);
                tvmc.setLayoutParams(layoutParams);
                tvmc.setTextSize(16);
                tvmc.setTextColor(Color.parseColor("#000000"));
                tvmc.setBackgroundColor(Color.parseColor("#ececec"));
                tvmc.setText(fwpzs1[j]);
                tvmc.setGravity(Gravity.CENTER);
                tvmc.setOnClickListener(new View.OnClickListener(){
                    public void onClick(View v) {
                        TextView tv = (TextView)v;
                        if(tv.getCurrentTextColor() == Color.parseColor("#ffffff")) {
                            tv.setTextColor(Color.parseColor("#000000"));
                            tv.setBackgroundColor(Color.parseColor("#ececec"));
                        }
                        else{
                            tv.setTextColor(Color.parseColor("#ffffff"));
                            tv.setBackgroundColor(Color.parseColor("#bc6ba6"));
                        }
                    }
                });
                llouter.addView(tvmc);
            }

            mllfwpz.addView(llouter);

            if(fwpzs0[i].indexOf("家电") != -1){

                llouter = new LinearLayout(context);
                layoutParams = new LinearLayout.LayoutParams(1600, 160);
                llouter.setLayoutParams(layoutParams);
                llouter.setOrientation(LinearLayout.HORIZONTAL);
                llouter.setBackgroundColor(Color.parseColor("#ffffff"));

                for(int j = 0; j < fwpzs2.length; j++) {
                    tvmc = new TextView(context);
                    layoutParams = new LinearLayout.LayoutParams(320, 120);
                    layoutParams.setMargins(5, 5, 5, 5);
                    tvmc.setLayoutParams(layoutParams);
                    tvmc.setTextSize(16);
                    tvmc.setTextColor(Color.parseColor("#000000"));
                    tvmc.setBackgroundColor(Color.parseColor("#ececec"));
                    tvmc.setText(fwpzs2[j]);
                    tvmc.setGravity(Gravity.CENTER);
                    tvmc.setOnClickListener(new View.OnClickListener(){
                        public void onClick(View v) {
                            TextView tv = (TextView)v;
                            if(tv.getCurrentTextColor() == Color.parseColor("#ffffff")) {
                                tv.setTextColor(Color.parseColor("#000000"));
                                tv.setBackgroundColor(Color.parseColor("#ececec"));
                            }
                            else{
                                tv.setTextColor(Color.parseColor("#ffffff"));
                                tv.setBackgroundColor(Color.parseColor("#bc6ba6"));
                            }
                        }
                    });
                    llouter.addView(tvmc);
                }
                mllfwpz.addView(llouter);
            }
        }
    }

    //获取房屋配置
    public String GetFWPZ(){

        String bhfy = new String();
        List<View> viewList = Base.getAllChildViews(mllfwpz);
        for(int i = 0; i < viewList.size(); i++) {
            if(viewList.get(i).getClass().toString().contains("LinearLayout")){
                List<View> vs = Base.getAllChildViews(viewList.get(i));
                for(int j=0;j<vs.size();j++){
                    TextView tv = (TextView)vs.get(j);
                    if(tv.getCurrentTextColor() == Color.parseColor("#ffffff")) {
                        bhfy += tv.getText()+",";
                    }
                }
            }
        }
        return bhfy.substring(0,bhfy.length()-1);
    }

    //设置房屋配置
    public void SetFWPZ(String fwpz){
        String[] fwpzs = fwpz.split(",");
        for(int k = 0; k < fwpzs.length; k++) {
            List<View> viewList = Base.getAllChildViews(mllfwpz);
            for(int i = 0; i < viewList.size(); i++) {
                if(viewList.get(i).getClass().toString().contains("LinearLayout")){
                    List<View> vs = Base.getAllChildViews(viewList.get(i));
                    for(int j = 0; j < vs.size(); j++){
                        TextView tv = (TextView)vs.get(j);
                        if(tv.getText().toString().indexOf(fwpzs[k]) != -1) {
                            tv.setTextColor(Color.parseColor("#ffffff"));
                            tv.setBackgroundColor(Color.parseColor("#bc6ba6"));
                        }
                    }
                }
            }
        }
    }
}
