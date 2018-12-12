package FBXX.CL;

import com.example.administrator.Public.R;
import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.PopupWindow;
import android.widget.TextView;
import java.util.ArrayList;
import java.util.List;
import Common.ViewAdapter;
import Common.WheelStyle;
import Common.WheelView;

public class FB_CL_JC_YSSP extends PopupWindow implements View.OnClickListener {

    private View mMenuView;
    private ViewGroup mllclys; //颜色
    private ViewGroup mllspsj; //上牌时间
    public TextView mtvclys; //颜色
    public TextView mtvspsj; //上牌时间
    private TabLayout.Tab tabclys; //颜色
    private TabLayout.Tab tabspsj; //上牌时间
    private TextView mtvysqd; //颜色
    private TextView mtvspsjqd; //上牌时间
    private TabLayout mtbbody;
    private ViewPager mvpbody;
    public WheelView mwvclys;//颜色
    public WheelView mwvyear;//上牌时间_年
    public WheelView mwvmonth;//上牌时间_月

    public FB_CL_JC_YSSP(Activity context, View.OnClickListener itemsOnClick, String type) {
        super(context);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        mMenuView = inflater.inflate(R.layout.fb_cl_jc_yssp, null);
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
        initView(itemsOnClick,context, type);
    }

    private void initView(View.OnClickListener itemsOnClick, Activity context, String type) {

        mllclys = (ViewGroup) mMenuView.findViewById(R.id.llclys);
        mllspsj = (ViewGroup) mMenuView.findViewById(R.id.llspsj);
        mtvclys = (TextView) mMenuView.findViewById(R.id.tv_clys);
        mtvspsj = (TextView) mMenuView.findViewById(R.id.tv_spsj);

        mtbbody = (TabLayout) mMenuView.findViewById(R.id.tb_body);
        mvpbody = (ViewPager) mMenuView.findViewById(R.id.vp_body);

        mllclys.setOnClickListener(this);
        mllspsj.setOnClickListener(this);

        tabclys = mtbbody.newTab().setCustomView(mllclys);
        tabspsj = mtbbody.newTab().setCustomView(mllspsj);
        mtbbody.addTab(tabclys);
        mtbbody.addTab(tabspsj);

        List<View> viewList = new ArrayList<>();
        LayoutInflater inflater = LayoutInflater.from(context);
        View vys = inflater.inflate(R.layout.fragment_clys, null);
        View vspsj = inflater.inflate(R.layout.fragment_spsj, null);
        viewList.add(vys);
        viewList.add(vspsj);

        mwvclys = (WheelView) vys.findViewById(R.id.wvclys);
        mwvyear = (WheelView) vspsj.findViewById(R.id.wvyear);
        mwvmonth = (WheelView) vspsj.findViewById(R.id.wvmonth);

        mtvysqd = (TextView) vys.findViewById(R.id.tv_clys_qd);
        mtvspsjqd = (TextView) vspsj.findViewById(R.id.tv_spsj_qd);

        mtvysqd.setOnClickListener(this);
        mtvspsjqd.setOnClickListener(itemsOnClick);

        ViewAdapter adapter = new ViewAdapter(viewList);
        mvpbody.setAdapter(adapter);

        if(type == "CLYS")
            mllclys.performClick();
        if(type == "SPSJ")
            mllspsj.performClick();
    }

    //事件监听
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.llclys:
                mtvclys.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvclys.setTextColor(Color.parseColor("#bc6ba6"));
                mtvspsj.setHintTextColor(Color.parseColor("#999999"));
                mtvspsj.setTextColor(Color.parseColor("#000000"));
                tabclys.select();
                mvpbody.setCurrentItem(0);
                break;
            case R.id.llspsj:
                mtvclys.setHintTextColor(Color.parseColor("#999999"));
                mtvclys.setTextColor(Color.parseColor("#000000"));
                mtvspsj.setHintTextColor(Color.parseColor("#bc6ba6"));
                mtvspsj.setTextColor(Color.parseColor("#000000"));
                tabspsj.select();
                mvpbody.setCurrentItem(1);
                break;
            case R.id.tv_clys_qd:
                mtvclys.setText(WheelStyle.createCLYSString().get(mwvclys.getCurrentItem()));
                mllspsj.performClick();
                break;
        }
    }
}
